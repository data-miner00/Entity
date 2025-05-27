namespace Entity.Raw.SqlClient;

using System;
using System.Data;
using Microsoft.Data.SqlClient;

/// <summary>
/// Examples for using SqlClient.
/// </summary>
public static class Examples
{
    /// <summary>
    /// The example to execute SQL query from code.
    /// </summary>
    /// <param name="connection">The opened connection to the database.</param>
    public static void UseRawQuery(SqlConnection connection)
    {
        var sql = "SELECT * FROM dbo.Products;";

        var command = new SqlCommand(sql, connection);

        var dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            Console.WriteLine(" - " + dataReader.GetValue(1)); // Get the value of second column
        }
    }

    /// <summary>
    /// Examples of an in-memory database (dataset).
    /// </summary>
    public static void DataSetStuffs()
    {
        // Creating a dataset
        var dataSet = new DataSet("dataSet");

        // Creating a table
        var productsTable = new DataTable("Products");

        // Creating columns
        var id = new DataColumn("Id", typeof(long));
        var name = new DataColumn("Name");
        var price = new DataColumn("Price", typeof(decimal));

        productsTable.Columns.Add(id);
        productsTable.Columns.Add(name);
        productsTable.Columns.Add(price);

        // Create rows
        var row = productsTable.NewRow();

        row[0] = 1;
        row["Name"] = "Massage gun";
        row["Price"] = 123.45m;

        productsTable.Rows.Add(row);

        dataSet.Tables.Add(productsTable);

        // Modify a row
        productsTable.Rows[0]["Price"] = 999.99m;
    }

    /// <summary>
    /// Examples of populating an in-memory dataset from data in SqlServer.
    /// </summary>
    /// <param name="connection">The opened connection.</param>
    public static void SqlDataAdapterStuffs(SqlConnection connection)
    {
        var adapter = new SqlDataAdapter();

        adapter.TableMappings.Add("RandomColumn", "Products");

        var command = new SqlCommand("SELECT Name FROM dbo.Products;", connection);
        command.CommandType = CommandType.Text;

        // Set SelectCommand to predefined command
        adapter.SelectCommand = command;

        // Fill the DataSet
        var dataSet = new DataSet("Products");
        adapter.Fill(dataSet);
    }

    private static void PrintTableRows(DataTable table)
    {
        for (var i = 0; i < table.Rows.Count; i++)
        {
            Console.WriteLine("ID" + table.Rows[i]["Id"]);
            Console.WriteLine("Name" + table.Rows[i]["Name"]);
            Console.WriteLine("Price" + table.Rows[i]["Price"]);
        }
    }

    private static void PrintTableColumns(DataSet dataSet)
    {
        foreach (DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName);
            foreach (DataColumn column in table.Columns)
            {
                Console.WriteLine(column.ColumnName + ", ");
            }
        }
    }
}
