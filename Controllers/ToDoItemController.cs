using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;
using ToDoListApi.Sevices;

namespace ToDoListApi.Controllers;

[ApiController]

[Route("api/[Controller]")]

public class ToDoItemController : ControllerBase
{
    [HttpGet("GetAllTasks")]
    public ActionResult<Task> GetAllTasks()
    {       
        List<ToDoItem> list = new List<ToDoItem>();
        ToDoItemService service = new ToDoItemService();
        list = service.GetToDoItemlist();
        return Ok(list);
    }
    [HttpGet("GetTaskUser")]
    public ActionResult<Task> GetTaskUser(int idUser)
    {        
        List<ToDoItem> list = new List<ToDoItem>();
        ToDoItemService service = new ToDoItemService();
        list = service.GetToDoUserItem(idUser);
        return Ok(list);
    }
    [HttpGet("GetTask")]
    public ActionResult<Task> GetTask(int idUser, int idtask)
    {        
        ToDoItem toDoItem = new ToDoItem(); 
        ToDoItemService service = new ToDoItemService();
        toDoItem = service.GetToDoItem(idUser, idtask);
        return Ok(toDoItem);
    }

    [HttpPost ("PostTask")]
    public ActionResult<Task> PostTask([FromBody]ToDoItem toDoItem)
    {
        ToDoItemService service = new ToDoItemService();
        service.createToDoItem(toDoItem);

        return CreatedAtAction(nameof(GetTask),
            new { id = toDoItem.IdTask }, toDoItem);
    }
    [HttpPut]
    public ActionResult<Task> PutTask()
    {        //Todavia no hace nada

        return Ok();
    }
    [HttpDelete]
    public ActionResult<Task> DeleteTask()
    {        //Todavia no hace nada

        return Ok();
    }

}
