using BaseballDB;
using StatsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI
{
    public static class DataContext
    {
        public static BaseballDatabase BaseballDatabase = new BaseballDatabase("Resources\\CSVs");
    }
}
