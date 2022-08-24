using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using GPDataNS;
using NETCore.Encrypt;

namespace TestFunctions
{
    public class GPDataService
    {
        public List<GPData> LoadData()
        {
            List<GPData> gpdatas = new List<GPData>();
            //在下方添加从文件加载数据的方法

            //返回值区
            return gpdatas;
        }

        public string GPHESservice(string MainKey)
        {
            var gphes = new GPHES(MainKey);
            gphes.GetSalt();
            gphes.Mix();
            byte[] SHA256Data = Encoding.UTF8.GetBytes(gphes.SaltedStr);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] by = Sha256.ComputeHash(SHA256Data);
            var HESResult = BitConverter.ToString(by).Replace("-", "").ToLower();
            //var HESResult = EncryptProvider.Sha256(gphes.SaltedStr);
            return HESResult;
        }

    }

    public class GPHES
    {
        private string mainkey_s
        {
            get; set;
        }
        private string salt_s
        {
            get; set;
        }
        private string salted_mainkey
        {
            get; set;
        }

        public GPHES(string mainkey)
        {
            mainkey_s = mainkey;
            salt_s = "12345678";
            salted_mainkey = $"1234{mainkey}5678";
        }

        public string GetSalt()
        {
            //初始化区
            var salt = new char[8];
            var saltBase = new int[8];
            var mainkeyBase = new int[mainkey_s.Length];
            var mkl = mainkey_s.Length;
            var addControl = mkl / 8;
            var j = 0; var mkbc = 0;
            //salt值计算区
            for (var i = 0; i < mkl; i++)
            {
                if (mainkey_s[i] <= 'z' && mainkey_s[i] >= 'a')
                    mainkeyBase[i] = mainkey_s[i] - 'a';
                else if (mainkey_s[i] <= 'Z' && mainkey_s[i] >= 'A')
                    mainkeyBase[i] = mainkey_s[i] - 'A';
                else if (mainkey_s[i] <= '9' && mainkey_s[i] >= '0')
                    mainkeyBase[i] = mainkey_s[i] - '0';
                else
                    mainkeyBase[i] = 0;
            }
            for (var i = 0; i < 8; i++)
            {
                j = 0;
                for (; j < addControl; j++)
                {
                    saltBase[i] += mainkeyBase[mkbc];
                    mkbc++;
                }
                if (saltBase[i] <= 32)
                {
                    saltBase[i] += 32;
                }
                while (saltBase[i] >= 127)
                {
                    saltBase[i] -= 32;
                }
            }
            for (var i = 0; i < 8; i++)
            {
                salt[i] = ((char)saltBase[i]);
            }
            //返回值区
            return salt.ToString();
        }

        public string Mix()
        {
            //定义区
            string remix;
            var s1 = new char[4];
            var s2 = new char[4];
            //运行区
            for (var i = 0; i < 4; i++)
                s1[i] = salt_s[i];
            for (var i = 0; i < 4; i++)
                s2[i] = salt_s[i + 4];
            remix = s1.ToString() + mainkey_s + s2.ToString();
            /*Test codes
             Console.WriteLine(remix);*/
            //返回区
            salted_mainkey = remix;
            return remix;
        }

        public string SaltedStr => salted_mainkey;
    }

}
