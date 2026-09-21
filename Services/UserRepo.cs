using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;
using UserManagement.DBManagementFiles;
using UserManagement.Interface;
using UserManagement.Models.RequestModel;
using UserManagement.Models.ResponseModel;

namespace UserManagement.Services
{
    public class UserRepo : IUser
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserResponseModel> CreateUser(UserRequestModel userRequestModel)
        {
            var response = new UserResponseModel();

            // 1. Hash the password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequestModel.Password);

            // 2. Get the underlying DbConnection from EF Core
            var connection = _context.Database.GetDbConnection();

            // 3. Open connection only if not already open (EF may have it open in a transaction)
            var wasClosed = connection.State == ConnectionState.Closed;
            if (wasClosed)
                await connection.OpenAsync();

            try
            {
                // 4. Create command for the stored procedure
                await using var command = connection.CreateCommand();
                command.CommandText = "dbo.sp_CreateUser";
                command.CommandType = CommandType.StoredProcedure;

                // 5. Add INPUT parameters
                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = userRequestModel.UserName });
                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 150) { Value = userRequestModel.Email });
                command.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 255) { Value = passwordHash });
                command.Parameters.Add(new SqlParameter("@Role", SqlDbType.NVarChar, 50) { Value = userRequestModel.Role });

                // 6. Add OUTPUT parameters
                var userIdParam = new SqlParameter("@UserId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 255)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(userIdParam);
                command.Parameters.Add(messageParam);

                // 7. Execute the stored procedure
                await command.ExecuteNonQueryAsync();

                // 8. Read OUTPUT values back
                response.UserModel.Response = userIdParam.Value == DBNull.Value ? 0 : Convert.ToInt32(userIdParam.Value);
                response.UserModel.Message = messageParam.Value?.ToString() ?? string.Empty;
            }
            finally
            {
                // 9. Only close if WE opened it — don't close EF's connection
                if (wasClosed)
                    await connection.CloseAsync();
            }

            return response;
        }

        public Task<UserResponseModel> GetUser(UserRequestModel userRequestModel)
        {
            var response = new UserResponseModel
            {
                UserModel = new UserRequestModel
                {
                    UserName = "azeemkhan",
                    Email = "azeemkhan@gmail.com",
                    FirstName = "Azeem",
                    LastName = "Khan",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St, City, Country"
                }
            };


            return Task.FromResult(response);
        }

        public async  Task<UserResponseModel> UpdateUser(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> DeleteUser(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetAllUser(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserById(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserByEmail(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserByPhone(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserByUsername(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserByRole(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}
