using Microsoft.EntityFrameworkCore;
using Schulmuseum.Data;
using Schulmuseum.Models;

namespace Schulmuseum.Services;

public class UserService
{
    private IDbContextFactory<Database> _dbContextFactory;

    public UserService(IDbContextFactory<Database> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public void AddUser(UserModel user)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            context.Users.Add(user);
        }
    }
}