﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BL.ModelsUI
{
    [Serializable]
    public class YearVal
    {
        public int Year { get; set; }
        public decimal? Value { get; set; }
        public decimal? Growth { get; set; }
    }
}
