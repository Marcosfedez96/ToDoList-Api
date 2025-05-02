using Microsoft.Data.SqlClient;
using ToDoListApi.DTOs;
using ToDoListApi.Models;

namespace ToDoListApi.Repositories;

public class ToDoItemRepository : IToDoItemRepository
{
    public readonly SqlConnection _connection;
    public readonly DataBaseConnection _dataBaseConnection;

    public ToDoItemRepository(SqlConnection connection, DataBaseConnection dataBaseConnection   )
    {
        _connection = connection;
        _dataBaseConnection = dataBaseConnection;
    }

    public List<ToDoItem> GetToDoItemlist()
    {
        var list = new List<ToDoItem>();
        DataBaseConnection dataBaseConnection = new();
        dataBaseConnection.SqlOpenConnection();
        string query = "select * from tareas;";
        SqlCommand cmd = new SqlCommand(query, dataBaseConnection.GetClient());
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new ToDoItem()
            {
                IdTask = reader.GetInt32(0),
                NameTask = reader.GetString(1),
                Importance = reader.GetString(2),
                Date = reader.GetDateTime(3),
                Category = reader.GetString(4),
                Done = reader.GetBoolean(5),
                // User= user
            }
           );
        }
        return list;
    }

    public List<ToDoItem> GetToDoUserItem(int idUser)
    {
        var list = new List<ToDoItem>();
        DataBaseConnection dataBaseConnection = new();
        dataBaseConnection.SqlOpenConnection();
        UserDTO user = SearchUser(idUser);
        string query = "select tareas.*  from tareas where id_usuario = @IdUser;";
        SqlCommand cmd = new SqlCommand(query, dataBaseConnection.GetClient());
        cmd.Parameters.AddWithValue("@IdUser", idUser);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            list.Add(new ToDoItem()
            {
                IdTask = reader.GetInt32(0),
                NameTask = reader.GetString(1),
                Importance = reader.GetString(2),
                Date = reader.GetDateTime(3),
                Category = reader.GetString(4),
                Done = reader.GetBoolean(5),
                UserData = user
            });



        }
        ;
        return list;
    }

    public ToDoItem GetToDoItem(int idUser, int idTask)
    {
        _dataBaseConnection.SqlOpenConnection();
        UserDTO user = SearchUser(idUser);
        ToDoItem? toDo = null;
        string query = "select *  from tareas where id_tarea = @idTask;";
        SqlCommand cmd = new SqlCommand(query, _dataBaseConnection.GetClient());
        cmd.Parameters.AddWithValue("@idTask", idTask);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            toDo = new ToDoItem()
            {
                IdTask = reader.GetInt32(0),
                NameTask = reader.GetString(1),
                Importance = reader.GetString(2),
                Date = reader.GetDateTime(3),
                Category = reader.GetString(4),
                Done = reader.GetBoolean(5),
                UserData = user
            };
           
        }
        reader.Close();
        return toDo;
    }

    public void createToDoItem(ToDoItem item)
    {
        
        _dataBaseConnection.SqlOpenConnection();
        item.IdTask = MaxId();
        string query = "insert into tareas (id_tarea, nombre_tarea, importancia, fecha ,categoria,hecho,id_usuario) " +
            "values(@id_task, @name_task, @importance, @date ,@category,@done,@id_user);";
        SqlCommand cmd = new SqlCommand(@query, _dataBaseConnection.GetClient());
        cmd.Parameters.AddWithValue("@id_task", item.IdTask);
        cmd.Parameters.AddWithValue("@name_task", item.NameTask);
        cmd.Parameters.AddWithValue("@importance", item.Importance);
        cmd.Parameters.AddWithValue("@date", item.Date);
        cmd.Parameters.AddWithValue("@category", item.Category);
        cmd.Parameters.AddWithValue("@done", item.Done);
        cmd.Parameters.AddWithValue("@id_user", item.UserData.IdUser);
        cmd.ExecuteNonQuery();
        _dataBaseConnection.SqlCloseConnection();
       
    }

    public UserDTO SearchUser(int IdUser)
    {
        DataBaseConnection dataBaseConnection = new();
        dataBaseConnection.SqlOpenConnection();

        string query = "Select * from usuarios where id_usuario = @IdUser";
        SqlCommand cmd = new SqlCommand(query, dataBaseConnection.GetClient());
        cmd.Parameters.AddWithValue("@IdUser", IdUser);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var getUser = new UserDTO()
            {
                IdUser = reader.GetInt32(0),
                UserName = reader.GetString(1)
            };
            return getUser;
        }
    ;
        return null;
    }

    private int MaxId()
    {
        _dataBaseConnection.SqlOpenConnection();
        int max = 1;
        string query = "select MAX(id_tarea + 1) from tareas;";
        SqlCommand cmd = new SqlCommand (query, _dataBaseConnection.GetClient());
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            max =  reader.GetInt32(0);
        }
        reader.Close();
        return max;
    }
}
