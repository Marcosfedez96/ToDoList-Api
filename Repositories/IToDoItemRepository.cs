using ToDoListApi.DTOs;
using ToDoListApi.Models;

namespace ToDoListApi.Repositories;

public interface IToDoItemRepository
{
    public List<ToDoItem> GetToDoItemlist();
    public List<ToDoItem> GetToDoUserItem(int idUser);
    public ToDoItem GetToDoItem(int idUser, int idTask);
    public void createToDoItem(ToDoItem item);
    public UserDTO SearchUser(int IdUser);


}
