namespace ToDoListApi.DTOs;

public class UserDTO 
{
    private int _idUser;
    private string _userName;
    
    public int IdUser { get { return _idUser; } set { _idUser = value; } }
    public string UserName { get { return _userName; } set { _userName = value; } }


}
