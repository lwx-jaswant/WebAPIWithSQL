using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace WebAPIWithSQL.Helper
{
    public class TokenHelper
    {
        public const string Issuer = "https://localhost:7250";
        public const string Audience = "https://localhost:7250";
        public const string Secret = "p0GXO6VuVZLRPef0tyO9jCqK4uZufDa6LP4n8Gj+8hQPB30f94pFiECAnPeMi5N6VT3/uscoGH7+zJrv4AuuPg==";
        public static async Task<string> GenerateAccessToken(int userId)
        {
            try
            {
                var key = Convert.FromBase64String(Secret.Replace('-', '+').Replace('_', '/'));

                var tokenHandler = new JwtSecurityTokenHandler();


                var claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            });

                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claimsIdentity,
                    Issuer = Issuer,
                    Audience = Audience,
                    Expires = DateTime.Now.AddMinutes(15),
                    SigningCredentials = signingCredentials,

                };
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);

                return await System.Threading.Tasks.Task.Run(() => tokenHandler.WriteToken(securityToken));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return null;
        }
        public static async Task<string> GenerateRefreshToken()
        {
            var secureRandomBytes = new byte[32];

            using var randomNumberGenerator = RandomNumberGenerator.Create();
            await System.Threading.Tasks.Task.Run(() => randomNumberGenerator.GetBytes(secureRandomBytes));

            var refreshToken = Convert.ToBase64String(secureRandomBytes);
            return refreshToken;
        }
    }
}