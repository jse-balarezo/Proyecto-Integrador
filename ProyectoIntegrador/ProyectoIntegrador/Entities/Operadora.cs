using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrador.Entities
{
    public class Operadora
    {
        public int OperadoraId { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Usuario")]
        [DisplayName("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
