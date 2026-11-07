using System.Reflection.Metadata.Ecma335;
using UserManagement.CommanFiles.KalishaGroup;
using UserManagement.DTOs.KalishaGroupDTOs.RequestDtos;
using UserManagement.Interface;
using UserManagement.Interface.KalishaGroup;
using UserManagement.Models.KalishaGroup.RequestModel;
namespace UserManagement.Services.KalishaGroup
{
    public class UserRepo : IUser
    {
        private readonly IDbService _Db;    

        public UserRepo(IDbService DbService)
        {
            _Db = DbService;
        }

        // ---------------- CREATE ----------------
        public async Task<RegisterUserDTOs> CreateUser(RegisterUserDTOs model)
        {
            RegisterUserDTOs response = new RegisterUserDTOs();
            try
            {
                const string sql = @"
                    INSERT INTO Users (Username, Email, Phone, RoleId, PasswordHash, IsActive, CreatedDate)
                    VALUES (@Username, @Email, @Phone, @RoleId, @PasswordHash, @IsActive, GETDATE());
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var newId = await _Db.ExecuteScalarAsync<int>(sql, new
                {
                    model.Username,
                    model.Email,
                    model.Phone,
                    model.RoleId,
                    model.PasswordHash,
                    IsActive = true
                });

                response.UserId = newId;
                response.Username = model.Username;
                response.Email = model.Email;
                response.Phone = model.Phone;
                response.RoleId = model.RoleId;
                response.Success = Convert.ToInt32(newId) > 0;
                response.Message = newId > 0 ? "User created successfully." : "Failed to create user.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        // ---------------- GET (generic) ----------------
        public async Task<LoginResponseDTOs> Login(LoginDto model)
        {
            LoginResponseDTOs resModel = new LoginResponseDTOs();

            try
            {
                if (model == null || string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Password))
                {
                    resModel.Success = false;
                    resModel.Message = "Username and password are required.";
                    return resModel;
                }

                const string sql = @"
            SELECT UserId, UserName, Email, Phone, RoleId, IsActive
              FROM Users
             WHERE UserName = @UserName AND Password = @Password;";

                var user = await _Db.QueryFirstOrDefaultAsync<LoginResponseDTOs>(
                    sql,
                    new { model.UserName, model.Password });

                if (user == null)
                {
                    resModel.Success = false;
                    resModel.Message = "Invalid username or password.";
                    return resModel;
                }
                // 5. Success — return the actual user data
                user.Success = true;
                user.Message = "User logged in successfully.";
                return user;
            }
            catch (Exception ex)
            {
                // Log the exception here (e.g. _logger.LogError(ex, "Login failed"))
                resModel.Success = false;
                resModel.Message = "An error occurred while logging in. Please try again later.";
                // Optionally include ex.Message only in Development environment
                return resModel;
            }
        }

        // ---------------- UPDATE ----------------
        public async Task<BaseModel> UpdateUser(UpdateUserDTOs model)
        {
            var response = new BaseModel();
            try
            {
                const string sql = @"
                    UPDATE Users
                       SET Username     = @Username,
                           Email        = @Email,
                           Phone        = @Phone,
                           RoleId       = @RoleId,
                           IsActive     = @IsActive,
                           UpdatedDate  = GETDATE()
                     WHERE UserId = @UserId;";

                var rows = await _Db.ExecuteAsync(sql, new
                {
                    model.UserId,
                    model.Username,
                    model.Email,
                    model.Phone,
                    model.RoleId,
                    model.IsActive
                });

                response.UserId = model.UserId;
                response.Success = rows > 0;
                response.Message = rows > 0 ? "User updated successfully." : "User not found.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        // ---------------- DELETE (soft delete) ----------------
        public async Task<BaseModel> DeleteUser(User model)
        {
            var response = new UpdateUserDTOs();
            try
            {
                const string sql = @"
                    UPDATE Users
                       SET IsActive    = 0,
                           UpdatedDate = GETDATE()
                     WHERE UserId = @UserId;";

                var rows = await _Db.ExecuteAsync(sql, new { model.UserId });

                response.UserId = Convert.ToInt32(model.UserId);
                response.Success = rows > 0;
                response.Message = rows > 0 ? "User deactivated." : "User not found.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        // ---------------- GET ALL ----------------
        public async Task<List<GetUserDtoBasedOnLogin>> GetAllUser(UserDtoBasedOnLoginRequest model)
        {
            const string sql = @"
        SELECT UserId, Username, Email, Phone, RoleId, IsActive
          FROM Users
         ORDER BY UserId;";

            var users = await _Db.QueryAsync<GetUserDtoBasedOnLogin>(sql);
            return users.ToList();
        }

        // ---------------- GET BY ID ----------------
        public async Task<GetUserDtoBasedOnLogin> GetUserById(UserDtoBasedOnLoginRequest model)
        {
            const string sql = @"
                SELECT UserId, Username, Email, Phone, RoleId, IsActive
                  FROM Users
                 WHERE UserId = @UserId;";

            var user = await _Db.QueryFirstOrDefaultAsync<GetUserDtoBasedOnLogin>(sql, new { model.UserId });

            if (user == null)
                return new GetUserDtoBasedOnLogin { Success = false, Message = "User not found."};
            return user;
        }

        // ---------------- GET BY EMAIL ----------------
        public async Task<GetUserDtoBasedOnLogin> GetUserByEmail(UserDtoBasedOnLoginRequest model)
        {
            const string sql = @"
                SELECT UserId, Username, Email, Phone, RoleId, IsActive
                  FROM Users
                 WHERE Email = @Email;";

            var user = await _Db.QueryFirstOrDefaultAsync<GetUserDtoBasedOnLogin>(sql, new { model.Email });

            if (user == null)
                return new GetUserDtoBasedOnLogin { Success = false, Message = "User not found." };

            user.Success = true;
            user.Message = "User found.";
            return user;
        }

        // ---------------- GET BY PHONE ----------------
        public async Task<GetUserDtoBasedOnLogin> GetUserByPhone(UserDtoBasedOnLoginRequest model)
        {
            const string sql = @"
                SELECT UserId, Username, Email, Phone, RoleId, IsActive
                  FROM Users
                 WHERE Phone = @Phone;";

            var user = await _Db.QueryFirstOrDefaultAsync<GetUserDtoBasedOnLogin>(sql, new { model.PhoneNo });

            if (user == null)
                return new GetUserDtoBasedOnLogin { Success = false, Message = "User not found." };

            user.Success = true;
            user.Message = "User found.";
            return user;
        }

        // ---------------- GET BY USERNAME----------------
        public async Task<GetUserDtoBasedOnLogin> GetUserByUsername(UserDtoBasedOnLoginRequest model)
        {
            const string sql = @"
                SELECT UserId, Username, Email, Phone, RoleId, IsActive
                  FROM Users
                 WHERE Username = @Username;";

            var user = await _Db.QueryFirstOrDefaultAsync<GetUserDtoBasedOnLogin>(sql, new { model.UserName });

            if (user == null)
                return new GetUserDtoBasedOnLogin { Success = false, Message = "User not found." };

            user.Success = true;
            user.Message = "User found.";
            return user;
        }

        // ---------------- GET BY ROLE ----------------
        // UserRepo.cs
        public async Task<List<GetUserDtoBasedOnLogin>> GetUserByRole(UserDtoBasedOnLoginRequest model)
        {
            const string sql = @"
        SELECT UserId, Username, Email, Phone, RoleId, IsActive
          FROM Users
         WHERE RoleId = @RoleId;";

            var users = await _Db.QueryAsync<GetUserDtoBasedOnLogin>(sql, new { model.RoleId });
            return users.ToList();
        }


        public async Task<int> LogoutUser(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
                return 0;

            const string sql = @"
        UPDATE RefreshTokens
           SET IsRevoked   = 1,
               RevokedDate = GETDATE()
         WHERE Token       = @RefreshToken
           AND IsRevoked   = 0;";

            var rows = await _Db.ExecuteAsync(sql, new { RefreshToken = refreshToken });
            return rows;   // 1 = revoked, 0 = token not found or already revoked
        }

        public Task<BaseModel> ChangePassword(UpdatePasswordRequestDto userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<BaseModel> ForgotPassword(ForgotPasswordRequestDto userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<BaseModel> ResetPassword(ResetPasswordRequestDto userRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}