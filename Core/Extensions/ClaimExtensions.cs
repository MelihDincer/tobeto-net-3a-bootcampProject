using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Extensions;

public static class ClaimExtensions
{
    //Kullanıcının e-postasının yer aldığı claimleri ICollection<Claim> nesnesine ekler.
    public static void AddEmail(this ICollection<Claim> claims, string email)
    {
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
    }

    //Kullanıcının adının yer aldığı claimleri ICollection<Claim> nesnesine ekler.
    public static void AddName(this ICollection<Claim> claims, string name)
    {
        claims.Add(new Claim(ClaimTypes.Name, name));
    }

    //Kullanıcının rolünün yer aldığı claimleri ICollection<Claim> nesnesine ekler.
    public static void AddRoles(this ICollection<Claim> claims, string[] roles)
    {
        //Rolleri listele.ForEach döngüsü ile her bir rol için döngüye gir. Döngünün her adımında yeni bir "Claim" nesnesi oluştur. Oluşturulan yeni "Claim" nesnesini, claims koleksiyonuna add metodu ile ekle. Kısaca her bir rol için ayrı bir claim eklenmiş oldu.
        roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
    }

    //Kullanıcının benzersiz tanımlayıcısını bir claim olarak ICollection<Claim> nesnesine ekleme
    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
    }
}
