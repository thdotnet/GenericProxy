using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fooRequest = "request";
            var barRequest = 3;

            var fooService = new FooService();
            var barService = new BarService();

            ServiceProxy<string,string>.Invoke(fooService.DoFoo, fooRequest);
            ServiceProxy<int, int>.Invoke(barService.DoBar, barRequest);

            Console.Read();
        }
    }

    class ServiceProxy<TRequest, TResponse>
    {
        public static void Invoke(Func<TRequest, TResponse> service, TRequest request)
        {
            var method = service.Method.Name;

            Console.WriteLine("Invoking method {0} from {1}" , method , service.Target);
            Console.WriteLine("Init at {0} ", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff"));

            Console.WriteLine("input:" + request);

            var response = service(request);

            Console.WriteLine("output:" + response);
            Console.WriteLine("End at {0} ", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff"));
            Console.WriteLine(" ");
        }
    }

    class FooService
    {
        public string DoFoo(object a)
        {
            return a + ": returning: Do Foo";
        }
    }

    class BarService
    {
        public int DoBar(int a)
        {
            return a + a;
        }
    }
}
