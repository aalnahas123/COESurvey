using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COE.Common.Model.IntegrationServicesModels
{
    public class SarasUserViewModel
    {
        //[JsonProperty("User_id")]
        //public string User_Id { get; set; }

        [JsonProperty("user_code")]
        public string User_Code { get; set; }

        [JsonProperty("organization_code")]
        public string Organization_Code { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; } = "Student";

        [JsonProperty("password")]
        public string Password { get; set; }

        //public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }

        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("loginName")]
        public string LoginName { get; set; }

        [JsonProperty("photopath")]
        public string PhotoPath { get; set; }

        [JsonProperty("Qualification")]
        public string Qualification { get; set; }

        [JsonProperty("YearsOfExperience")]
        public int YearsOfExperience { get; set; } = 0;
    }
}
