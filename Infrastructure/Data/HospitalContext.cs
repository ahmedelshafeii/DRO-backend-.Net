using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HospitalContext : IdentityDbContext<User>
    {
        public HospitalContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<CenterPhone>().HasKey(k => new { k.CenterId, k.Phone });
            builder.Entity<Center_doctor>().HasKey(k => new { k.CenterId, k.DoctorId });
            builder.Entity<CenterInsurance>().HasKey(k => new {k.CenterId,k.InsuranceCompany});
            builder.Entity<CenterSpeciality>().HasKey(k => new {k.CenterId,k.Speciality});
            builder.Entity<WeekDays>().HasKey(k => new {k.Day,k.StartTime,k.EndTime});
            builder.Entity<Doctor>()
                .HasMany(m => m.CentersManage).WithOne().OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(f => f.DocAdminId);
           
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Center> Centers { get; set; }
        public virtual DbSet<Center_doctor> Center_Doctors { get; set; }
        public virtual DbSet<CenterPhone> Center_Phones { get; set; }
        public virtual DbSet<CenterInsurance> Center_Insurances { get; set; }
        public virtual DbSet<CenterSpeciality> Center_Specialities { get; set; }
        public virtual DbSet<WeekDays> WeekDays { get; set; }




    }
}
