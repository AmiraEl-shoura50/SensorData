using DbSensor.Context;
using Microsoft.AspNetCore.Mvc;

namespace DbSensor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly SensorDbContext _context;

        public SensorDataController(SensorDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> ReceiveSensorData([FromBody] SensorData data)
        {
            if (data == null)
            {
                return BadRequest("Invalid request body");
            }

            var sensorReading = new SensorData
            {
                HeartRate = data.HeartRate,
                SpO2 = data.SpO2
            };
            _context.SensorReadings.Add(sensorReading);
            await _context.SaveChangesAsync();

            return Ok("Data received successfully");
        }
    }
}
