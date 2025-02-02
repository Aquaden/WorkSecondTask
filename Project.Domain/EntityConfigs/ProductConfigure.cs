﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.EntityConfigs
{
    public class ProductConfigure : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.DeletedDate).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();
        }
    }
}
