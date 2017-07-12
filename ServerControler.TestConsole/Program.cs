using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerControler.EntityModel;
using ServerControler.TestConsole.AdminServiceLocal;
//using ServerControler.TestConsole.AdminServiceServer;

namespace ServerControler.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminServiceClient client = new AdminServiceClient();
            client.Open();
            //Console.WriteLine(client.CopyAndPasteDirectory("nowy", "C:\\Users\\Michał\\Desktop\\Test", "C:\\Users\\Michał\\Desktop"));
            //Console.WriteLine(client.AddNewDirectory("nowy", "\\192.168.1.8\\$C"));
            //Console.WriteLine(client.DeleteFile("nowy.txt", "\\192.168.1.8\\$C"));
            //Console.WriteLine(client.DeleteDirectory("nowy", "\\192.168.1.8\\$C"));
            client.Close();
            Console.ReadKey();

        }
    }
}
