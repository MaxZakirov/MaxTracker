using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MaxTracker.Authentication.Models;
using Microsoft.IdentityModel.Tokens;

namespace MaxTracker.Authentication.Helpers
{
	public static class TokenHelper
	{
		public static void CreateToken(this UserAuthenticationInfoViewModel loginInfo, string secretKey)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);
			var tokenDescription = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, loginInfo.Email),
					new Claim(ClaimTypes.Email, loginInfo.Name),
					new Claim(ClaimTypes.Role, loginInfo.Role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescription);

			loginInfo.Token = tokenHandler.WriteToken(token);
		}
	}
}
