using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employeeshift.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeShiftController : ControllerBase
    {
        private readonly IEmployeeShiftService _employeeShiftService;
        public EmployeeShiftController(IEmployeeShiftService employeeShiftService)
        {
            _employeeShiftService = employeeShiftService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeShifts(int? id)
        {
            try
            {
                var result = await _employeeShiftService.GetEmployeeShifts(id);
                return Ok(result);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }
    }
}
