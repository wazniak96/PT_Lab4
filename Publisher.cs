using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PT_Lab4
{
    class Publisher
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Publisher() { }

        public Publisher(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
