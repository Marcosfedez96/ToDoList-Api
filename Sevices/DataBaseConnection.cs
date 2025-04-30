using Microsoft.Data.SqlClient;

namespace ToDoListApi.Sevices;

public class DataBaseConnection
{
    public static string route = "Data Source=DESKTOP-6A61RJD;Initial Catalog=ToDoAppDB;Integrated Security=True;Trust Server Certificate=True";
    public SqlConnection client = new SqlConnection(route);

    public SqlConnection GetClient()
    {
        return client;
    }

    public void SqlOpenConnection()
    {
        if (client.State == System.Data.ConnectionState.Closed)
        {
            client.Open();
        }
    }

    public void SqlCloseConnection()
    {
        if (client.State == System.Data.ConnectionState.Closed)
        {
            client.Close();
        }

    }


}
