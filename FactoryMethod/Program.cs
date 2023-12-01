using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
     class Program
    {
        static void Main(string[] args)
        {

            CustomerManagaer customerManagaer = new CustomerManagaer(new LoggerFactory2());
            customerManagaer.Save();

            Console.ReadLine();
            Console.ReadLine();
        }

    }
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new LogFNetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLoger");
           
        }

    }
    public class LogFNetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with LogFNetLogger");
           
        }

    }
    public class CustomerManagaer


    {
        private ILoggerFactory _loggerFactory;
        public CustomerManagaer(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
