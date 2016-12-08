using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DvaBot
{
    class Dva
    {
        private string Time()
        {
            return string.Format("[{0:HH:mm:ss}]", DateTime.Now);
        }

        DiscordClient discord;
        CommandService commands;

        public Dva()
        {
            Console.WriteLine("{0}Starting dva", Time());

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            commands.CreateCommand("ult")
                .Do(async (e) =>
                {
                    Console.WriteLine("{0}Checking {1} for permissions.", Time(), e.Message.User);

                    if (e.User.ServerPermissions.ManageMessages == true)
                    {
                        Console.WriteLine("{0}Nerfing this.", Time());
                        Console.WriteLine("{0}{1}Nerfed this.", Time(), e.Message.User);

                        await e.Channel.SendTTSMessage("NERF DIS");
                        await e.Channel.SendMessage("!purge");
                    }
                    else
                    {
                        Console.WriteLine("{0}{1} Doesn't have the proper permissions to nerf dis", Time(), e.Message.User);
                        await e.Channel.SendMessage("Hey, u can't nerf dis! ");
                    }
                });

            commands.CreateCommand("r8")
                .Do(async (e) =>
                {
                    if (e.User.Id == 152501884291252224)
                    {
                        //maja
                        Console.WriteLine("{0}Rated Maja", Time());

                        await e.Channel.SendMessage("MARRY M- NAH M8 UR A SIDEHOE");
                    }
                    else if (e.User.Id == 130025550201749504)
                    {
                        //erik
                        Console.WriteLine("{0}Rated Erik", Time());

                        await e.Channel.SendMessage("GOTT'EM");
                    }
                    else if (e.User.Id == 152502387079249920)
                    {
                        //annie
                        Console.WriteLine("{0}Rated Annie", Time());

                        await e.Channel.SendMessage("TEODOR.");
                    }
                    else if (e.User.Id == 196002504318648320)
                    {
                        //valter
                        Console.WriteLine("{0}Rated Valter", Time());

                        await e.Channel.SendMessage("FURRY");
                    }
                    else
                    {
                        //annan
                        Console.WriteLine("{0}Rated Someone else", Time());

                        await e.Channel.SendMessage("I PLAY TO WIN");
                    }
                });
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjQ4ODkxOTkyNzMyNDY3MjAy.CxBG2w.BxnTciMUVYquS-q5q_93rv1WYM8", TokenType.Bot);
            });
        }
        private void Log(object sender, LogMessageEventArgs e)
        { 
            Console.WriteLine("{0}{1}", Time(), e.Message);
        }
    }
}
