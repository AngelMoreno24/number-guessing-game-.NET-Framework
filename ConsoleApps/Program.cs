using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace ConsoleApps
{
    
    [ServiceContract]
    public interface myInterface
    {
        //Operation contracts for SecretNumber and checkNumber method
        [OperationContract]
         int SecretNumber(int lower, int upper);

        [OperationContract]
         string checkNumber(int userNum, int SecretNum);
    }

    //Implementations of SecretNumber and checkNumber
    public class NumberGuess : myInterface
    {
        public int SecretNumber(int lower, int upper)
        {
            DateTime currentDate = DateTime.Now;
            int seed = (int)currentDate.Ticks;
            Random random = new Random(seed);
            int sNumber = random.Next(lower, upper);
            return sNumber;
        }
        public string checkNumber(int userNum, int SecretNum)
        {
            if (userNum == SecretNum)
                return "correct";
            else
            if (userNum > SecretNum)
                return "too big";
            else return "too small";
        }
    }
    



    internal class Program
    {
        static void Main(string[] args)
        {
            //create URI instance
            Uri baseAddress = new Uri("http://localhost:8000/Service");

            //creates a serviceHost instand in order to host service
            ServiceHost selfHost = new ServiceHost
                      (typeof(NumberGuess),
                      baseAddress);

            //adds binding
            selfHost.AddServiceEndpoint(
                     typeof(myInterface),
                     new WSHttpBinding(),
                     "myService");

            //adds metadata
            System.ServiceModel.Description.ServiceMetadataBehavior smb =
        new System.ServiceModel.Description.ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            //starts the service
            selfHost.Open();
            Console.WriteLine("myService developed is ready to take requests. Please create a client to play my number guessing game.");
            Console.WriteLine("If you want to quit this service, simply press <ENTER>.\n");
            Console.ReadLine();

            //closes the service
            selfHost.Close();

        }
    }
}
