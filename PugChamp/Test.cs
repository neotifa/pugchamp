using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace PugChamp
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            var a = new Discord.EmbedBuilder();
            a.WithTitle("Commands");
            a.WithDescription("General Commands\n-- !help // Gives a list of commands to use");
            a.WithColor(new Discord.Color(0, 170, 255));
            Discord.IDMChannel gencom = await Context.Message.Author.GetOrCreateDMChannelAsync();
            await gencom.SendMessageAsync("", false, a.Build());
            await gencom.CloseAsync();
        }

        [Command("kick")]
        [RequireBotPermission(Discord.GuildPermission.KickMembers)]
        [RequireUserPermission(Discord.GuildPermission.KickMembers)]
        public async Task KickAsync(Discord.IGuildUser user, [Remainder] string reason)
        {
            if(user.GuildPermissions.KickMembers)
            {
                var b = new Discord.EmbedBuilder();
                b.WithTitle("User Kicked");
                b.WithDescription(user.Username + " was kicked.");
                b.WithColor(new Discord.Color(0, 170, 255));
                await Context.Channel.SendMessageAsync("", false, b.Build());
                await user.KickAsync();
            }
        }

        [Command("postwelcome")]
        public async Task Welcome()
        {
            var c = new Discord.EmbedBuilder();
            c.WithTitle("Welcome");
            c.WithDescription("Enjoy your time here! :smile:");
            c.WithColor(new Discord.Color(0, 170, 255));
            await Context.Channel.SendMessageAsync("", false, c.Build());
        }

        [Command("postrules")]
        public async Task Rules()
        {
            var d = new Discord.EmbedBuilder();
            d.WithTitle("Rules");
            d.WithDescription("-wat");
            d.WithColor(new Discord.Color(0, 170, 255));
            await Context.Channel.SendMessageAsync("", false, d.Build());
        }
    }
}
