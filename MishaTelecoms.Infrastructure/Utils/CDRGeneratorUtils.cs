using MishaTelecoms.Domain.Settings;
using System;

namespace MishaTelecoms.Infrastructure.Utils
{
    public class CDRGeneratorUtils
    {
        private readonly CDRGeneratorConfig _config;
        private readonly Random _rnd = new Random();

        public CDRGeneratorUtils(CDRGeneratorConfig config)
        {
            _config = config;
        }

        public string[] CreateStringArray(string str)
        {
            return str.Split(",");
        }

        public string GeneratePhoneNumber()
        {
            string num = "";
            for (int i = 0; i < 10; i++)
                num += _rnd.Next(0, 9).ToString();
            return num;
        }

        public string GenerateCountry()
        {
            string[] result = CreateStringArray(_config.Countries);
            return result[_rnd.Next(0, result.Length)];
        }

        public string GenerateCallType()
        {
            string[] result = CreateStringArray(_config.CallTypes);
            return result[_rnd.Next(0, result.Length)];
        }

        public int GenerateDuration()
        {
            return _rnd.Next(1, 30);
        }

        public string GenerateDate()
        {
            return DateTimeOffset.Now.ToString("yyyyMMdd");
        }

        public string GetFilepath()
        {
            return _config.Filepath;
        }
    }
}
