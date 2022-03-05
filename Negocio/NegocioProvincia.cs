using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProvincia
    {
        public Provincia buscarxid(int idProvincia)
        {
            Provincia provincia = new Provincia();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, IDCostoEnvio, Descripcion FROM Provincias where baja=0 and ID= " + idProvincia);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    provincia = new Provincia
                    {
                        ID = (int)datos.Lector["ID"],
                        IDCostoEnvio = (int)datos.Lector["IDCostoEnvio"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return provincia;
        }
    }
}
