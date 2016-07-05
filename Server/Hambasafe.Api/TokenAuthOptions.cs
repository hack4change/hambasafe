using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace Hambasafe.Api
{
    public class TokenAuthOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
