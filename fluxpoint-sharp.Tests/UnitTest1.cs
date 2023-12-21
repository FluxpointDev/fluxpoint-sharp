namespace fluxpoint_sharp.Tests;

[TestClass]
public class API
{
    [TestMethod]
    public async Task Test()
    {
        Console.WriteLine("Hello World!");
        string Token = Environment.GetEnvironmentVariable("fluxpoint_api");
        Console.WriteLine("Token: " + Token);

        FluxpointClient Client = new FluxpointClient("Test", Token);
        var Joke = await Client.Misc.GetDadJokeAsync();
        Console.WriteLine("Joke: " + Joke.joke);

        var File = await Client.Sfw.GetNekoAsync();
        Console.WriteLine("File: " + File.file);

            var Res = await Client.ImageGen.SendCustomImageAsync(new CustomImage
            {
                Base = new CanvasImage
                {
                    width = 100,
                    height = 100
                }
            });

            Console.WriteLine("Image: " + Res?.success);
        
    }
}