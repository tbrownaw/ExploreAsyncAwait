using System;
using System.Threading.Tasks;

namespace TestAsyncAwait
{
    class Fnord
    {
        public string Name { get; private set; }
        public Fnord(string name)
        {
            Name = name;
            Console.WriteLine($"Creating {Name}");
        }
        public void Rename(string n)
        {
            Name = n;
        }
        ~Fnord()
        {
            System.Console.WriteLine($"Destrying {Name}");
        }
    }
    class MyDisposable: IDisposable
    {
        public void Dispose() { }
    }
    class Program
    {
        static void Foobar()
        {
            var xyzzy = new Fnord("pqr");
        }
        async static Task Baz()
        {
            var asdf = new Fnord("stu");
        }
        async static Task Subber(bool sleep)
        {
            var baz = new Fnord("ghi");
            if (sleep)
            {
                await Task.Delay(250);
            }
        }
        async static Task Sub(bool sleep)
        {
            var bar = new Fnord("def");
            await Subber(sleep);
            var quux = new Fnord("jkl");
            {
                await Baz();
                var fnord = new Fnord("mno");
                {
                    var qwerty = new Fnord("vwx");
                }
            }
            using (var x = new MyDisposable())
            {
                var qwerty = new Fnord("FNORD");
            }
            Foobar();
            bar.Rename("DEF");
        }
        async static Task Main(string[] args)
        {
            Console.Write("Sleep?: ");
            var s = Console.ReadLine();
            var sleep = s.IndexOfAny(new[] { 't', 'T', 'y', 'Y', '1' }) > -1;
            {
                var foo = new Fnord("abc");
                foo.Rename("ABC");
                await Sub(sleep);
            }
            Console.WriteLine("Hello World!");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("See you later!");
            //System.Diagnostics.Debugger.Break();
        }
    }
}
