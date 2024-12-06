using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace AmazonReviewGenerator.Services
{
    public static class JsonCleaner
    {
        public static string CleanJson(string json)
        {
            // Remove the colons in keys (like "Size:" -> "Size")
            return Regex.Replace(json, @"\""([a-zA-Z0-9\s]+):\""", @"\""$1\"":");
        }
    }
}
