namespace ToDoListApi.Models;

public class ToDoItem
{
    private int _idTask;
    private string _nameTask;
    private string _importance;
    private DateTime _date;
    private string _category;
    private bool _done;
    private GetUser _userdata;

    public int IdTask {  get { return _idTask; } set { _idTask = value; } }
    public string NameTask { get { return _nameTask; } set { _nameTask = value; } }
    public string Importance { get { return _importance; } set { _importance = value; } }
    public DateTime Date { get { return _date; } set { _date = value; } }
    public string Category { get { return _category; } set { _category = value; } }
    public bool Done { get { return _done; } set { _done = value; } }
    public GetUser UserData { get { return _userdata; } set { _userdata = value; } }


}
