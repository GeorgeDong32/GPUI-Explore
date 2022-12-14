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
            var gphes = new GPHES(test);
            gphes.GetSalt();
            gphes.Mix();
            Console.WriteLine(EncryptProvider.Sha256(gphes.SaltedStr));
            Console.WriteLine(testservice.GPHESservice(test));
            Console.WriteLine(testservice.GPHESservice(test));
        }
    }
}
