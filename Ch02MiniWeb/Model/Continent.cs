﻿using System.ComponentModel;

namespace Ch02MiniWeb.Model
{
    public enum Continent
    {
        Unknown = 0,
        Europe = 1,
        Asia = 2,
        [Description("North America")]
        NorthAmerica = 3,
        [Description("South America")]
        SouthAmerica = 4,
        Africa = 5,
        Oceania = 6,
        Antarctica = 7
    }
}