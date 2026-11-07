using Dapper;
using System.Data;

namespace UserManagement.Interface
{
    public interface IDbService
    {
        // For fetching lists
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text);

        // For fetching a single record (returns null if not found)
        Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text);

        // For INSERT/UPDATE/DELETE (returns rows affected)
        Task<int> ExecuteAsync(string sql, object? parameters = null, CommandType commandType = CommandType.Text);

        // For INSERT when you need the new ID back
        Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text);

        // For handling multiple result sets (like your Oracle RefCursor)
        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object? parameters = null, CommandType commandType = CommandType.Text);
    }
}
