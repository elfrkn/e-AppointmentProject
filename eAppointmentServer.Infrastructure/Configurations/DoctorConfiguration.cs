using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAppointmentServer.Infrastructure.Configurations
{
    internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");

            //Aynı ad-soyada sahip ikinci bir doktor olmasın diye 
            //builder.HasIndex(x => new { x.FirstName, x.LastName }).IsUnique();

            builder.Property(p => p.Department)
                .HasConversion(v => v.Value, v => DepartmentEnum.FromValue(v))
                .HasColumnName("Department");
        }
    }
}
