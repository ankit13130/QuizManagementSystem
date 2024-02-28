using System.Security.Cryptography;
using System.Text;

namespace QuizManagement.Core.Domain.Helper;

public class EncryptionDecryption
{
    //encrypt
    private const int keySize = 64;
    private const int iterations = 350000;
    //hashing512 is fast but less secure as compared to hashing256 which is slow but more secure
    private HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

    public string HashPasword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(keySize);
        //salt.ToList().ForEach(x => Console.Write(x));
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            hashAlgorithm,
            keySize);
        return Convert.ToHexString(hash);
    }
    //decrypt
    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
}
