using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tienda_Virtual.Models
{
    [Table("Productos", Schema = "dbo"),]
    public class Producto
    {

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

        [Required(ErrorMessage = "Campo requerido")] // es lo mismo que decir no acepta nulos
        [DataType(DataType.Currency)]
        [Display(Name = "Precio")]
        public double Precio { get; set; }




        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }

        //Foreing key
        //[ForeignKey("CategoriaID")]
        [Display(Name = "Categoria ID")]
        public int CategoriaId { get; set; }



        //Relacionar categoria como clase padre
        public virtual Categoria categoria { get; set; }

    }
}