using Discord.WebSocket;

namespace test.Commands;

public class Receiver
{
    public static async Task MessageReceiver(SocketMessage arg)
    {
        if (arg.Content.Equals("!help"))
        {
            await arg.Channel.SendMessageAsync("Now i'm in an external class");
        }
    }
}