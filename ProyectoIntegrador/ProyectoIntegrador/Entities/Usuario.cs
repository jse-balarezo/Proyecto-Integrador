using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrador.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [NotMapped]
        public string NombreCompleto { get { return $"{Nombre} {Apellido}"; } }
        public Operadora Operadora { get; set; }
        public List<Plan> Planes { get; set; }
    }
}
