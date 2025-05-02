using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using ToDoListApi.Models;
using ToDoListApi.Repositories;

namespace ToDoListApi.Services;

public class ToDoItemService
{
    public readonly IToDoItemRepository _toDoItemRepository;

    public ToDoItemService( IToDoItemRepository toDoItemRepository)
    {
        _toDoItemRepository = toDoItemRepository;
    }


    public List<ToDoItem> GetToDoItemList()
    {
        return _toDoItemRepository.GetToDoItemlist();
    }

    public List<ToDoItem> GetToDoUserItem(int idUser)
    {
       return _toDoItemRepository.GetToDoUserItem(idUser);
    }

    public ToDoItem GetToDoItem(int idUser , int idTask)
    {
        return _toDoItemRepository.GetToDoItem(idUser, idTask);
       
    }

    public void createToDoItem(ToDoItem item)
    {
       _toDoItemRepository.createToDoItem(item);
        
    }

 

}
