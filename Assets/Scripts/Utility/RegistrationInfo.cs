using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utility
{

    
    public class RegistrationInfo
    {
        [JsonProperty("Gender")]
        string Gender { get; set; }

        [JsonProperty("BirthDate")]
        DateTime BirthDate { get; set; }

        [JsonProperty("BirthCity")]
        string BirthCity { get; set; }

        [JsonProperty("BirthCountry")]
        string BirthCountry { get; set; }

        public RegistrationInfo(string gender, DateTime birthDate, string birthCity, string birthCountry)
        {
            Gender = gender;
            BirthDate = birthDate;
            BirthCity = birthCity;
            BirthCountry = birthCountry;
        }



    }
}
