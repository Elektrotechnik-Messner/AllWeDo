using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace DatabaseLibrary;

// Public class because it needs to be accessed from other files
public class DataAccess
{
    // Get Data from the database
    // Asynchronous method
    public async Task<List<T>> LoadData<T, TU>(string sql, TU parameters, string connectionString)
    {
        // Create the connection 
        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            // Get the row data form the database, put it in a list and return it
            var rows = await connection.QueryAsync<T>(sql, parameters);
            // Using await because list can only converted when the database has answered
            return rows.ToList();
        }
    }
    
    // Save data T to the database
    public Task SaveData<T>(string sql, T parameters, string connectionString)
    {
        // Create the connection
        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            // Store the data
            // ReSharper disable once ReturnOfTaskProducedByUsingVariable
            return connection.ExecuteAsync(sql, parameters);
        }
    }
}