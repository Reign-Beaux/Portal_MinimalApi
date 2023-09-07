using System.Data;
using System.Data.SqlClient;

namespace Portal_MinimalApi.Data
{
  public class Connection
  {
    private readonly string connectionString;
    private readonly SqlConnection connection;

    public Connection(IConfiguration configuration)
    {
      connectionString = configuration["ConnectionStrings:DefaultConnection"]!;
      connection = new SqlConnection(connectionString);
    }

    public async Task<DataTable> ExecuteQuery(string storedProcedure, List<SqlParameter> parameters)
    {
      try
      {
        DataTable dataTable = new DataTable();
        connection.Open();
        SqlCommand command = new SqlCommand(storedProcedure, connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddRange(parameters.ToArray());
        using (SqlDataAdapter dataAdapter = new(command))
        {
          await Task.Run(() => dataAdapter.Fill(dataTable));
        }
        return dataTable;
      }
      catch (Exception ex)
      {
        connection.Close();
        throw new Exception("Error: " + ex.Message);
      }
      finally
      {
        connection.Close();
      }
    }
  }
}
