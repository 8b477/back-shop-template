﻿namespace BLL_Shop.JWT.Models
{
#nullable disable
    public class JWTSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int DurationInMinutes { get; set; }
    }
#nullable enable
}
