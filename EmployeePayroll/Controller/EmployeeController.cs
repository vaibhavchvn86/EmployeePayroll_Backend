using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager manager;
        public EmployeeController(IEmployeeManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("addemp")]
        public async Task<IActionResult> AddEmp([FromBody] RegisterModel add)
        {
            try
            {
                var check = await this.manager.AddEmp(add);
                if (check != null)
                {
                    return Ok(new ResponseModel<RegisterModel> { Status = true, Message = "Employee Register Successfully", Data = check });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Employee Not Registered" });
                }

            }
            catch (Exception e)
            {
                return NotFound(new { Status = false, Message = e.Message });
            }
        }

        [HttpPut]
        [Route("editemp")]
        public async Task<IActionResult> EditEmp([FromBody] RegisterModel edit)
        {
            try
            {
                var check = await this.manager.EditEmp(edit);
                if(check != null)
                {
                    return Ok(new ResponseModel<RegisterModel> { Status = true, Message = "Employee Details updated Successfully", Data = check });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Employee Details Not Updated" });
                }

            }
            catch(Exception e)
            {
                return NotFound(new { Status = false, Message = e.Message });
            }
        }

        [HttpDelete]
        [Route("delemp")]
        public async Task<IActionResult> DeleteEmp(string id)
        {
            try
            {
                var check = await this.manager.DeleteEmp(id);
                if (check != null)
                {
                    return Ok(new ResponseModel<RegisterModel> { Status = true, Message = "Employee Deleted Successfully", Data = check });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Employee Not Deleted" });
                }

            }
            catch (Exception e)
            {
                return NotFound(new { Status = false, Message = e.Message });
            }
        }

        [HttpGet]
        [Route("getemp")]
        public IActionResult GetEmp()
        {
            try
            {
                IEnumerable<RegisterModel> check = this.manager.GetEmp().ToList();
                if (check != null)
                {
                    return Ok(new { Status = true, Message = "Employee Retrived Successfully", Data = check });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Employee Data Not Found" });
                }

            }
            catch (Exception e)
            {
                return NotFound(new { Status = false, Message = e.Message });
            }
        }
    }
}
