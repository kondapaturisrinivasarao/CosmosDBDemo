using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmosDBExample1.Models
{
    public class Employee
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "department")]
        public string Department { get; set; }
        [JsonProperty(PropertyName = "isPermanent")]
        public bool IsPermanent { get; set; }
    }
}