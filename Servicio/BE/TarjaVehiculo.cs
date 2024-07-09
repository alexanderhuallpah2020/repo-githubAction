using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class TarjaVehiculo
    {
        public string EmpresaId { get; set; }
        public int TarjaCodigo { get; set; }
        public int Anio { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public decimal Peso { get; set; }
        public decimal PesoBalanza { get; set; }
        public string NumeroSerie { get; set; }
        public string Marca { get; set; }
        public bool SiniestroEstado { get; set; }
        public bool OperacionEstado { get; set; }
        public string AudiUsuario { get; set; }
        public DateTime? AudiFecha { get; set; } = DateTime.Now;
    }
}
