using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EntityFramework.Configuration
{
    public class LoteConfiguration : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            //qual a primary key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(); //o id vai ser auto incrementar
            builder.Property(x => x.CodigoLote).IsRequired(); //
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.Fabricacao);
            builder.Property(x => x.Validade).IsRequired();

            //explica a relação entre Lote e Produto
            builder.HasOne(x => x.Produto).WithMany(p => p.Lotes).HasForeignKey(x => x.idProduto);
    }

    }
}
