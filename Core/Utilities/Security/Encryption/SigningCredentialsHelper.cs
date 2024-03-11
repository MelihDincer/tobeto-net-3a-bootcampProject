using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption;

public class SigningCredentialsHelper
{
    //Dijital imza (signing credential) oluşturma.
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); //MD5 
    }
}
