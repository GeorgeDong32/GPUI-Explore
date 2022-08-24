using System;
using GPDataNS;
using TestFunctions;

namespace Program
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var test = "GeorgeDong2352";
            var testservice = new GPDataService();
            Console.WriteLine(testservice.GPHESservice(test));
            Console.WriteLine(testservice.GPHESservice(test));
        }
    }
}
