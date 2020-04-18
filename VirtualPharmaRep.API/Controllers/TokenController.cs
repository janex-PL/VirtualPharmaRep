using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels.Tokens;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.API.Controllers
{
	[Route("api/[controller]"), ApiController]
	public class TokenController : ControllerBase
	{
		private readonly JsonSerializerOptions _serializer;

		private readonly UserManager<ApplicationUser> _userManager;

		private readonly IConfiguration _configuration;

		private readonly ApplicationDbContext _context;

		public TokenController(UserManager<ApplicationUser> userManager, IConfiguration configuration,
			ApplicationDbContext context)
		{
			_userManager = userManager;
			_configuration = configuration;
			_context = context;
			_serializer = new JsonSerializerOptions()
			{
				WriteIndented = true
			};
		}

		[HttpPost("Auth")]
		public async Task<IActionResult> Auth([FromBody] TokenRequestViewModel model)
		{
			if(model == null)
				return BadRequest();

			return model.GrantType switch
			{
				"password" => await GetToken(model),
				"refresh_token" => await RefreshToken(model),
				_ => BadRequest()
			};
		}

		private async Task<IActionResult> RefreshToken(TokenRequestViewModel model)
		{
			try
			{
				var refreshToken = _context.Tokens
					.FirstOrDefault(t => t.ClientId == model.ClientId && t.Value == model.RefreshToken);

				if (refreshToken == null)
					return Unauthorized();

				var user = await _userManager.FindByIdAsync(refreshToken.UserId);

				if (user == null)
					return Unauthorized();

				var newToken = CreateRefreshToken(refreshToken.ClientId, refreshToken.UserId);

				_context.Tokens.Remove(refreshToken);
				await _context.Tokens.AddAsync(newToken);
				await _context.SaveChangesAsync();

				var response = CreateAccessToken(newToken.UserId, newToken.Value);

				return new JsonResult(response,_serializer);
			}
			catch (Exception)
			{
				return Unauthorized();
			}
		}

		private TokenResponseViewModel CreateAccessToken(string userId, string refreshToken)
		{
			var currentTime = DateTime.UtcNow;

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, userId),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Iat,
					new DateTimeOffset(currentTime).ToUnixTimeSeconds().ToString())
            };

			var tokenExpirationMinutes = _configuration.GetValue<int>("Auth:Jwt:TokenExpirationInMinutes");
			var issuerSigningKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_configuration["Auth:Jwt:Key"]));

			var token = new JwtSecurityToken(
				issuer: _configuration["Auth:Jwt:Issuer"],
				audience: _configuration["Auth:Jwt:Audience"],
				claims: claims,
				notBefore: currentTime,
				expires: currentTime.Add(TimeSpan.FromMinutes(tokenExpirationMinutes)),
				signingCredentials: new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256)
			);

			var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

			return new TokenResponseViewModel()
			{
				Token = encodedToken,
				Expiration = tokenExpirationMinutes,
				RefreshToken = refreshToken
			};
		}

		private static Token CreateRefreshToken(string clientId, string userId) =>
			new Token()
			{
				ClientId = clientId,
				UserId = userId,
				Type = 0,
				Value = Guid.NewGuid().ToString("N"),
				CreatedDateTime = DateTime.UtcNow
			};

		private async Task<IActionResult> GetToken(TokenRequestViewModel model)
		{
			try
			{
				var user = await _userManager.FindByNameAsync(model.UserName);

				if (user == null && model.UserName.Contains("@"))
					user = await _userManager.FindByEmailAsync(model.UserName);

				if(user == null || !await _userManager.CheckPasswordAsync(user,model.Password))
					return Unauthorized();

				var refreshToken = CreateRefreshToken(model.ClientId, user.Id);

				await _context.Tokens.AddAsync(refreshToken);
				await _context.SaveChangesAsync();

				var response = CreateAccessToken(user.Id, refreshToken.Value);

				return new JsonResult(response,_serializer);
			}
			catch (Exception)
			{
				return Unauthorized();
			}
		}

		
	}
}