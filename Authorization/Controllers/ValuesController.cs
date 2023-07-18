using Authorization.Attributes;
using DataAccess.Context;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    AppDbContext _context = new();

    [HttpGet("[action]")]
    public async Task<IActionResult> Get (string userName, CancellationToken cancellationToken)
    {
        User? user = await _context.Users.Where(x=>x.UserName == userName).FirstOrDefaultAsync(cancellationToken);

        string token = JwtProvider.CreateToken(user);

        return Ok(new {Token = token});
    }
    //[Role("GetAll")]
    [RoleFilter("GetAll")]
    [HttpGet("[action]")]
    [Authorize(AuthenticationSchemes ="Bearer")] //olmak zorunda
    public IActionResult GetAll()
    {
        IList<string> strings = new List<string>();
        for (int i = 0; i < 10; i++)
        {
            strings.Add("Name " + i);
        }
        return Ok(strings);
    }
    //[Role("Admin")]
    [RoleFilter("Admin")]
    [HttpGet("[action]")]
    //[Authorize(AuthenticationSchemes = "Bearer",Roles = "GetAll")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public IActionResult GetAllAdminRole()
    {
        IList<string> strings = new List<string>();
        for (int i = 0; i < 10; i++)
        {
            strings.Add("Name " + i);
        }
        return Ok(strings);
    }
}
