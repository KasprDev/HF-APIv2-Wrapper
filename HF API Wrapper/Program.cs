using HFApi.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_API_Wrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            HFApi hf = new HFApi("hf_clientid_", "hf_secret_");

            if (!File.Exists("access-token.txt"))
            {
                HFAuthDto auth = await hf.GetAccessTokenAsync("hf_code");

                if (auth.AccessToken != null)
                {
                    File.WriteAllText("access-token.txt", auth.AccessToken);
                }
            }
            else
            {
                hf.AccessToken = File.ReadAllText("access-token.txt");
            }
        }
    }
}
