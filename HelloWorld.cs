using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

using Discord;
using Discord.Commands;

namespace anealBot
{
    public class HelloWorld: ModuleBase<SocketCommandContext>
    {
        [Command("Hello"), Alias("helloworld", "world"), Summary("Hello world command")]
        public async Task Aneal()
        {
            await Context.Channel.SendMessageAsync("Hello world");
        }

        [Command("Bomb"), Alias("Bombworld", "world"), Summary("Bomb world command")]
        public async Task Bomb()
        {
            await Context.Channel.SendMessageAsync("BOOM");
        }


    }
}
