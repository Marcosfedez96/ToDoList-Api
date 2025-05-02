using Microsoft.Data.SqlClient;
using ToDoListApi.DTOs;
using ToDoListApi.Models;

namespace ToDoListApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;
        private readonly DataBaseConnection _databaseConection;


        public UserRepository(SqlConnection sqlConnection, DataBaseConnection databaseConection)
        {
            _connection = sqlConnection;
            _databaseConection = databaseConection;
        }


        public UserDTO GetById(int id)
        {

            DataBaseConnection connection = new DataBaseConnection();
            _databaseConection.SqlOpenConnection();
            string query = "select * from usuarios where id_usuario = @id;";
            SqlCommand cmd = new SqlCommand(query, _databaseConection.GetClient());
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserDTO user = new UserDTO()
                {
                    IdUser = reader.GetInt32(0),
                    UserName = reader.GetString(1),
                };
                return user;
            }
            _databaseConection.SqlCloseConnection();
            return null;
        }

        public List<UserDTO> GetUsersList()
        {

            List<UserDTO> users = new List<UserDTO>();
            _databaseConection.SqlOpenConnection();
            string query = "select * from usuarios;";
            SqlCommand cmd = new SqlCommand(query, _databaseConection.GetClient());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserDTO user = new UserDTO()
                {
                    IdUser = reader.GetInt32(0),
                    UserName = reader.GetString(1),

                };
                users.Add(user);
            }
            _databaseConection.SqlCloseConnection();
            return users;
        }

        public void InsertUser(string userName, string password, int max)
        {

            _databaseConection.SqlOpenConnection();
            string insertQuery = "INSERT INTO usuarios(id_usuario,nombre_usuario,password) VALUES(@max,@userName,@password);";
            SqlCommand cmd = new SqlCommand(insertQuery, _databaseConection.GetClient());
            cmd.Parameters.AddWithValue("@max", max);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            _databaseConection.SqlCloseConnection();
        }

        public int MaxId()
        {
            _databaseConection.SqlOpenConnection();
            string maxQuery = "select MAX(id_usuario + 1) from usuarios;";
            SqlCommand cmd = new SqlCommand(maxQuery, _databaseConection.GetClient());
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {

                return reader1.GetInt32(0);

            }
            return 0;
        }

        public bool UserExist(string userName)
        {
            List<User> userList = new List<User>();
            _databaseConection.SqlOpenConnection();

            string query = "SELECT Count(nombre_usuario) from usuarios where nombre_usuario = @userName;";
            SqlCommand cmd = new SqlCommand(query, _databaseConection.GetClient());
            cmd.Parameters.AddWithValue("@userName", userName);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int amount = reader.GetInt32(0);
                if (amount > 0)
                {
                    return true;
                }
            }
            _databaseConection.SqlCloseConnection();
            return false;
        }
    }
}
