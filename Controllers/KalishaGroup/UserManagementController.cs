using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.CommanFiles.KalishaGroup;
using UserManagement.CQRS.KalishaGroup.Command;
using UserManagement.DTOs.KalishaGroupDTOs.RequestDtos;
using UserManagement.Models;
using UserManagement.Models.KalishaGroup.RequestModel;

namespace UserManagement.Controllers.KalishaGroup
{
    [ApiController]
    [Route("[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly ILogger<UserManagementController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        public UserManagementController(ILogger<UserManagementController> logger,IConfiguration configuration, IMediator mediator)
        {
            _logger = logger;
            _configuration = configuration;
            _mediator = mediator;
        }                     

        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin(LoginDto ReqModel)
        {
            try
            {
                LoginResponseDTOs userResponseModel = new LoginResponseDTOs();
                userResponseModel = await _mediator.Send(new UserLoginCommand { ReqModel = ReqModel });
                if (userResponseModel == null)
                {
                    return NotFound("User not found.");
                }
                else
                {
                    userResponseModel.AccessToken = await GenerateToken(userResponseModel);
                }

                return Ok(userResponseModel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpGet]
        public Task<string> GenerateToken(LoginResponseDTOs userResponseModel)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["jwt:key"]));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                 new Claim(JwtRegisteredClaimNames.Sub,_configuration["jwt:Subject"]),
                 new Claim(JwtRegisteredClaimNames.GivenName, userResponseModel.Username),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                 new Claim("UserID",userResponseModel.UserId.ToString()),
                 new Claim("UserName",userResponseModel.Username.ToString()),
                 new Claim("RoleName",userResponseModel.Role.ToString()),
                 new Claim("RoleId",userResponseModel.RoleId.ToString())
                 };

                var token = new JwtSecurityToken(
                    issuer: _configuration["jwt:issuer"],
                    audience: _configuration["jwt:audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: credentials
                );

                return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating the token.");
                throw;
            }
        }
        [HttpPost("UserRegister")]
        public async Task<IActionResult> UserRegister(RegisterUserDTOs userResponseModel)
        {
            try
            {
                var  Res = await _mediator.Send(new UserRegisterCommand { ReqModel = userResponseModel });
                return Ok(Res);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the user.");
                return StatusCode(500, "An error occurred while registering the user.");
            }
        }
        [HttpPost("UserLogout")]
        public async Task<IActionResult> UserLogout(string RefreshToken)
        {
            try
            {
                var Res = await _mediator.Send(new UserLogoutCommand { RefreshToken = RefreshToken });
                return Ok(Res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging out the user.");
                return StatusCode(500, "An error occurred while logging out the user.");
            }
        }
        [HttpPost("UserUpdateProfile")]
        public async Task<IActionResult> UserUpdateProfile(UpdateUserDTOs userResponseModel)
        {
            try
            {
                var Res = await _mediator.Send(new UserUpdateProfileCommand { ReqModel = userResponseModel });
                return Ok(Res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user profile.");
                return StatusCode(500, "An error occurred while updating the user profile.");
            }
        }
        [HttpPost("UserChangePassword")]
        public async Task<IActionResult> UserChangePassword(UpdatePasswordRequestDto userResponseModel)
        {
            try
            {
                BaseModel Res = new BaseModel();
                Res = await _mediator.Send(new UserChangePasswordCommand { ReqModel = userResponseModel });
                return Ok(Res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while changing the user password.");
                return StatusCode(500, "An error occurred while changing the user password.");
            }
        }
        [HttpPost("UserForgotPassword")]
        public async Task<IActionResult> UserForgotPassword(ForgotPasswordRequestDto userResponseModel)
        {
            try
            {
                BaseModel Res = new BaseModel();
                Res = await _mediator.Send(new UserForgotPasswordCommand { ReqModel = userResponseModel });
                return Ok(Res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the forgot password request.");
                return StatusCode(500, "An error occurred while processing the forgot password request.");
            }
        }
        [HttpPost("UserResetPassword")]
        public async Task<IActionResult> UserResetPassword(ResetPasswordRequestDto userResponseModel)
        {
            try
            {
                BaseModel Res = new BaseModel();
                Res = await _mediator.Send(new UserResetPasswordCommand { ReqModel = userResponseModel });
                return Ok(Res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while resetting the user password.");
                return StatusCode(500, "An error occurred while resetting the user password.");
            }
        }
        [HttpPost("UserDeleteAccount")]
        public async Task<IActionResult> UserDeleteAccount(User userResponseModel)
        {
            try
            {
                BaseModel Res = new BaseModel();
                Res = await _mediator.Send(new UserDeleteAccountCommand { ReqModel = userResponseModel });
                return Ok(Res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the user account.");
                return StatusCode(500, "An error occurred while deleting the user account.");
            }
        }
    }
}
