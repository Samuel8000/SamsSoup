using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Auth
{
    public static class SamsSoupClaimTypes
    {
        public static List<string> ClaimsList { get; set; } = new List<string> { "Delete Soup", "Add Soup", "Age for ordering" };
    }
}
