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

                
        }

    }
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
        }
    }

    public interface ILoggerFactory
    {
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
    public class CustomerManagaer
    {
        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = new EdLogger();
        }
    }
}
