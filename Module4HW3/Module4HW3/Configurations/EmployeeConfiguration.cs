using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Module4HW3.Entities;

namespace Module4HW3.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(e => e.EmployeeId);
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.HiredDate).IsRequired().HasColumnType("date");
            builder.Property(e => e.OfficeId).IsRequired();
            builder.Property(e => e.TitleId).IsRequired();

            builder.HasOne(e => e.Title)
                .WithMany(t => t.Employees)
                .HasForeignKey(f => f.TitleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Office)
                .WithMany(o => o.Employees)
                .HasForeignKey(f => f.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
