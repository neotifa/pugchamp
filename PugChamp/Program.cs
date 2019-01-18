using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace PugChamp
{
    class Program
    {

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandHandler _handler;
       
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            
            // client.Log += Log;
            // client.MessageReceived += MessageRecieved;
            await _client.LoginAsync(TokenType.Bot, getToken());
            await _client.StartAsync();

            _handler = new CommandHandler(_client);

            await Task.Delay(-1);
        }


        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private string getToken()
        {
            string token = System.IO.File.ReadAllText("../../token.txt");
            return token;
        }

        private async Task MessageRecieved(SocketMessage message)
        {
            if(message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("!pong");
            }
        }
    }
}
