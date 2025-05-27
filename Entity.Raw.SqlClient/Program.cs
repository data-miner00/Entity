using Entity.Common;
using Microsoft.Data.SqlClient;
using static Entity.Raw.SqlClient.Examples;

using var connection = new SqlConnection(Constants.MSSQLConnectionString);

try
{
    connection.Open();
    Console.WriteLine(connection.State);
    Console.WriteLine(connection.DataSource);
    Console.WriteLine(connection.Database);
    Console.WriteLine(connection.ServerVersion);
    Console.WriteLine(connection.WorkstationId);
    Console.WriteLine(connection.ConnectionTimeout);
    Console.WriteLine(connection.PacketSize);
}
catch (SqlException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
