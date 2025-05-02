using ToDoListApi.DTOs;
using ToDoListApi.Models;

namespace ToDoListApi.Repositories
{
    public interface IUserRepository 
    {
        public UserDTO GetById(int id);

        public List<UserDTO> GetUsersList();

        public void InsertUser(string userName, string password, int max);

        public int MaxId();        

        public bool UserExist(string userName);
    }
}
