using Microsoft.Data.SqlClient;
using ToDoListApi.DTOs;
using ToDoListApi.Models;
using ToDoListApi.Repositories;

namespace ToDoListApi.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDTO> GetUsersList()
        {
           return _userRepository.GetUsersList();
        }  

        public UserDTO GetById(int id)
        {
            return _userRepository.GetById(id);
            
        }

        public UserDTO InsertUser(string userName, string password)
        {

            int max = _userRepository.MaxId();

            if (_userRepository.UserExist(userName))
            {
                return null;
            }
            _userRepository.InsertUser(userName, password, max);

            UserDTO user = new UserDTO();
            user.IdUser = max;
            user.UserName = userName;

            return user;
            
        }

        

       
    }
}
