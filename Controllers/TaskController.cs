using Microsoft.AspNetCore.Mvc;

namespace ToDoListApi.Controllers;

[ApiController]

[Route("api/[Controller]")]

public class TaskController : ControllerBase
{
    [HttpGet]
    public ActionResult<Task> GetTask()
    {        //Todavia no hace nada

        return Ok();
    }
    [HttpPost]
    public ActionResult<Task> PostTask()
    {        //Todavia no hace nada

        return Ok();

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
