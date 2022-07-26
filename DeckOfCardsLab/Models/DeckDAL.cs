using Newtonsoft.Json;
using System.Net;

namespace DeckOfCardsLab.Models
{
    public class DeckDAL
    {
        public DeckModel GetCards(string card) //adjust for a new api
        {
            //Adjust for a new api
            //api url
            string key = "9x0u2du1k22h";
            string url = $"https://deckofcardsapi.com/api/deck/{key}/draw/?count=5";

            //setup request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //save response data
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //adjust for a new api
            //convert JSON to a c# object
            DeckModel result = JsonConvert.DeserializeObject<DeckModel>(JSON);
            return result;
        }
    }
}
