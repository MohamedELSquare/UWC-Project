using DAL.Context;
using DAL.Models;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UHFAPP;

namespace UWC.Utilities
{

    public class ContinuousTaskService : BackgroundService
    {
        private readonly Add _context;
        private readonly ILogger<ContinuousTaskService> _logger;
        private StringBuilder _ip;
        private uint _port;

        public ContinuousTaskService(
            ILogger<ContinuousTaskService> logger,
            Add context)
        {
            _logger = logger;
            _context = context;
            _ip = new StringBuilder("192.168.8.147");
            _port = 8888;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Continuous Task Service started.");

            // Initialize UHF connection once
            UHFAPI.TCPConnect(_ip, _port);
            UHFAPI.UHFInventory();
            UHFAPI.UHFSetCW(1);

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    await DoWorkAsync(stoppingToken);
                    await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken); // Short delay
                }
            }
            catch (TaskCanceledException)
            {
            }
            finally
            {
                _logger.LogInformation("Continuous Task Service stopped.");
            }
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            await Task.Run(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var d = UHFAPI.uhfGetReceived();
                    if (d == null) continue;

                    if (d.Epc.Contains("E2806"))
                    {
                        var data = new Tag
                        {
                            Epc = d.Epc,
                            Ant = d.Ant,
                            Rssi = d.Rssi,
                            Tid = d.Tid,
                            TimeStamp = DateTime.Now
                        };
                       await _context.AddToDatabase(data);
                    }
                }
            }, stoppingToken);
        }
    }
}
