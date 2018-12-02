using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

using Discord;
using Discord.Commands;

namespace anealBot
{
    public class HelloWorld : ModuleBase<SocketCommandContext>
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

        [Command("Chief"), Alias("Chiefworld", "world"), Summary("Chief world command")]
        public async Task Chief()
        {
            await Context.Channel.SendMessageAsync("Hey Chief");
        }

        [Command("embed"), Summary("Embed test command")]
        public async Task Embed([Remainder]string Input = "None")
        {
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithAuthor("Test embed", Context.User.GetAvatarUrl());
            Embed.WithColor(40, 200, 150);
            Embed.WithFooter("The footer of the embed", Context.Guild.Owner.GetAvatarUrl());
            Embed.WithDescription("This is a **dummy**   description, with a cool link.\n" +
                              "[This is my favourite website](https://niceme.me/)");
            Embed.AddInlineField("User input:", Input); 


            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }
    }

}

