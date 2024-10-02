using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppStore.Models.Domain;

public class Libro
{
    [Key] //Indica que va a ser clave unica primaria
    [Required] //Indica que no puede ser nula
    public int Id {get; set;}
    public string? Titulo {get; set;}
    public string? CreateDate {get; set;}
    public string? Imagen {get; set;}
    [Required]
    public string? Autor {get; set;}
    public virtual ICollection<Categoria>? CategoriaRelationList {get; set;} //Se crea una coleccion de categorias porque un libro puede tener muchas categorias
    public virtual ICollection<LibroCategoria>? LibroCategoriaRelationList {get; set;} //Se crea una coleccion de librocategorias porque un libro puede tener muchas LibroCategoria
    [NotMapped]
    public List<int>? Categorias {get; set;}
    [NotMapped]
    public string? CategoriasNames {get; set;}
    [NotMapped]
    public IFormFile? ImageFile {get; set;}
    [NotMapped]
    public IEnumerable<SelectListItem>? CategoriasList {get; set;}
    [NotMapped]
    public MultiSelectList? MultiCategoriasList {get; set;}

}