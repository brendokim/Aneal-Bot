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
        public async Task Brendon()
        {
            await Context.Channel.SendMessageAsync("Hello world");
        }
    }
}
