using Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
     class Program
    {
        static void Main(string[] args)
        {

        }

    }
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");


        }
    }
    internal interface ILogging
    {
        void Log();
    }
        class Caching:ICaching
        {
            public void Cache()
            {
                Console.WriteLine("Cached");
            }

        }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
            public void CheckUser()
            {
                Console.WriteLine("User Checked");
            }

        }

    internal interface IAuthorize
    {   
        void CheckUser();
    }
}
    class CustomerManager
    {
    private ILogging _logging;
    ICaching _caching;
    IAuthorize _authorize;
    public CustomerManager(ILogging logging, ICaching caching, IAuthorize authorize)
    {
        _logging = logging;
        _caching = caching;
        _authorize = authorize;
    }
    public void Save()
    {
        _logging.Log();
        _caching.Cache();
        _authorize.CheckUser();
        Console.WriteLine("Saved");
    }
}

