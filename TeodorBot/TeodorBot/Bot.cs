using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace TeodorBot
{
    class Bot
    {
        private string Time()
        {
            return string.Format("[{0:HH:mm:ss}]", DateTime.Now);
        }

        DiscordClient discord;
        CommandService commands;

        public Bot()
        {
            string[] NC = new string[20];

            NC[0] = "nick/0";
            NC[1] = "nick/1";
            NC[2] = "nick/2";
            NC[3] = "nick/3";
            NC[5] = "nick/4";
            NC[4] = "nick/5";
            NC[6] = "nick/6";
            NC[7] = "nick/7";
            NC[8] = "nick/8";
            NC[9] = "nick/9";
            NC[10] = "nick/10";
            NC[11] = "nick/11";
            NC[12] = "nick/12";
            NC[13] = "nick/13";
            NC[14] = "nick/14";
            NC[15] = "nick/15";
            NC[16] = "nick/16";
            NC[17] = "nick/17";
            NC[18] = "nick/18";
            NC[19] = "nick/19";

            Console.WriteLine("{0}Starting Teodor", Time());

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            // Variables

            //add command prefix (the ! in !(command))
            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            //create hello command that says hello
            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("Hi!");
                Console.WriteLine("{0}Said Hello to {1}!", Time(), e.User);
                });

            commands.CreateCommand("detaljer")
                .Do(async (e) => 
                {
                    Console.WriteLine("{0}{1}sent BARA DETALJER VETTU", Time(), e.User);
                    await e.Channel.SendFile("img/detaljer.jpg");
                });

            commands.CreateCommand("anninem")
                .Do(async (e) =>
                {
                    Console.WriteLine("{0}{1} sent Emninem", Time(), e.User);
                    await e.Channel.SendFile("img/eminem1.jpg");
                    await e.Channel.SendFile("img/eminem2.jpg");
                });

            commands.CreateCommand("GO")
                .Do(async (e) =>
                {
                    Console.WriteLine("{0}{1} BWAH", Time(), e.User);

                    await e.Channel.SendMessage("BWAH");
                });

            commands.CreateCommand("gw")
                .Do(async (e) =>
                {
                    Console.WriteLine("{0}{1} sent gw", Time(), e.User);
                    await e.Channel.SendFile("img/gw.jpg");
                });

            RegisterPurgeCommand();
            //RegisterTestCommand();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjQ3ODE3NjQ5MDc2MTc0ODQ4.CwyAdw.CAbfARItTIkIKSQqbS0qR2cLqTg", TokenType.Bot);
            });
        }

        //private void RegisterTestCommand()
        //{
        //    commands.CreateCommand("test").Do(async (e) =>
        //    {

        //        Console.WriteLine("");
        //        await e.Message.Channel.SendMessage("You have {0} in your bank", );
        //    });
        //}

    //create purge command (!purge)
    private void RegisterPurgeCommand()
        {
            commands.CreateCommand("purge").Do(async (e) =>
                {
                    Console.WriteLine("{0}Checking {1} permissions for purge.", Time(), e.User);
                    if (e.User.ServerPermissions.ManageMessages == true)
                    {
                        //check if user has privileges to purge
                        Console.WriteLine("{0}Starting purge.", Time());

                        //create array for messages
                        Message[] messagesToDelete;

                        //take the 100 latest messages and put them in the array
                        messagesToDelete = await e.Channel.DownloadMessages(100);

                        //delete all the messages in the array 
                        await e.Channel.DeleteMessages(messagesToDelete);

                        Console.WriteLine("{0}Purged.", Time());
                    }
                    else
                    {
                        Console.WriteLine("{0}Not proper permissions.", Time());
                    }
                });

        }
        //log function
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine("{0}{1}", Time(), e.Message);
        }
    }
}
