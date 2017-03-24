using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord;
using Discord.Commands;

namespace TeodorBot
{
    class Bot
    {
        public string Time()
        {
            return string.Format("[{0:HH:mm:ss}]", DateTime.Now);
        }

        DiscordClient discord;
        CommandService commands;

        Random rand = new Random();

        String path = @"C:\Users\Elev\Desktop\BotLogs\TeodorsLogs.txt";

        public Bot()
        {
            Console.WriteLine("{0}Starting Teodor", Time());

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            //add command prefix (the ! in !(command))
            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "TEODORBOTS LOGS");
            }

            commands.CreateCommand("d20").Do(async (e) =>
            {
                int x = rand.Next(1, 21);
                await e.Channel.SendMessage(x.ToString());
            });

            commands.CreateCommand("d6").Do(async (e) =>
            {
                int x = rand.Next(1, 7);
                await e.Channel.SendMessage(x.ToString());
            });

            //create hello command that says hello
            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("Hi!");
                    Console.WriteLine("{0}Said Hello to {1}!", Time(), e.User);

                    
                });
            //MEMES
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
            //Memes over

            //Purges 100 last messages after permission check
            commands.CreateCommand("purge").Do(async (e) =>
            {
                Console.WriteLine("{0}Checking {1} permissions for purge.", Time(), e.User);
                if (e.User.ServerPermissions.ManageMessages != true)
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

                    string appendText = Environment.NewLine + Time() + " User " + e.Message.User + " purged " + e.Message.Channel;
                    File.AppendAllText(path, appendText);
                }
                else
                {
                    Console.WriteLine("{0}Not proper permissions.", Time());
                    string appendText = Environment.NewLine + Time() + " User " + e.Message.User + " tried to purge " + e.Message.Channel + " but they didn't have permissions";
                    File.AppendAllText(path, appendText);
                }
            });

            //connects
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjQ3ODE3NjQ5MDc2MTc0ODQ4.CwyAdw.CAbfARItTIkIKSQqbS0qR2cLqTg", TokenType.Bot);
            });
        }

        //log function
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine("{0}{1}", Time(), e.Message);
        }
    }
}
