using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlazingPizza.Shared
{
    public class Address
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo nombre es requerido"),
            MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Complete la direccion"),
            MaxLength(100)] 
        public string Line1 { get; set; }
        [MaxLength(100, ErrorMessage = "No se puede esceder de 100 caracteres")]
        public string Line2 { get; set; }
        [Required(ErrorMessage ="Ciudad no indicada"), MaxLength(50)] 
        public string City { get; set; }
        [Required(ErrorMessage = "Estado no indicado"), MaxLength(20)] 
        public string Region { get; set; }
        [Required(ErrorMessage ="Falta el codigo postal"), MaxLength(20)] 
        public string PostalCode { get; set; }
    }
}
