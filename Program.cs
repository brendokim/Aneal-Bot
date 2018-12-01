using System;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;

using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace Aneal_Bot
{
    class Program
    {
        private DiscordSocketClient Client;
        private CommandService Commands;

        static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();


        private async Task MainAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {

                LogLevel = LogSeverity.Debug

            });

            Commands = new CommandService(new CommandServiceConfig

            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug

            });

            Client.MessageReceived += Client_MessageReceived;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());

            Client.Ready += Client_Ready;
            Client.Log += Client_Log;

            string Token = "";
            using (var Stream = new FileStream((Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).Replace(@"bin\Debug\netcoreapp2.0", @"Data\Token.txt"), FileMode.Open, FileAccess.Read))
            using (var ReadToken = new StreamReader(Stream))
            {
                Token = ReadToken.ReadToEnd();

            }
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();

            await Task.Delay(-1);

        }


        private async Task Client_Log(LogMessage Message)
        {
            Console.WriteLine($"{DateTime.Now} at {Message.Source}] {Message.Message}");

        }

        private async Task Client_Ready()
        {

            await Client.SetGameAsync("Aneal's Game of Life!", "https://www.youtube.com/watch?v=TA91T_OPajw", StreamType.NotStreaming);

        }

        private async Task Client_MessageReceived(SocketMessage arg)
        {

          //  throw new NotImplementedException();

        }
    }

}
