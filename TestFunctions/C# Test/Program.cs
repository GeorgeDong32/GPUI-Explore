using System;
using GPDataNS;
using TestFunctions;
using NETCore.Encrypt;

namespace Program
{
    class TestClass
    {
        static void Main(string[] args)
        {
            var test = "GeorgeDong2352";
            var testservice = new GPDataService();

            Console.WriteLine(EncryptProvider.Sha256(test));
            Console.WriteLine(testservice.GPHESservice(test));
            Console.WriteLine(testservice.GPHESservice(test));
        }
    }
}
