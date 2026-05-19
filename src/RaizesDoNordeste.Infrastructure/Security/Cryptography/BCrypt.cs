using RaizesDoNordeste.Domain.Security.Criptography;
using BC = BCrypt.Net.BCrypt;

namespace RaizesDoNordeste.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncrypter
{
    public string Criptografar(string password) => BC.HashPassword(password);
}