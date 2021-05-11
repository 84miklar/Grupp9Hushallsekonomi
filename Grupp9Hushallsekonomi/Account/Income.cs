using Grupp9Hushallsekonomi.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp9Hushallsekonomi
{
    public class Income : IAccount
    {
        public double Money { get; set; }
        public string Name { get; set; }
    }
}
