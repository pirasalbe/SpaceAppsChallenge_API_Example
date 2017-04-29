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
            Console.WriteLine("Insert year: ");
            string year = Console.ReadLine();
            Console.WriteLine("Insert month: ");
            string month = Console.ReadLine();
            Console.WriteLine("Insert day: ");
            string day = Console.ReadLine();

            string text;
            int page = 1;

            List<Observation> obs = new List<Observation>();
            List<Place> places = new List<Place>();
            Place countrySelected = new Place();
            bool end = true;
            while (end)
            {
                var request = WebRequest.Create(url + placesParams + "&page=" + page);
                request.ContentType = "application/json; charset=utf-8";

                var response = (HttpWebResponse)request.GetResponse();
                
                

                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                    List<Place> tmp = JsonConvert.DeserializeObject<List<Place>>(text);
                    if(tmp.Count == 0)
                    {
                        end = false;
                    }
                    places.AddRange(tmp); 

                    page++;
                }
            }
            

            foreach (Place place in places)
            {
                if (place.name == country)
                {
                    countrySelected = place;
                }
            }
            page = 0;
            
            
            while (true)
            {
                var request = WebRequest.Create(url + observationParams + "&swlat=" + countrySelected.swlat + "&swlng=" + countrySelected.swlng + "&nelat=" + countrySelected.nelat + "&nelng=" + countrySelected.nelng + "&page=" + page + "&year=" + year + "&month=" + month + "&day=" + day );
                request.ContentType = "application/json; charset=utf-8";
                var response = (HttpWebResponse)request.GetResponse();


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
