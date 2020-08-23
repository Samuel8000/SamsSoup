﻿using SamsSoup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsSoup.Data.Interfaces
{
    public interface ISoupRepository
    {
        IEnumerable<Soup> AllSoups { get; }
        IEnumerable<Soup> SoupsOfTheWeek { get; }
        Soup GetSoupById(int soupId);
    }
}