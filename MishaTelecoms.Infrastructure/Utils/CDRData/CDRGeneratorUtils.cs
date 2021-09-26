using MishaTelecoms.Domain.Settings;
using System;

namespace MishaTelecoms.Infrastructure.Utils.CDRData
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
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException($"'{nameof(str)}' cannot be null or empty.", nameof(str));

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
            return result[_rnd.Next(0, result.Length)].Trim();
        }

        public string GenerateCallType()
        {
            string[] result = CreateStringArray(_config.CallTypes);
            return result[_rnd.Next(0, result.Length)].Trim();
        }

        public int GenerateDuration()
        {
            return _rnd.Next(1, 30);
        }

        public string GetFilepath()
        {
            return _config.Filepath;
        }

        public double CalculateCost(string country, int duration)
        {
            return country switch
            {
                "Ireland" => Math.Round(0.66 * duration, 5),
                "England" => Math.Round(0.85 * duration, 10),
                "Scotland" => Math.Round(1.10 * duration, 1),
                "Wales" => Math.Round(0.77 * duration, 0),
                "NorthernIreland" => Math.Round(0.89 * duration, 2),
                _ => 0.0,
            };
        }
    }
}
