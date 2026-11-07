using UserManagement.Interface;
using UserManagement.Interface.KalishaGroup;
using UserManagement.Models.KalishaGroup.RequestModel;
using UserManagement.Models.KalishaGroup.ResponseModel;

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
        public async Task<UserResponseModel> CreateUser(UserRequestModel model)
        {
            var response = new UserResponseModel();
            try
            {
                const string sql = @"
                    INSERT INTO Users (Username, Email, Phone, RoleId, PasswordHash, IsActive, CreatedDate)
                    VALUES (@Username, @Email, @Phone, @RoleId, @PasswordHash, @IsActive, GETDATE());
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var newId = await _Db.ExecuteScalarAsync<int>(sql, new
                {
                    model.UserName,
                    model.Email,
                    model.PhoneNumber,
                    model.UserRoleId,
                    model.Password,
                    IsActive = true
                });

                response.UserId = newId;
                response.UserModel.UserName = model.UserName;
                response.UserModel.Email = model.Email;
                response.UserModel.PhoneNumber = model.PhoneNumber;
                response.UserModel.UserRoleId = model.UserRoleId;
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
        public async Task<UserResponseModel> GetUser(UserRequestModel model)
        {
            // Example: treat this as "get by UserId if provided, otherwise by Username".
            if (model.UserId > 0)
                return await GetUserById(model);
            if (!string.IsNullOrWhiteSpace(model.UserName))
                return await GetUserByUsername(model);

            return new UserResponseModel { Success = false, Message = "No lookup criteria supplied." };
        }

        // ---------------- UPDATE ----------------
        public async Task<UserResponseModel> UpdateUser(UserRequestModel model)
        {
            var response = new UserResponseModel();
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
                    model.UserName,
                    model.Email,
                    model.PhoneNumber,
                    model.UserRoleId,
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
        public async Task<UserResponseModel> DeleteUser(UserRequestModel model)
        {
            var response = new UserResponseModel();
            try
            {
                const string sql = @"
                    UPDATE Users
                       SET IsActive    = 0,
                           UpdatedDate = GETDATE()
                     WHERE UserId = @UserId;";

                var rows = await _Db.ExecuteAsync(sql, new { model.UserId });

                response.UserId = model.UserId;
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
        public async Task<UserResponseModel> GetAllUser(UserRequestModel model)
        {
            UserResponseModel response = new UserResponseModel();
            try
            {
                const string sql = @"
                    SELECT UserId, Username, Email, Phone, RoleId, IsActive
                      FROM Users
                     ORDER BY UserId;";

                var users = await _Db.QueryAsync<Models.KalishaGroup.ResponseModel.User>(sql);

                response.UserList = users.ToList();
                response.Success = true;
                response.Message = $"{response.UserList.Count} user(s) found.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        // ---------------- GET BY ID ----------------
        public async Task<UserResponseModel> GetUserById(UserRequestModel model)
        {
            const string sql = @"
                SELECT UserId, Username, Email, Phone, RoleId, IsActive
                  FROM Users
                 WHERE UserId = @UserId;";

            var user = await _Db.QueryFirstOrDefaultAsync<UserResponseModel>(sql, new { model.UserId });

            if (user == null)
                return new UserResponseModel { Success = false, Message = "User not found." };

            user.Success = true;
            user.Message = "User found.";
            return user;
        }

        // ---------------- GET BY EMAIL ----------------
        public async Task<UserResponseModel> GetUserByEmail(UserRequestModel model)
        {
            const string sql = @"
                SELECT UserId, Username, Email, Phone, RoleId, IsActive
                  FROM Users
                 WHERE Email = @Email;";

            var user = await _Db.QueryFirstOrDefaultAsync<UserResponseModel>(sql, new { model.Email });

            if (user == null)
                return new UserResponseModel { Success = false, Message = "User not found." };

            user.Success = true;
            user.Message = "User found.";
            return user;
        }

        // ---------------- GET BY PHONE ----------------
        public async Task<UserResponseModel> GetUserByPhone(UserRequestModel model)
        {
            const string sql = @"
                SELECT UserId, Username, Email, Phone, RoleId, IsActive
                  FROM Users
                 WHERE Phone = @Phone;";

            var user = await _Db.QueryFirstOrDefaultAsync<UserResponseModel>(sql, new { model.PhoneNumber });

            if (user == null)
                return new UserResponseModel { Success = false, Message = "User not found." };

            user.Success = true;
            user.Message = "User found.";
            return user;
        }

        // ---------------- GET BY USERNAME ----------------
        public async Task<UserResponseModel> GetUserByUsername(UserRequestModel model)
        {
            const string sql = @"
                SELECT UserId, Username, Email, Phone, RoleId, IsActive
                  FROM Users
                 WHERE Username = @Username;";

            var user = await _Db.QueryFirstOrDefaultAsync<UserResponseModel>(sql, new { model.UserName });

            if (user == null)
                return new UserResponseModel { Success = false, Message = "User not found." };

            user.Success = true;
            user.Message = "User found.";
            return user;
        }

        // ---------------- GET BY ROLE ----------------
        public async Task<UserResponseModel> GetUserByRole(UserRequestModel model)
        {
            var response = new UserResponseModel();
            try
            {
                const string sql = @"
                    SELECT UserId, Username, Email, Phone, RoleId, IsActive
                      FROM Users
                     WHERE RoleId = @RoleId;";

                var users = await _Db.QueryAsync<Models.KalishaGroup.ResponseModel.User>(sql, new { model.UserRoleId });

                response.UserList = users.ToList();
                response.Success = true;
                response.Message = $"{response.UserList.Count} user(s) found for role {model.UserRoleId}.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}