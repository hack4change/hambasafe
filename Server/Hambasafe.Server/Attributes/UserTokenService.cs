using System;
using System.Collections.Concurrent;

namespace Hambasafe.Server.Attributes
{
    public class UserTokenService
    {
        private static UserTokenService _instance = null;

        private static object _locker = new object();

        private ConcurrentDictionary<string, TokenPayload> _tokens = new ConcurrentDictionary<string, TokenPayload>();

        public ITokenProvider<TokenPayload> TokenProvider { get; set; }

        private static string _secret = "SECRET";

        public static UserTokenService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        _instance = new UserTokenService()
                        {
                            TokenProvider = new JwtTokenProvider<TokenPayload>()
                        };
                    }
                }

                return _instance;
            }
        }


        public string GetToken(TokenPayload payload)
        {
            var token = TokenProvider.GetToken(payload, _secret);

            _tokens.AddOrUpdate(token, payload, (s, td) => td);

            return token;
        }

        public bool ValidateUserToken(string token)
        {
            return TokenProvider.Validate(token, _secret);
        }
    }

    public class TokenPayload
    {
        public Guid TokenId { get; set; }

        public Guid UserId { get; set; }

        public DateTime ExpireOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
