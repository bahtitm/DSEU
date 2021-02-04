using System;
using System.Text.RegularExpressions;
using DSEU.Application.Services.Interfaces;

namespace DSEU.Infrastructure.Services
{
    public class RegistrationIndexExtractor : IRegistrationIndexExtractor
    {
        private const string REGISTRATION_INDEX_GROUP_NAME = "number";

        public int ExtractIndexByPattern(string registrationNumber, string pattern)
        {
            var regExp = new Regex(pattern);
            var matchResult = regExp.Match(registrationNumber);
            var group = matchResult.Groups[REGISTRATION_INDEX_GROUP_NAME];
            
            if (matchResult.Success && group.Success)
            {
                var registrationIndex = Convert.ToInt32(group.Value);
                return registrationIndex;
            }
            else
            {
                throw new ArgumentException($"Invalid registration number", nameof(registrationNumber));
            }
        }
    }
}
