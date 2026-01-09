using Npgsql;
namespace WebApiTask.Data;
public class ApplicationDbContext
{
   
      private readonly string _connectionString="Host=localhost;Port=5432;Database=newfileTask;Username=postgres;Password=1234";
     public NpgsqlConnection Connection()=> new NpgsqlConnection(_connectionString);
    
}
