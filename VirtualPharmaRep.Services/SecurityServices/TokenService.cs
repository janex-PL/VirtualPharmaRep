using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Services.SecurityServices
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public TokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task<TokenResponseViewModel> GetToken(TokenRequestViewModel request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null && request.UserName.Contains("@"))
                user = await _userManager.FindByEmailAsync(request.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return null;

            var refreshToken = CreateRefreshToken(request.ClientId, user.Id);

            await _context.Set<Token>().AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            var response = CreateAccessToken(user.Id, refreshToken.Value);

            return response;
        }

        public async Task<TokenResponseViewModel> RefreshToken(TokenRequestViewModel request)
        {
            var refreshToken = await _context.Set<Token>().FirstOrDefaultAsync( t=> t.ClientId == request.ClientId);

            if (refreshToken == null)
                return null;

            var user = await _userManager.FindByIdAsync(refreshToken.UserId);

            if (user == null)
                return null;

            var newToken = CreateRefreshToken(refreshToken.ClientId, refreshToken.UserId);

            _context.Set<Token>().Remove(refreshToken);
            await _context.Set<Token>().AddAsync(newToken);
            await _context.SaveChangesAsync();

            var response = CreateAccessToken(newToken.UserId, newToken.Value);

            return response;
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
                _configuration["Auth:Jwt:Issuer"],
                _configuration["Auth:Jwt:Audience"],
                claims,
                currentTime,
                currentTime.Add(TimeSpan.FromMinutes(tokenExpirationMinutes)),
                new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenResponseViewModel
            {
                Token = encodedToken,
                Expiration = tokenExpirationMinutes,
                RefreshToken = refreshToken
            };
        }
        private static Token CreateRefreshToken(string clientId, string userId)
        {
            return new Token
            {
                ClientId = clientId,
                UserId = userId,
                Type = 0,
                Value = Guid.NewGuid().ToString("N")
            };
        }
    }
}