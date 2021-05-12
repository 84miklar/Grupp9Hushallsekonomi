using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp9Hushallsekonomi.Interface
{
    public interface IAccount
    {
        /// <summary>
        /// värde i kronor
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// Namnet på transaktionen(?)
        /// </summary>
        public string Name { get; set; }
    }
}
