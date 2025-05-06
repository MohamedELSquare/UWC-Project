using BLL;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apllication.Controllers
{

    [ApiController]
    public class SignalController : ControllerBase
    {
        private readonly RealTimeContext _context;


        public SignalController(RealTimeContext context, SignalService signalService)
        {
            _context = context;
            //_signalService = signalService;
        }

        [HttpGet("Signal")]
        public async Task<IActionResult> Signal(string ID, int MoveDetected)
        {
            // Get alarm status for the gate
            var status = await _context.Alarms
                .Where(a => a.Gate == ID)
                .Select(a => a.Status)
                .FirstOrDefaultAsync();

            // Create and save sensor log
            var sensorLog = new Sensor
            {
                Direction = MoveDetected,
                SensorId = ID,
                TimeStamp = DateTime.Now
            };
            _context.Sensors.Add(sensorLog);
            await _context.SaveChangesAsync(); // To get generated Id

            // Get TagDirections that are within 40 seconds before the signal
            var tagReads = await _context.TagDirections
                .Where(t => t.TimeStamp.AddSeconds(40) >= sensorLog.TimeStamp)
                .ToListAsync();

            if (!tagReads.Any())
                return Ok(status);

            // Get related sensor with gate and warehouse
            var sensor = await _context.DSensors
                .Include(s => s.Gate)
                    .ThenInclude(g => g.Warehouse)
                .FirstOrDefaultAsync(s => s.Name == ID);

            if (sensor == null || sensor.Gate == null || sensor.Gate.Warehouse == null)
                return BadRequest("Sensor or related gate/warehouse not found.");

            var warehouse = sensor.Gate.Warehouse;

            foreach (var tag in tagReads)
            {
                // Determine direction
                tag.Direction = MoveDetected == 1 ? "In" : "Out";

                var pallet = await _context.Palletss
                    .FirstOrDefaultAsync(p => p.UID == tag.Epc);

                if (pallet != null)
                {
                    if (tag.Direction == "Out")
                    {
                        pallet.DWarehouseId = null;
                    }
                    else if (tag.Direction == "In" && pallet.DWarehouseId == null)
                    {
                        pallet.DWarehouseId = warehouse.Id;
                    }

                    _context.Palletss.Update(pallet);
                }

                // Set DSensorId from current sensor
                tag.DSensorId = sensor.Id;

                _context.TagDirections.Update(tag);
            }

            await _context.SaveChangesAsync();

            return Ok(status);
        }


        [HttpGet("Signal2")]
        [Obsolete("Old Versoin")]
        public async Task<ActionResult> Signal2(string ID, int MoveDetected)
        {
            var status = _context.Alarms.Where(x => x.Gate == ID).Select(x => x.Status).FirstOrDefault();
            var data = new Sensor
            {
                Direction = MoveDetected,
                SensorId = ID,
                TimeStamp = DateTime.Now
            };
            _context.Add(data);


            var tagRead = await _context.TagDirections.Where(x => x.TimeStamp.AddSeconds(40) >= data.TimeStamp).ToListAsync();
            if (tagRead.Count > 0)
            {
                foreach (var tag in tagRead)
                {
                    tag.Direction = data.Direction == 1 ? "In" : "Out";

                    var pallet = _context.Palletss.FirstOrDefault(p => p.UID == tag.Epc);
                    if (tag.Direction == "Out" && pallet != null)
                    {
                        pallet.DWarehouseId = null;
                    }
                    else if (pallet.DWarehouseId == null && tag.Direction == "In")
                    {
                        var sId = data.SensorId;

                        var sensor = _context.DSensors.FirstOrDefault(s => s.Name == sId);
                        var gate = _context.DGate.FirstOrDefault(g => g.Id == sensor.GateId);
                        var gateId = sensor.GateId;
                        var warehouseId = gate.WarehouseId;
                        pallet.DWarehouseId = warehouseId;
                    }

                    tag.DSensorId = data.Id; // Should be From Table Definition


                    _context.Update(tag);
                    _context.Palletss.Update(pallet);
                    _context.SaveChanges();
                    return Ok($"{status}#, PaltetId: {pallet.Id}, WarehouseId: {pallet.DWarehouseId}");
                }

            }
            return Ok(status);
        }



        [HttpGet("Status")]
        public async Task<ActionResult> Status(string GateName)
        {
            var status = _context.Alarms.Select(x => x.Status).FirstOrDefault();

            return Ok($"{status}#");
        }
    }
}
