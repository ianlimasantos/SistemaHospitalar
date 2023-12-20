﻿using Cadastro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Data.EF.Maps
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(x=> x.Id);

            builder.Property(x => x.CRM)
                .IsRequired();

            builder.Property(x => x.Especialidade)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Telefone)
                .IsRequired();

            builder.HasMany(x => x.EnderecoConsultorios)
                .WithOne(x => x.Medico)
        }
    }
}