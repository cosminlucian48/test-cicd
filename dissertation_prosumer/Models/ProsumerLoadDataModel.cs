﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace dissertation_prosumer
{
    public class ProsumerLoadDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int ProsumerId { get; set; }
        public string Time { get; set; }
        public double Load { get; set; }
        public override string ToString()
        {
            return $"ProsumerId: {ProsumerId}, Time: {Time}, Load: {Load}";
        }
    }
}
