using Microsoft.Data.SqlClient;
using ToDoListApi.Models;

namespace ToDoListApi.Sevices
{
    public class UserService
    {

        public List<User> GetUsersList()
        {
            List<User> users = new List<User>();
            DataBaseConnection connection = new DataBaseConnection();
            connection.SqlOpenConnection();
            string query = "select * from usuarios;";
            SqlCommand cmd = new SqlCommand(query, connection.GetClient());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User user = new User()
                {
                    IdUser = reader.GetInt32(0),
                    UserName = reader.GetString(1),
                    Password = reader.GetString(2)
                };
                users.Add(user);
            }connection.SqlCloseConnection();
            return users;
        }


        public void InsertUser(string userName, string password)
        {
            DataBaseConnection connection = new DataBaseConnection();
            connection.SqlOpenConnection();
            int max = MaxId();
            string insertQuery = "INSERT INTO usuarios(id_usuario,nombre_usuario,password) VALUES(@max,@userName,@password);";
            SqlCommand cmd = new SqlCommand(insertQuery, connection.GetClient());
            cmd.Parameters.AddWithValue("@max", max);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            connection.SqlCloseConnection();
        }

        public bool UserExist(string userName)
        {
            List<User> userList = new List<User>();
            DataBaseConnection connection = new DataBaseConnection();
            connection.SqlOpenConnection();

            string query = "SELECT Count(nombre_usuario) from usuarios where nombre_usuario = @userName;";
            SqlCommand cmd = new SqlCommand(query, connection.GetClient());
            cmd.Parameters.AddWithValue("@userName",userName);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int amount = reader.GetInt32(0);
                if (amount > 0) {
                    return true;
                }
            }
            connection.SqlCloseConnection();
            return false;
        }

        public int MaxId()
        {
            DataBaseConnection connection = new DataBaseConnection();
            connection.SqlOpenConnection();
            string maxQuery = "select MAX(id_usuario + 1) from usuarios;";
            SqlCommand cmd = new SqlCommand(maxQuery, connection.GetClient());
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {

                return reader1.GetInt32(0);

            }
            return 0;
        }
    }
}
