using GerenciamentoPatrimonio.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPatrimonio.Infra.Repositories.Map
{
    public class MapUsuario : EntityTypeConfiguration<Usuario>
    {
        public MapUsuario()
        {
            ToTable("usuario");
            HasKey(p => p.Id);
        }
    }
}
