using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tienda_Virtual.Models
{
    [Table("Categorias", Schema = "dbo")] //le decimos a visual que es tabla
    public class Categoria
    {

        //Constructor clase hija
        public Categoria()
        {


            this.Productos = new HashSet<Producto>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")] // es lo mismo que decir no acepta nulos
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El codigo debe de ser de 3 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo requerido")] // es lo mismo que decir no acepta nulos
        [StringLength(50, ErrorMessage = "La descripcion no  debe sobre pasar de 50 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        //Relacionar las clases.(Hija-padre)

        public virtual ICollection<Producto> Productos { get; set; }




    }
}