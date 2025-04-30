namespace ToDoListApi.Models;

public class Task
{
    private int _idTask;
    private string _nameTask;
    private string _importance;
    private DateTime _date;
    private string _description;
    private bool _done;
    private User _user;

    public int IdTask {  get { return _idTask; } set { _idTask = value; } }
    public string NameTask { get { return _nameTask; } set { _nameTask = value; } }
    public string Importance { get { return _importance; } set { _importance = value; } }
    public DateTime Date { get { return _date; } set { _date = value; } }
    public string Description { get { return _description; } set { _description = value; } }
    public bool Done { get { return _done; } set { _done = value; } }
    public int IdUser { get { return _user.IdUser; } set { _user.IdUser = value; } }


}
