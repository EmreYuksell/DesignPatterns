using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
     class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomManager.CreateAsSingleton();
            customerManager.Save();
        }

        class CustomManager
        {
            private static CustomManager _customerManager;

                private CustomManager()
            {


            }
            public static CustomManager CreateAsSingleton()
            {
                if( _customerManager == null)
                {
                    _customerManager = new CustomManager();
                }
                return _customerManager;
            }
            public  void Save()
            {
                Console.WriteLine("Save");

            }
        }
    }
}
