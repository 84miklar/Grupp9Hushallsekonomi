using Grupp9Hushallsekonomi.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp9Hushallsekonomi.Account
{
    public class Outcome : IAccount
    {
        public double Money { get; set; }
        public string Name { get; set; }
    }
}
