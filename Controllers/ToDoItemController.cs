using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoListApi.Models;
using ToDoListApi.Services;

namespace ToDoListApi.Controllers;

[ApiController]

[Route("api/[Controller]")]

public class ToDoItemController : ControllerBase
{
    ToDoItemService _todoItemService;

    public ToDoItemController(ToDoItemService toDoItemService)
    {
        _todoItemService = toDoItemService;
    }

    [HttpGet("GetAllTasks")]
    public ActionResult<Task> GetAllTasks()
    {       
        List<ToDoItem> list = new List<ToDoItem>();
        list = _todoItemService.GetToDoItemList();
        return Ok(list);
    }
    [HttpGet("GetTaskUser")]
    public ActionResult<Task> GetTaskUser(int idUser)
    {        
        List<ToDoItem> list = new List<ToDoItem>();
        list = _todoItemService.GetToDoUserItem(idUser);
        return Ok(list);
    }
    [HttpGet("GetToDoItem")]
    public ActionResult<Task> GetToDoItem(int idUser, int idtask)
    {        
        ToDoItem toDoItem = new ToDoItem(); 
        toDoItem = _todoItemService.GetToDoItem(idUser, idtask);
        if (toDoItem == null)
        {
            return NotFound();
        }
        return Ok(toDoItem);
    }

    [HttpPost ("PostTask")]
    public ActionResult<Task> PostTask([FromBody]ToDoItem toDoItem)
    {
        _todoItemService.createToDoItem(toDoItem);

        return CreatedAtAction(nameof(GetToDoItem),
            new { idUser = toDoItem.UserData.IdUser, idtask = toDoItem.IdTask }, toDoItem);
    }
    //[HttpPut]
    //public ActionResult<Task> PutTask()
    //{        //Todavia no hace nada

    //    return Ok();
    //}
    //[HttpDelete]
    //public ActionResult<Task> DeleteTask()
    //{        //Todavia no hace nada

    //    return Ok();
    //}

}
