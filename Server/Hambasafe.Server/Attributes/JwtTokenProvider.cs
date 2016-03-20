using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Hambasafe.Server.Attributes
{
    public interface ITokenProvider<in TPayload>
    {
        string GetToken(TPayload payload, string key);
        bool Validate(string token, string key);
    }

    public class JwtTokenProvider<TPayload> : ITokenProvider<TPayload>
    {
        public string GetToken(TPayload payload, string key)
        {
            return EncodeToken(payload, key);
        }

        public bool Validate(string token, string key)
        {
            var result = DecodeToken(token, key);

            return DateTime.Now <= result.ExpireOn;
        }

        public static string EncodeToken(TPayload jwtPayload, string secret)
        {
            const string algorithm = "HS256";

            var header = new JwtHeader
            {
                Typ = "JWT",
                Alg = algorithm
            };


            var payload = JsonConvert.SerializeObject(jwtPayload);

            payload = Eas.EncryptText(payload, secret);

            var jwt = Base64Encode(JsonConvert.SerializeObject(header)) + "." + payload;

            jwt += "." + Sign(jwt, secret);

            return jwt;
        }

        public static TokenPayload DecodeToken(string token, string secret)
        {
            var segments = token.Split('.');

            if (segments.Length != 3)
                throw new Exception("Token structure is incorrect!");

            JwtHeader header = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(Base64Decode(segments[0])), typeof(JwtHeader));

            var payload = Eas.DecryptText(segments[1], secret);

            //TokenPayload jwtPayload = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(Base64Decode(segments[1])), typeof(TokenPayload));
            TokenPayload jwtPayload = JsonConvert.DeserializeObject<TokenPayload>(payload);


            var rawSignature = segments[0] + '.' + segments[1];

            if (!Verify(rawSignature, secret, segments[2]))
                throw new Exception("Verification Failed");

            return jwtPayload;
        }

        private static bool Verify(string rawSignature, string secret, string signature)
        {
            return signature == Sign(rawSignature, secret);
        }

        private static string Sign(string str, string key)
        {
            var encoding = new ASCIIEncoding();

            byte[] signature;

            using (var crypto = new HMACSHA256(encoding.GetBytes(key)))
            {
                signature = crypto.ComputeHash(encoding.GetBytes(str));
            }

            return Base64Encode(signature);
        }

        public static string Base64Encode(dynamic obj)
        {
            Type strType = obj.GetType();

            var base64EncodedValue = Convert.ToBase64String(strType.Name.ToLower() == "string" ? Encoding.UTF8.GetBytes(obj) : obj);

            return base64EncodedValue;
        }

        public static dynamic Base64Decode(string str)
        {
            var base64DecodedValue = Convert.FromBase64String(str);

            return base64DecodedValue;
        }
    }

    public class JwtHeader
    {
        public string Typ { get; set; }
        public string Alg { get; set; }
    }
}
