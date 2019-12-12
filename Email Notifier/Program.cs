using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blood_Pressure_Tracker;
using Blood_Pressure_Tracker.Models;
using Email_Notifier.SendEmailRefrence;

namespace Email_Notifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "aspnet-Blood-Pressure-Tracker-20191208065438";
            ApplicationDbContext database = new ApplicationDbContext(connection, true);
            SendEmailRefrence.SendEmailServiceClient emailService = new SendEmailServiceClient();
            while (true)
            {
                foreach (var user in database.Users)
                {
                    string body = $"Hello {user.Name}\nPlease measure your pressure.\nKeep healthy ♥";
                    string subject = "Blood pressure notifier";
                    Console.WriteLine($"Sendig to {user.Name} , {user.Email}");
                    emailService.SendEmail("BloodPressure.notfication@gmail.com", user.Email, body, subject, "blood@1234");
                    Console.WriteLine("Sent ♥");
                }
                Thread.Sleep(MinutesToMilliSeconds(30));
            }
        }

        public static int MinutesToMilliSeconds(int minutes)
        {
            return minutes * 60 * 1000;
        }
    }
}
