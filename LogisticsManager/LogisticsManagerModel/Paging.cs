﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagerModel
{
    public class Paging
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public string TableName { get; set; }
        public string PrimaryKey { get; set; }
        public string Condition { get; set; }
        public string Sort { get; set; }
        public string Fields { get; set; }
    }
}
