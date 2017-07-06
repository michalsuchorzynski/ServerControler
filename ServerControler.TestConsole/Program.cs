using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerControler.EntityModel;

namespace ServerControler.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DataBaseModel())
            {
                db.Tests.Add(new Test { Name = "Another Blog " });
                db.SaveChanges();

                foreach (var blog in db.Tests)
                {
                    Console.WriteLine(blog.Name);
                }
            }
            Console.ReadKey();
        }
    }
}
