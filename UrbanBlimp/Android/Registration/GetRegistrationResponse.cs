using System;
using System.Collections.Generic;

namespace UrbanBlimp.Android
{
    public class GetRegistrationResponse
    {
        public string Alias;
        public List<string> Tags;
        public DateTime Created;
        public bool Active;
    }
}