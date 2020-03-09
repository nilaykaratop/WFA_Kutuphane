using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_Kutuphane
{
    class Kutuphane
    {
        public string kitapadi;
        public string yazaradi;
        public string yayinevi;
        public int isbnNo;



        public override string ToString()
        {
            return this.kitapadi + "-" + this.yazaradi;
        }
    }
}
