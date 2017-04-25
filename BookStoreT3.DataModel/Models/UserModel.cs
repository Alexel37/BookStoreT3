using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookStoreT3.DataModel.Models
{
    public class UserModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("first name")]
        public string FirstName { get; set; }

        [JsonProperty("last name")]
        public string LastName { get; set; }
    }
}
