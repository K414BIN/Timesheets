using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Ef.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        void IEntityTypeConfiguration<Service>.Configure(EntityTypeBuilder<Service> builder)
        {
                       builder.ToTable("services");
        }
    }
}
