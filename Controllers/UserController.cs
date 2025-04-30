using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ToDoListApi.Models;
using ToDoListApi.Sevices;

namespace ToDoListApi.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUser()
    {
        UserService userService = new UserService();
        List<User> users = new List<User>();
        users = userService.GetUsersList();
        return Ok(users);
    }

  

    [HttpPost]
    public ActionResult<User> PostUser(string userName , string password)
    {
        UserService userService = new UserService();

        if (userService.UserExist(userName)) {
            return Conflict("el usuario existe.");
        }

        userService.InsertUser(userName,password);


        return NoContent();

    }

  

    [HttpPut]
    public ActionResult<User> PutUser()
    {
        //Todavia no hace nada
        return Ok();
    }
    [HttpDelete]
    public ActionResult<User> DeleteUser() {
        //Todavia no hace nada

        return Ok();

    }


}
