using RaizesDoNordeste.Domain.Security.Criptography;
using BC = BCrypt.Net.BCrypt;

namespace RaizesDoNordeste.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncrypter
{
    public string Criptografar(string password)
    {
        return BC.HashPassword(password);
    }

    public bool VerificarSenha(string senha, string senhaHash)
    {
        return BC.Verify(senha, senhaHash);
    }
}