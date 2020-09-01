using GerenciamentoPatrimonio.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GerenciamentoPatrimonio.Infra.Repositories.Map
{
    public class MapPatrimonio : EntityTypeConfiguration<Patrimonio>
    {
        public MapPatrimonio()
        {
            ToTable("patrimonio");
            HasKey(p => p.Id);
                            
        }
    }
}
