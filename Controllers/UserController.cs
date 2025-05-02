using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ToDoListApi.DTOs;
using ToDoListApi.Models;
using ToDoListApi.Services;

namespace ToDoListApi.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class UserController : ControllerBase
{
    UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet ("GetUser")]
    public ActionResult<IEnumerable<UserDTO>> GetUser()
    {
        
        List<UserDTO> users = new List<UserDTO>();
        users = _userService.GetUsersList();
        return Ok(users);
    }

    [HttpGet("{userId}", Name = "GetUserById")]

    public ActionResult<UserDTO> GetUserById(int userId)
    {
        return Ok(_userService.GetById(userId));
    }

  

    [HttpPost(Name = "PostUser")]
    public ActionResult<User> PostUser(string userName , string password)
    {
        var user = _userService.InsertUser(userName, password);
       if(user == null)
        {
            return NoContent();
        }
        ;

        return CreatedAtAction(nameof(GetUserById), new { userId = user.IdUser }, user);

    }



    //[HttpPut]
    //public ActionResult<User> PutUser()
    //{
    //    Todavia no hace nada
    //    return Ok();
    //}
    //[HttpDelete]
    //public ActionResult<User> DeleteUser()
    //{
    //    Todavia no hace nada

    //    return Ok();

    //}


}
