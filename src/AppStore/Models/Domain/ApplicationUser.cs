using Microsoft.AspNetCore.Identity;

namespace AppStore.Models.Domain;

//Clase que representa a los usuarios de mi aplicacion
public class ApplicationUser : IdentityUser
{
    public string? Nombre {get; set;}
}