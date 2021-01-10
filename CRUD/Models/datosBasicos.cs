using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public abstract class datosBasicos
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression("[a-zA-Z]{3,60}", ErrorMessage = "Ingrese el nombre sin espacios y sin números")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "El campo debe tener minimo 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Tipo Doc")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(9999999, 9000000000, ErrorMessage = "El número de documento no es valido")]
        [Display(Name = "Número Doc")]
        public int NumDocumento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Tipo Vehiculo")]
        public string TipoVehiculo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression("[a-zA-Z]{3}[0-9]{3}|[a-zA-Z]{3}[0-9]{2}[a-zA-Z]", ErrorMessage = "Formato de placa invalido")]
        [Display(Name = "Placa Vehiculo")]
        public string PlacaVehiculo { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }
    }
}