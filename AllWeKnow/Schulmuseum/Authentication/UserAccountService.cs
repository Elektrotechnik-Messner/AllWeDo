using Schulmuseum.Models;
using DatabaseLibrary;
namespace Schulmuseum.Authentication;

public class UserAccountService
{
    private List<UserAccount> _users;
    private List<UserModel>? _dbUsers;
    private DataAccess _data;
    private bool _loadedFromdb = false;

    public UserAccountService ()
    {
        _dbUsers = new List<UserModel>();
        _users = new List<UserAccount> {};
        _data = new DataAccess();
        _ = GetUsers();
    }
    private async Task GetUsers()
    {
        _dbUsers = await _data.LoadData<UserModel, dynamic>("SELECT * FROM users ORDER BY id DESC", new { },"Server=root02.oc.host.endelon.link;Port=3306;database=mainblogdb; user id=mainblogdb;password=i6u0rlxn9gg7we4");
        foreach (var user in _dbUsers)
        {
            if (user.Username is not null && user.Password is not null && user.Rights is not null && user.Fullname is not null)
            {
                _users.Add(new UserAccount{Username = user.Username, Password = user.Password, Role = user.Rights, Fullname = user.Fullname, Id = user.Id});
            }
        }
        _loadedFromdb = true;
    }
    public UserAccount? GetByUserName(string userName)
    {
        return _users.FirstOrDefault(x => x.Username == userName);
    }
    public bool GotData()
    {
        return _loadedFromdb;
    }
}