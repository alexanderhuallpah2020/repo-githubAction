using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Config
{
    public class ConfigBE
    {
        /* RUTA */
        public string Rutas_Base { get; set; }

        /* DESTINO */
        public string Rutas_Destino { get; set; }


        /* CONEXION SFTP */
        public string SFTP_Server { get; set; }
        public string SFTP_Usuario { get; set; }
        public string SFTP_Password { get; set; }

        /* CONEXION BD */
        public string ConexionBaseDeDatos { get; set; }

        /* MINUTOS DE ESPERA */
        public int Servicio_MinutosDeEspera { get; set; }

        public ConfigBE()
        {
            /* RUTA */
            Rutas_Base = string.Empty;

            /* DESTINO */
            Rutas_Destino = string.Empty;

            /* CONEXION SFTP */
            SFTP_Server = string.Empty;
            SFTP_Usuario = string.Empty;
            SFTP_Password = string.Empty;

            /* CONEXION BD */
            ConexionBaseDeDatos = string.Empty;

            /* MINUTOS DE ESPERA */
            Servicio_MinutosDeEspera = 10;

        }
    }
}
