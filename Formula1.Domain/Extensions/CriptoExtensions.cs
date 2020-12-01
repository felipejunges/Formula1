namespace Formula1.Domain.Extensions
{
    public static class CriptoExtensions
    {
        public static string GetBCrypt(this string senha, int salt = 12)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha, BCrypt.Net.BCrypt.GenerateSalt(salt));
        }

        public static bool CheckBCrypt(this string hash, string senha)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(senha, hash);
            }
            catch
            {
                return false;
            }
        }
    }
}