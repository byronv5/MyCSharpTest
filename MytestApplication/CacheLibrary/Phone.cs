using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CacheLibrary
{
    public class Phone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        /// <summary>
        /// 厂商
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// 机主
        /// </summary>
        public Person Owner { get; set; }
    }
}
