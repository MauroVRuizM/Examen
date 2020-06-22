//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUExamen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Libro
    {

        [ScaffoldColumn(false)]
        public int idLibro { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El título es requerido"), MaxLength(55)]
        [Display(Name = "Título")]
        public string titulo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El autor(es) es requerido"), MaxLength(55)]
        [Display(Name = "Autor(es)")]
        public string autor { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El ISBN es requerido"), MaxLength(55)]
        [Display(Name = "ISBN")]
        public string isbn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "Fecha de Publicación")]
        public System.DateTime fecha_publicacion { get; set; }

        [DataType(DataType.Duration)]
        [Display(Name = "Número de ejemplares")]
        public int ejemplares { get; set; }

        [Display(Name = "Categoría")]
        public int idCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}