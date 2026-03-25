using System;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

public class JwtValidator
{
    private static string secretKey = "Media_Sys_Super_Secure_Key_Size_256";

    public static ClaimsPrincipal ValidateToken(string token)
    {
        var handler = new JsonWebTokenHandler();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var parameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "TaskApplication",

            ValidateAudience = true,
            ValidAudience = "TaskApplication",

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key
        };

        var result = handler.ValidateToken(token, parameters);

        if (!result.IsValid)
        {
            throw new Exception("Invalid Token");
        }

        return result.ClaimsIdentity != null
            ? new ClaimsPrincipal(result.ClaimsIdentity)
            : null;
    }
}