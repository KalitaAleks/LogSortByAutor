using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSortByAutor
    {
    public class Commit
        {
        public string Autor { get; set; }
        public string Massage { get; set; }


        public Commit()
            {
            this.Autor = string.Empty;
       
            this.Massage = string.Empty;
            }
        }
    }
