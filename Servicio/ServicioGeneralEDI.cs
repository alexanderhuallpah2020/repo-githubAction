using SRV_EdiFileService.Servicio.BE.Config;
using SRV_EdiFileService.Servicio.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio
{
    internal class ServicioGeneralEDI
    {
        private ConfigBE config;
        private ProcesarEDI proceso;
        public ServicioGeneralEDI(ConfigBE _config)
        {
            config = _config;
            proceso = new ProcesarEDI(config);
        }


        public string ProcesarArchivosEDI()
        {
            StringBuilder result = new StringBuilder();
            //ValidarCarpetas();

            //result.AppendLine(proceso.Procesar());

            return result.ToString();
        }
    }
}
