﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
     public class DBSetting : IDBSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IDBSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
