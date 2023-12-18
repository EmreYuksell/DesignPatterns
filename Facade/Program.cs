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
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
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

     interface ICaching
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
class Validation : IValidate
{
    public void Validate()
    {
        Console.WriteLine("Validated");
    }

}

internal interface IValidate
{
    void Validate();
}

    class CustomerManager
    {
    private CrossCuttonConsernsFasade _concerns;
    public CustomerManager()
    {
       
    }
    public void Save()
    {
        _concerns.Caching.Cache();
        _concerns.Authorize.CheckUser();
        _concerns.Logging.Log();
        _concerns.Validation.Validate();
        Console.WriteLine("Saved");
    }
    class CrossCuttonConsernsFasade
    {
       public  ILogging Logging;
       public ICaching Caching;
       public IAuthorize Authorize;
       public IValidate Validation;

        public CrossCuttonConsernsFasade()
        {
           
         Logging = new Logging();
         Caching = new Caching();

        Authorize = new Authorize();
        Validation = new Validation();
        }

        
    }
}

