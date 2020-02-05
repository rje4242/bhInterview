using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bhinterview
{
    public class Reason
    {
        private string text;

        private static int count = 0;

        public Reason(string text)
        {
            count++;
            this.text = text;
        }

        public Reason()
        {
            count++;
        }

        public int instanceCount
        {
            get { return count; }
        }
        

        public string Text
        {
            get { return text; }
            set
            {
                if (value.Length < 4)
                {
                    throw new Exception("Text for reason must be longer than four characters.");
                }
                text = value;
            }
        }
    }


    public class ApplicantDatabaseRepresentation
    {
        public int applicantId { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public virtual ICollection<ReasonDatabaseRepresentation> Reasons { get; set; }
    }

    
}
