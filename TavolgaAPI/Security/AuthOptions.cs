using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TavolgaAPI.Core
{
    public class AuthOptions
    {
        public const string ISSUER = "TaVolgaApi"; // издатель токена
        public const string AUDIENCE = "TaVolgaApiClient"; // потребитель токена
        const string KEY = "xPhvXHvHFRWKxVntrPkv3vUqccTUf2wD9hEMW6APzUnCcRE4SuWeumEtdZUbQqAwtHQxtXb4usC5yy8P4uGNF7cUmzK2StkgGEpJn5qxVKdvhtEq8KDtfmYH2JKxMZYgS4R2LgdZDL5VQdmHXJBHywWzUJSfbf48E2THggwkVusNFCJna6NYgsSaQTF4SU93gnsrm3Yg4gtXdCTxY4PqDks3yBXSmfqsTGfcazzeCM8QWgyNV6BRynhjgZWxPAkc";
        public const int LIFETIME = 14; // время жизни токена - 14 дней
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
