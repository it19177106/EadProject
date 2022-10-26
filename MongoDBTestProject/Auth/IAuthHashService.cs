namespace MongoDBTestProject.Auth
{
    public interface IAuthHashService
    {
        void PasswordHashing(String password, out byte[] passwordHash, out byte[] passwordKey);

        bool VerifyPassword(String password, byte[]? passwordHash, byte[]? passwordKey);


    }
}
