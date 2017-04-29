using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ConsoleApplication2
{
    class Observation
    {
        public string id;
        public string latitude;
        public string longitude;
        public string time_observed_at_utc;
        public string place_guess;
        public string species_guess;
        public string quality_grade;
        public string num_identification_disagreements;

        [JsonConstructor]
        public Observation(string id, string latitude, string longitude, string time_observed_at_utc, string place_guess, string species_guess, string quality_grade, string num_identification_disagreements)
        {
            this.id = id;
            this.latitude = latitude;
            this.longitude = longitude;
            this.time_observed_at_utc = time_observed_at_utc;
            this.place_guess = place_guess;
            this.species_guess = species_guess;
            this.quality_grade = quality_grade;
            this.num_identification_disagreements = num_identification_disagreements;
        }
    }
}
