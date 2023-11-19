using System;
using Discord;
using Discord.WebSocket;
using test.Commands;
using System.IO;

namespace test
{ 
    internal class Program
    {
        public static Task Main(string[] args)
        {
            Task<DiscordSocketClient> client = new bot().Run(args[0]);
            return client;
        }
    }
}