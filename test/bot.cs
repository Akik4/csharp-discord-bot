using Discord;
using Discord.WebSocket;
using test.Commands;

namespace test;

public class bot
{
        private DiscordSocketClient? _client;

        public async Task<DiscordSocketClient> Run(string token)
        {
            var config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.All
            };
            
            _client = new DiscordSocketClient(config);

            _client.Log += Log;

            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await _client.LoginAsync(TokenType.Bot, token);
            _client.MessageReceived += Receiver.MessageReceiver;
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);

            return _client;
        }

        
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
}