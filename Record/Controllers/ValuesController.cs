using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Record.Dtos;

namespace Record.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult Login(LoginDto loginDto)
        {
            loginDto.Email = string.Empty;
            return Ok("başarılı");
        }


        [HttpPost("[action]")]
        public IActionResult LoginWithRecord(LoginDtoRecord loginDtoRecord)
        {
            //loginDtoRecord.Email = string.Empty; //bir defa kullanılacak olduğu için başka bir değer atanamaz
            return Ok("başarılı");
        }

    }
}
