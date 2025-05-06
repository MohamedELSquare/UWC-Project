using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using UHFAPP;
using UWC.Utilities;

namespace UWC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalController : ControllerBase
    {
        private readonly RealTimeContext _context;

        public SignalController(RealTimeContext context)
        {
            _context = context;
        }
        [HttpGet("Signal")]
        public async Task<ActionResult> Signal(string ID,int MoveDetected)
        {
            
            return Ok("Saved");
        }
    }
}
