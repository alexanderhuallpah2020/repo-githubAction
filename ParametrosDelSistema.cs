using Newtonsoft.Json;
using SRV_EdiFileService.Servicio.BE.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SRV_EdiFileService
{
    public static class ParametrosDelSistema
    {
        #region public static ServicioParametros ObtenerDatosDeConfiguracion()
        public static ConfigBE ObtenerDatosDeConfiguracion()
        {
            ConfigBE result = new ConfigBE();
            string path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            #region Cargamos variables
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                dynamic configuration = JsonConvert.DeserializeObject<dynamic>(json);

                /*
                * 
                *   C O N E X I O N    B A S E     D E     D A T O S
                * 
                */
                result.ConexionBaseDeDatos = (string)configuration.ConexionBaseDeDatos.NTC;

                /*
                 * 
                 *   R U T A 
                 * 
                 */

                result.Rutas_Base = (string)configuration.Ruta.Base;

                /*
                * 
                *   D E S T I N O
                * 
                */

                result.Rutas_Destino = (string)configuration.Ruta.Destino;

                /*
               * 
               *   S F T P
               * 
               */
                result.SFTP_Server = (string)configuration.SFTP.Server;
                result.SFTP_Usuario = (string)configuration.SFTP.Usuario;
                result.SFTP_Password = (string)configuration.SFTP.Password;

                /*
                * 
                *   MINUTOS DE ESPERA
                * 
                */
                result.Servicio_MinutosDeEspera = (int)(configuration.Servicio.MinutosDeEspera ?? "10");

            }
            #endregion
            return result;
        }
        #endregion
    }
}
