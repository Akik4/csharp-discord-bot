using System.Runtime.InteropServices.ComTypes;
using Discord;
using Discord.WebSocket;

namespace test.Commands;

public class Receiver
{
    public static async Task MessageReceiver(SocketMessage arg)
    {
        string prefix = "!";
        Dictionary<string, string> cmds = new Dictionary<string, string>();
        cmds.Add("help", "Show you this message");
        cmds.Add("icon", "Show your icon");
        
        if (arg.Content.Equals(prefix + "help"))
        {
            // Generate fields from dictionary
            var fields = new List<EmbedFieldBuilder>();
            foreach (var key in cmds)
            {
                fields.Add(new EmbedFieldBuilder()
                {
                    Name = key.Key,
                    Value = key.Value
                });
            }
            //Create an embed
            var embed = new EmbedBuilder()
            {
                ThumbnailUrl = "https://i.pinimg.com/originals/32/e5/4b/32e54bfee28044d67ff291aa15a116ff.png",
                Description = "Here available commands",
                Color = Color.Gold,
                Fields = fields
            }.Build();
            
            //Send the messages
            await arg.Channel.SendMessageAsync("There is the help embed message", false, embed);
        }

        if (arg.Content.StartsWith(prefix + "icon"))
        {
            //Define var
            string username = "";
            string avatarUrl = "";
            IReadOnlyCollection<SocketUser> users = arg.MentionedUsers;

            //Check if user has been mentioned
            if (users.Count == 1)
            {
                username = users.First().Username;
                avatarUrl = users.First().GetAvatarUrl();
            // Handle if user put more than 1 user
            } else if (users.Count > 1)
            {
                await arg.Channel.SendMessageAsync("You need to provide a single user");
            }
            // Handle if user didn't mention
            else
            {
                username = arg.Author.Username;
                avatarUrl = arg.Author.GetAvatarUrl();
            }
            // Handle error
            if (username != "")
            {
                var embed = new EmbedBuilder()
                {
                    Description = "Here " + username + "'s icon",
                    ImageUrl = avatarUrl,
                    Color = Color.Purple
                }.Build();

                await arg.Channel.SendMessageAsync(null, false, embed);
            }
        }
    }
}