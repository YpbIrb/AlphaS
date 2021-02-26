using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utility
{


    public class AuthorisationInfo
    {
        [JsonProperty("ID")]
        string ID { get; set; }

        public AuthorisationInfo(string iD)
        {
            ID = iD;
        }

    }
}
