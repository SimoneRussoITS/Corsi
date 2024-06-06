using System.Data;

namespace FirstApp.Models.Services.Infrastructure;

public interface IDatabaseAccessor
{
    DataSet Query(string query);
}