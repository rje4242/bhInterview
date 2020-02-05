using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bhinterview
{
    public class Applicant
    {
        private string firstName ;
        private string lastName;
        private static int count = 0;
        private List<Reason> reasons ;

        public Applicant(string first, string last)
        {
            count++;
            FirstName = first;
            LastName = last;
            
        }

        public void AddReason(string r)
        {
            Reason a = new Reason(r);
            reasons.Add(a);
        }

        public void AddReasons(List <Reason> reasons)
        {
            this.reasons = reasons;
        }

        public Applicant()
        {
            count++;
        }

        public int instanceCount
        {
            get { return count; }
        }

        public List<Reason> Reasons
        {
            get { return reasons; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set {
                if(value.Length < 1)
                {
                    throw new Exception("Last name must be longer than one character.");
                }
                lastName = value;
            }
        }

        public override bool Equals(object other)
        {
            Applicant otherApplicant = (Applicant)other;

            if (otherApplicant.LastName == this.LastName &&
                    otherApplicant.FirstName == this.FirstName)
            {
                return true;

            }
            return false;
        }
    }

    public class ReasonDatabaseRepresentation
    {
        public int reasonId { get; set; }
        public string ReasonText { get; set; }
        public virtual ApplicantDatabaseRepresentation Applicant { get; set; }
    }

}
