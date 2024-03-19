using System.Text;

namespace PomodoroAPI.Infrastructure;

public static class EnvVariables
{
    public static byte[] Jwt
    {
        get
        {
            var key = CustomEnv.Get("JWT_SECRET_KEY");
            if (key == null) throw new Exception("Forneça a chave \"JWT_SECRET_KEY\"");
            return Encoding.ASCII.GetBytes(key);
        }
    }

    public static int JwtTokenExpires
    {
        get
        {
            var key = CustomEnv.Get("JWT_TOKEN_EXPIRES");
            if (key == null) throw new Exception("Forneça a chave \"JWT_TOKEN_EXPIRES\"");
            return int.Parse(key);
        }
    }
}