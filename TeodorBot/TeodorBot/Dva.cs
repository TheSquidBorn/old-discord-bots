using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace TeodorBot
{
    class Dva
    {
        DiscordClient discord;
        CommandService commands;

        public Dva()
        {
            Console.WriteLine("Starting dva");

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x  =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            commands.CreateCommand("r8")
                .Do(async (e) =>
                {
                    if (e.User.Id == 152501884291252224)
                    {
                        //maja
                        await e.Channel.SendMessage("Ur a sidehoe");
                    }
                    else if (e.User.Id == 130025550201749504)
                    {
                        //erik
                        await e.Channel.SendMessage("GG- gay guy.");
                    }
                    else if (e.User.Id == 152502387079249920)
                    {
                        //annie
                        await e.Channel.SendMessage("TEODOR.");
                    }
                    else
                    {
                        //annan
                    }
                });
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjQ4ODkxOTkyNzMyNDY3MjAy.CxBG2w.BxnTciMUVYquS-q5q_93rv1WYM8", TokenType.Bot);
            });
        }
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
