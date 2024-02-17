using System.Text;

namespace PomodoroAPI.Infrastructure;

public class Keys
{
    public static byte[] Jwt
    {
        get
        {
            var key = CustomEnv.Get("JTW_SECRET_KEY");
            if (key == null) throw new Exception("Forneça a chave \"JTW_SECRET_KEY\"");
            return Encoding.ASCII.GetBytes(key);
        }
    }
}