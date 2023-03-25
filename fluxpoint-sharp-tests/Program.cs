using fluxpoint_sharp;
using System.Text.Json;

namespace fluxpoint_sharp_tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running tests");
            new Program().Start().GetAwaiter().GetResult();
        }

        public async Task Start()
        {
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"/DiscordBots/Waifu/";
            string jsonString = File.ReadAllText(Path + "Config.json");
            Console.WriteLine(jsonString);
            TokenInfo Token = JsonSerializer.Deserialize<TokenInfo>(jsonString);
            FluxpointClient fp = new FluxpointClient("Test", Token.API);

            var CurrentDate = DateTime.Now;
            await fp.Misc.GetMeAsync();
            Console.WriteLine(DateTime.Now - CurrentDate);


            await Task.Delay(-1);
        }

        public class TokenInfo
        {
            public string API { get; set; }
        }
    }
}