using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;
using System.Data.Entity;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace bhinterview
{        

    class Program
    {
        
        static void Main(string[] args)
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());

            List<Reason> twoReasons = new List<Reason>();
            twoReasons.Add(new Reason("I would like a software engineering job in the downtown Sacramento area."));
            twoReasons.Add(new Reason("I believe Berkshire Hathaway is a company where I can grow in my career."));

            Applicant me = new Applicant("Trevor", "Foley");
            me.AddReasons(twoReasons);
            me.AddReason("I hope to learn more about software development in my next career position.");

            InsertData(me);

            PrintData();

        }

        
        private static void InsertData(Applicant a)
        {
            using (var context = new ApplicantContext())
            {
                var applicant = new ApplicantDatabaseRepresentation
                {
                    First = a.FirstName,
                    Last = a.LastName
                };
                context.Applicant.Add(applicant);

                foreach (Reason r in a.Reasons) {
                    context.Reason.Add(new ReasonDatabaseRepresentation
                    {
                         ReasonText = r.Text,
                         Applicant = applicant
                    });
                }
                
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            using (var context = new ApplicantContext())
            {
                var reasons = context.Reason.Include(a => a.Applicant);
                foreach (var reason in reasons)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"My reason: {reason.ReasonText}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
        
    }
    

}
