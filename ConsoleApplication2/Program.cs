using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
namespace ConsoleApplication2
{
    class Program
    {
        public static string url = "https://www.inaturalist.org/";
        public static string observationParams = "observations.json?per_page=200";
        public static string placesParams = "places.json?per_page=200&place_type=country";
        static void Main(string[] args)
        {
            Console.WriteLine("Insert country: ");
            string country = Console.ReadLine();
            
            string text;
            List<Observation> obs = new List<Observation>();
            
            var request = WebRequest.Create(url + placesParams);
            request.ContentType = "application/json; charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();
            List<Place> places;
            Place countrySelected = new Place();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
                places = JsonConvert.DeserializeObject<List<Place>>(text);
                
                foreach(Place place in places)
                {
                    if(place.name == country)
                    {
                        countrySelected = place;
                    }
                }
            }
            int page = 0;
            while (true)
            {
                request = WebRequest.Create(url + observationParams + "&swlat=" + countrySelected.swlat + "&swlng=" + countrySelected.swlng + "&nelat=" + countrySelected.nelat + "&nelng=" + countrySelected.nelng + "&page=" + page);
                request.ContentType = "application/json; charset=utf-8";
                response = (HttpWebResponse)request.GetResponse();


                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                    List<Observation> tmp = JsonConvert.DeserializeObject<List<Observation>>(text);
                    obs.AddRange(tmp);

                }
                page++;
            }
            
            


        }
    }
}
