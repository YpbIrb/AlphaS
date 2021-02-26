using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    [Serializable]
    public class Participant
    {
        
        string ID { get; set; }

        string Gender { get; set; }

        DateTime BirthDate { get; set; }

        string BirthCity { get; set; }

        string BirthCountry { get; set; }

        public Participant(string gender, DateTime birthDate, string birthCity, string birthCountry)
        {
            Gender = gender;
            BirthDate = birthDate;
            BirthCity = birthCity;
            BirthCountry = birthCountry;
        }



    }
}
