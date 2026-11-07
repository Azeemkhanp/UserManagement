using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using UserManagement.Interface;


namespace UserManagement.Services
{
    public class DbService : IDbService
    {
        private readonly string _connectionString;

        public DbService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<T>(sql, parameters, commandType: commandType);
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters, commandType: commandType);
        }

        public async Task<int> ExecuteAsync(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(sql, parameters, commandType: commandType);
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<T>(sql, parameters, commandType: commandType);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object? parameters = null, CommandType commandType = CommandType.Text)
        {
            // Note: The connection must stay open while reading multiple results.
            var connection = CreateConnection();
            return await connection.QueryMultipleAsync(sql, parameters, commandType: commandType);
        }
    }
}
