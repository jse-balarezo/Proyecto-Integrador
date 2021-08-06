using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrador.Entities
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string Nombre { get; set; }
        public int NumeroGigas { get; set; }
        public float Valor { get; set; }
        public Usuario Usuario { get; set; }
    }
}
