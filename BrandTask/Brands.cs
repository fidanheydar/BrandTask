using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandTask
{
    internal class Brands
    {
        public Brands()
        {
            _count++;
            Id=_count;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        private static int _count;

        public override string ToString()
        {
            return $"{Id}){Name} - {Year}";
        }
    }

}
