using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  ISWebApp.Bot.Base;
using  ConsoleApplication;
namespace ISWebApp.Bot
{
    class Program
    {
      
        static void Main(string[] args)
        {
          // var tlg=new Telegrambot();
          // tlg.Executelegram();
          // Console.WriteLine("A Executar!");
          // Console.ReadLine();
          
        var accessToken = "EAAIxqNXZAbzIBAAjFr2Nb4xzFNi9l2lTdPtBvl1FYMezG7VRAOsccIF2bmh9VSMIxK1ROlLjrk91ZC9mtCvDHQJIO4Jhex6EhEouyLSSQoTNg2LZCRWmfol6Hj1Wo7uyrXYjs9Mbqx9amEvGSsdXpNu4kMLUGNWh0Ikxmn95BUAQmrPy5jA5PSPcJVFwPsZD";
        var facebookClient = new FacebookClient();
        var facebookService = new FacebookService(facebookClient);
        var getAccountTask = facebookService.GetAccountAsync(accessToken);
 
        Task.WaitAll(getAccountTask);
        var account = getAccountTask.Result;
        Console.WriteLine($"{account.Id} {account.Name}");
        var postOnWallTask = facebookService.PostOnWallAsync(accessToken, "Ola!");
        Task.WaitAll(postOnWallTask);
        
        }
      
    }
}
