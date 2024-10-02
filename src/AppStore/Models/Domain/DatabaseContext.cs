using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Models.Domain;

public class DatabaseContext : IdentityDbContext<ApplicationUser> //Se convierte en una instancia de EFC
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) //Constructor que solicita la cadena de conexion
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder) //Permite definir configuracion de las entidades
    {
        base.OnModelCreating(builder);

        builder.Entity<Libro>() //Comienzo por la entidad libro
            .HasMany(x => x.CategoriaRelationList) //Tiene muchas categorias
            .WithMany(y => y.LibroRelationList) //Con muchos libros
            .UsingEntity<LibroCategoria>( //Usa libro categoria como entidad intermedia por la relacion muchos a muchos
              j => j //Representa a una instancia de libro categoria
              .HasOne(p => p.Categoria) //Ancla de categoria
              .WithMany(p => p.LibroCategoriaRelationList)
              .HasForeignKey(p => p.CategoriaId),

              j => j
              .HasOne(p => p.Libro) //Ancla de libro
              .WithMany(p => p.LibroCategoriaRelationList)
              .HasForeignKey(p => p.LibroId),

              j =>
              {
                j.HasKey(t => new {t.LibroId, t.CategoriaId}); //Clave primaria
              } 
            );
    }

    public DbSet<Categoria>? Categorias {get; set;} //Entidad de categorias (siempre en plural por convencion)
    public DbSet<Libro>? Libros {get; set;} //Entidad de libros (siempre en plural por convencion)
    public DbSet<LibroCategoria>? LibroCategorias {get; set;} //Entidad de librocategoria (siempre en plural por convencion)
}