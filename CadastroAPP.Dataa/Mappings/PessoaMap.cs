using CadastroAPP.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAPP.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            //nome tabela
            builder.ToTable("PESSOA");

            //campo chave primaria
            builder.HasKey(c => c.Id);

            //mapear os campos
            builder.Property(c => c.Id)
                .HasColumnName("ID"); //nome da coluna

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
