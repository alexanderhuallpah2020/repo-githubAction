using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class DocumentoOrigenDetalle
    {
        public string EMPRE_C_CODIGO { get; set; }
        public string REGIME_C_CODIGO { get; set; }
        public string RECA_C_NUMERO { get; set; }
        public string PUERTO_C_CODIGO_ORIGEN { get; set; }
        public string PUERTO_C_CODIGO_EMBARQUE { get; set; }
        public string TIPDOC_C_CODIGO { get; set; }
        public string CONEMB_C_NUMERO { get; set; }
        public short COEMDE_C_NUMERO_ITEM { get; set; }
        public string PAIS_C_CODIGO_ORIGEN { get; set; }
        public string COEMDE_C_DIR_INDIR { get; set; }
        public string TIPEMB_C_CODIGO_MANIFESTADO { get; set; }
        public string TIPCAR_C_CODIGO_MANIFESTADO { get; set; }
        public string CARGA_C_CODIGO_MANIFESTADO { get; set; }
        public Nullable<decimal> COEMDE_C_CANTIDAD_MANIFESTADA { get; set; }
        public Nullable<decimal> COEMDE_C_PESO_MANIFESTADA { get; set; }
        public Nullable<decimal> COEMDE_C_VOLUMEN_MANIFESTADA { get; set; }
        public string TIPEMB_C_CODIGO_RECEPCIONADO { get; set; }
        public string TIPCAR_C_CODIGO_RECEPCIONADO { get; set; }
        public string CARGA_C_CODIGO_RECEPCIONADO { get; set; }
        public Nullable<decimal> COEMDE_C_CANTIDAD_RECEPCIONADO { get; set; }
        public Nullable<decimal> COEMDE_C_PESO_RECEPCIONADO { get; set; }
        public Nullable<decimal> COEMDE_C_VOLUMEN_RECEPCIONADO { get; set; }
        public string TIPEMB_C_CODIGO_DESPACHADO { get; set; }
        public string TIPCAR_C_CODIGO_DESPACHADO { get; set; }
        public string CARGA_C_CODIGO_DESPACHADO { get; set; }
        public Nullable<decimal> COEMDE_C_CANTIDAD_DESPACHADO { get; set; }
        public Nullable<decimal> COEMDE_C_PESO_DESPACHADO { get; set; }
        public Nullable<decimal> COEMDE_C_VOLUMEN_DESPACHADO { get; set; }
        public string TIPEMB_C_CODIGO_AFACTURAR { get; set; }
        public string TIPCAR_C_CODIGO_AFACTURAR { get; set; }
        public string CARGA_C_CODIGO_AFACTURAR { get; set; }
        public Nullable<decimal> COEMDE_C_CANTIDAD_FACTURADO { get; set; }
        public Nullable<decimal> COEMDE_C_PESO_FACTURADO { get; set; }
        public Nullable<decimal> COEMDE_C_VOLUMEN_FACTURADO { get; set; }
        public Nullable<int> COEMDE_C_CANTIDAD_INMOVILIZADO { get; set; }
        public Nullable<int> COEMDE_C_PESO_INMOVILIZADO { get; set; }
        public Nullable<int> COEMDE_C_VOLUMEN_INMOVILIZADO { get; set; }
        public Nullable<int> COEMDE_C_CANTIDAD_WARRANTED { get; set; }
        public Nullable<int> COEMDE_C_PESO_WARRANTED { get; set; }
        public Nullable<int> COEMDE_C_VOLUMEN_WARRANTED { get; set; }
        public Nullable<int> COEMDE_C_CANTIDAD_FISICO { get; set; }
        public Nullable<int> COEMDE_C_PESO_FISICO { get; set; }
        public Nullable<int> COEMDE_C_VOLUMEN_FISICO { get; set; }
        public Nullable<decimal> COEMDE_C_CANTIDAD_SALDO { get; set; }
        public Nullable<decimal> COEMDE_C_PESO_SALDO { get; set; }
        public Nullable<int> COEMDE_C_VOLUMEN_SALDO { get; set; }
        public Nullable<decimal> COEMDE_C_CANTIDAD_UNIDAD { get; set; }
        public Nullable<decimal> COEMDE_C_PESO_UNIDAD { get; set; }
        public Nullable<int> COEMDE_C_VOLUMEN_UNIDAD { get; set; }
        public string COEMDE_C_UNIDAD_FACTURADA { get; set; }
        public Nullable<System.DateTime> COEMDE_C_FECHA_INGRESO { get; set; }
        public Nullable<System.DateTime> COEMDE_C_FECHA_ULTIMA_SALIDA { get; set; }
        public string COEMDE_C_OBSERVACION { get; set; }
        public string COEMDE_C_MARCAS_NUMEROS { get; set; }
        public string COEMDE_C_DESCRIPCION_MERC { get; set; }
        public string COEMDE_C_CON_EMB_PADRE { get; set; }
        public Nullable<int> COEMDE_C_CON_EMB_PADRE_IT { get; set; }
        public Nullable<int> ROL_C_CODIGO_DESPACHADOR { get; set; }
        public Nullable<int> PERSONA_C_CODIGO_DESPACHADOR { get; set; }
        public int COEMDE_C_INDICADOR_AUTOMATICO { get; set; }
        public Nullable<int> COEMDE_C_INDICADOR_INMOVILIZAD { get; set; }
        public Nullable<int> COEMDE_C_INDICADOR_WARANTED { get; set; }
        public string COEMDE_C_INDICADOR_MER_PEL { get; set; }
        public string COEMDE_C_INDICADOR_REFRIGERADA { get; set; }
        public int COEMDE_C_IND_CONTENEDOR { get; set; }
        public int COEMDE_C_ENVIO_ADUANA { get; set; }
        public int COEMDE_C_VALIDAR_X_CANTIDAD { get; set; }
        public Nullable<int> ROL_C_CODIGO_AG_VOL { get; set; }
        public Nullable<int> PERSONA_C_CODIGO_AG_VOL { get; set; }
        public string COEMDE_C_NUMERO_ORDEN_EMB { get; set; }
        public Nullable<System.DateTime> COEMDE_C_FECHA_ORDEMB { get; set; }
        public string COEMDE_C_IDENTIFICACION_MFTDO { get; set; }
        public string COEMDE_C_NUMERO_SERIE1_MFTDO { get; set; }
        public Nullable<decimal> COEMDE_C_CANTIDAD_COMPROMETIDO { get; set; }
        public Nullable<decimal> COEMDE_C_PESO_COMPROMETIDO { get; set; }
        public Nullable<decimal> COEMDE_C_VOLUMEN_COMPROMETIDO { get; set; }
        public int COEMDE_C_CANTIDAD_TRANSITO { get; set; }
        public Nullable<int> COEMDE_C_PESO_TRANSITO { get; set; }
        public Nullable<int> COEMDE_C_VOLUMEN_TRANSITO { get; set; }
        public string CONTEN_C_CODIGO { get; set; }
        public Nullable<int> COEMDE_C_TEMPERATURA { get; set; }
        public int COEMDE_C_VENTILACION { get; set; }
        public string USUA_C_CODIGO { get; set; }
        public Nullable<System.DateTime> COEMDE_C_FECHA_USUARIO { get; set; }
        public string USUA_C_CODIGO_MOD { get; set; }
        public Nullable<System.DateTime> COEMDE_C_FECHA_USUARIO_MOD { get; set; }
        public long CONEMB_C_INTERNO { get; set; }
        public string TIPEMB_C_CODIGO_CONTENEDORIZADA { get; set; }
        public string TIPCAR_C_CODIGO_CONTENEDORIZADA { get; set; }
        public string CARGA_C_CODIGO_CONTENEDORIZADA { get; set; }
        public Nullable<decimal> COEMDE_C_CANTIDAD_CONTENEDORIZADA { get; set; }
        public Nullable<int> COEMDE_C_INDICADOR_ENSAQUE { get; set; }
        public Nullable<int> COEMDE_C_CANTIDAD_MAL_ESTADO { get; set; }
        public Nullable<int> COEMDE_C_PESO_MAL_ESTADO { get; set; }
        public Nullable<int> COEMDE_C_ACTA_INVENTARIO { get; set; }
    }

}
