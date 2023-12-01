using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
     class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
            Console.ReadLine();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);

    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net");
        
        }


    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
        Console.WriteLine("Logged with NLogged");
        }
    }
    public abstract class Catching
    {
        public abstract void Cache(string data);

    }
    public class MemCache:Catching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Catching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }
    public abstract class CrossCuttingConcernsFactory1
    {
        public abstract Logging CreateLogger();
        public abstract Catching CreateCatching(); 
    }
    public class Factory1 : CrossCuttingConcernsFactory1
    {
        public override Catching CreateCatching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class Factory2 : CrossCuttingConcernsFactory1
    {
        public override Catching CreateCatching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    public class ProductManager
    {
       private CrossCuttingConcernsFactory1 _crossCuttingConcernsFactory1;

        private Logging _logging;
        private Catching _catching;

        public ProductManager(CrossCuttingConcernsFactory1 crossCuttingConcernsFactory1)
        {
           _crossCuttingConcernsFactory1 = crossCuttingConcernsFactory1;
            _logging = _crossCuttingConcernsFactory1.CreateLogger();
           _catching= _crossCuttingConcernsFactory1.CreateCatching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _catching.Cache("Data");
            Console.WriteLine("Listed");
        }
    }

}
