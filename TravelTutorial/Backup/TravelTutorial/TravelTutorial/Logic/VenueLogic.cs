using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelTutorial.Models;

namespace TravelTutorial.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Venue>> GetVenuesAsync(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenerateURL(latitude, longitude);

            using(HttpClient client = new HttpClient())
            {
                //json content from the api (rest service)
                var response = await client.GetAsync(url);
                //get the json string from the response variable
                var json = await response.Content.ReadAsStringAsync();

                //deserialises the json against the C# objects
                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);
                string theshortname = venueRoot.response.venues[0].location.city;

                venues = venueRoot.response.venues as List<Venue>;
            }

            return venues;

        }
    }
}
