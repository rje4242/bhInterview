using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;

namespace bhinterview
{
    class ApplicantContext : DbContext
    {
        public DbSet<ReasonDatabaseRepresentation> Reason { get; set; }
        public DbSet<ApplicantDatabaseRepresentation> Applicant { get; set; }

        const string addressDatabase = "database-1.cowbahg40izk.us-east-1.rds.amazonaws.com";
        const int portDatabase = 3306;
        const string passwordDatabase = "americanrivergold";
        const string userDatabase = "admin";
        const string databaseDatabase = "bhInterview";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=" + addressDatabase + ";user=" + userDatabase + ";database=" + databaseDatabase +
                ";port=" + portDatabase.ToString() + ";password=" + passwordDatabase);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicantDatabaseRepresentation>(entity =>
            {
                entity.HasKey(e => e.applicantId);
                entity.Property(e => e.First).IsRequired();
                entity.Property(e => e.Last).IsRequired();
            });

            modelBuilder.Entity<ReasonDatabaseRepresentation>(entity =>
            {
                entity.HasKey(e => e.reasonId);
                entity.Property(e => e.ReasonText).IsRequired();
                entity.HasOne(d => d.Applicant).WithMany(p => p.Reasons);
            });
        }


    }
}
