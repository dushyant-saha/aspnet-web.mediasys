using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace MediaSysTask.Models
{
    public class JwtHelper
    {
        private static string secretKey = "Media_Sys_Super_Secure_Key_Size_256";

        public static string GenerateToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new[]{new Claim(ClaimTypes.Name, username)};

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "TaskApplication",
                Audience = "TaskApplication",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };

            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(descriptor);

            return token;
        }
    }
}