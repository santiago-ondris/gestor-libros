using System.ComponentModel.DataAnnotations;


namespace AppStore.Models.Domain;

public class Categoria
{
    [Key]
    [Required]
    public int Id {get; set;}
    public string? Nombre {get; set;}
    public virtual ICollection<Libro>? LibroRelationList {get; set;} //Se crea una coleccion de librs porque una categoria puede tener muchos libros

    public virtual ICollection<LibroCategoria>? LibroCategoriaRelationList {get; set;} //Se crea una coleccion de librocategorias porque una categoria puede tener muchas LibroCategoria
}