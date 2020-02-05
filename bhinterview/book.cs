using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bhinterview
{

    public class Book //: DatabaseObject
    {
        public string Title { get; set; }
        public virtual Publisher Publisher { get; set; }
    }

    public class Publisher //: DatabaseObject
    {
        public int publisherId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

}
