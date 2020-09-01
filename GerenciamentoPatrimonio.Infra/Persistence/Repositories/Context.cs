using GerenciamentoPatrimonio.Dominio.Entidades;
using System.Data.Entity;

namespace GerenciamentoPatrimonio.Infra
{
    public class Context : DbContext
    {
        public Context() : base("GerenciamentoPatrimonioConnectionString") { }
        public DbSet<Patrimonio> Patrimonio { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.AddFromAssembly(typeof(Context).Assembly);
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);

        }


    }
}
