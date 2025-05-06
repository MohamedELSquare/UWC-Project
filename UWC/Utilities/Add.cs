using BLL;
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace UWC.Utilities
{
    public class Add
    {
        private readonly SignalService _signalService;
        private readonly IServiceScopeFactory _scopeFactory;

        public Add(IServiceScopeFactory scopeFactory, SignalService signalService)
        {
            _scopeFactory = scopeFactory;
            _signalService = signalService;
        }
        public async Task AddToDatabase(Tag tag)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var direction = "";
                var context = scope.ServiceProvider.GetRequiredService<RealTimeContext>();
                var lastRead = await context.TagDirections.FirstOrDefaultAsync(t => t.Epc == tag.Epc);
                var sensorRead = context.Sensors.OrderByDescending(s=>s.TimeStamp).FirstOrDefault(s=>s.TimeStamp.AddSeconds(60) >= tag.TimeStamp);
                if (sensorRead == null)
                    direction = "Undefiend";
                else if (sensorRead.TimeStamp.AddSeconds(60) >= tag.TimeStamp)
                    direction = sensorRead.Direction == 1 ? "In" : "Out";
                if (lastRead == null)
                {
                    var warehouse = new Warehouse();
                    var data = new TagDirection
                    {
                        Epc = tag.Epc,
                        Direction = direction,
                        Rssi = tag.Rssi,
                        Tid = tag.Tid,
                        TimeStamp = tag.TimeStamp,
                        //SensorMapId = sensorRead.SensorId,
                    };
                    await context.AddAsync(data);
                    //await _signalService.AddSignalAsync(data);

                }
                else
                {
                    lastRead.TimeStamp = tag.TimeStamp;
                    lastRead.Rssi = tag.Rssi;
                    lastRead.Tid = tag.Tid;
                    lastRead.Direction = lastRead.Direction == "Undefiend" || (lastRead.Direction != "Undefiend" && direction != "Undefiend")
                        ? direction : lastRead.Direction;
                    context.Update(lastRead);
                    //await _signalService.UpdateSignalAsync(lastRead);
                }
                await context.SaveChangesAsync();
            }

        }
    }
}
