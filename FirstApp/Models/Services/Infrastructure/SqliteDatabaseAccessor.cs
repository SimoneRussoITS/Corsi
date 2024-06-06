using System.Data;
using FirstApp.Models.Enums;
using FirstApp.Models.ValueTypes;
using Microsoft.Data.Sqlite;

namespace FirstApp.Models.Services.Infrastructure;

public class SqliteDatabaseAccessor : IDatabaseAccessor
{
    public DataSet Query(string query)
    {
        using var conn = new SqliteConnection("Data Source=Data/FirstApp.db");
        conn.Open();
        var cmd = new SqliteCommand(query, conn);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Int64 id = (Int64) reader["Id"];
            string title = (string) reader["Title"];
            string description = (string) reader["Description"];
            string author = (string) reader["Author"];
            string email = (string) reader["Email"];
            decimal price;
            if (reader["Price"] is Int64)
            {
                price = (decimal)(Int64)reader["Price"];
            }
            else
            {
                price = (decimal)(double)reader["Price"];
            }
            Currency currency = Currency.EUR; // Default value
            if (reader.GetSchemaTable().Columns.Contains("Currency"))
            {
                currency = (Currency)reader["Currency"];
            }
            Money priceValue = new Money(price, currency);
        }
        return new DataSet();
    }
}