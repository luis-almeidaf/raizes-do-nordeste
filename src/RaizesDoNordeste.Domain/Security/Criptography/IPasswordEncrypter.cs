namespace RaizesDoNordeste.Domain.Security.Criptography;

public interface IPasswordEncrypter
{
    string Criptografar(string password);
    bool VerificarSenha(string senha, string senhaHash);
}