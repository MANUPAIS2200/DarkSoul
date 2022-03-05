using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
   public class NegocioCostoEnvio
    {

        public List<CostoEnvio> listar()
        {
            List<CostoEnvio> lista = new List<CostoEnvio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, Zona, Precio FROM CostosDeEnvio WHERE baja=0;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new CostoEnvio
                    {
                        ID = (int)datos.Lector["ID"], 
                        Zona = (int)datos.Lector["Zona"],
                        Precio = (decimal)datos.Lector["Precio"],
                    };

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(CostoEnvio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values(" + "'" + nuevo.Precio + "'" + ", '" + nuevo.Zona + "')";
                datos.setearConsulta("insert into CostosDeEnvio (Precio, Zona)" + valores);
                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(CostoEnvio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update CostosDeEnvio SET Zona= '" + nuevo.Zona + "', Precio= '" + nuevo.Precio + "' WHERE ID= '" +nuevo.ID + "'" );
                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE CostosDeEnvio SET baja = 1 Where Id = " + id);
                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int zonaxid(int id)
        {
            int zona = 0;
            List<CostoEnvio> lista = new List<CostoEnvio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, Zona, Precio FROM CostosDeEnvio WHERE baja=0;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new CostoEnvio
                    {
                        ID = (int)datos.Lector["ID"],
                        Zona = (int)datos.Lector["Zona"],
                        Precio = (decimal)datos.Lector["Precio"],
                    };

                    lista.Add(aux);
                }
                foreach (CostoEnvio item in lista)
                {
                    if (id == item.ID)
                        return item.Zona;

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

            return zona;
        }
        public int getcostoxidprovincia(int id)
        {
            int costo = 0;




            return costo;
        }

        public CostoEnvio buscarxid(int IDCostoEnvio)
        {
            CostoEnvio costoEnvio = new CostoEnvio();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, Zona, Precio FROM  CostosDeEnvio where baja=0 and ID= " + IDCostoEnvio);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    costoEnvio = new CostoEnvio
                    {
                        ID = (int)datos.Lector["ID"],
                        Zona = (int)datos.Lector["Zona"],
                        Precio = (decimal)datos.Lector["Precio"],
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

            return costoEnvio;
        }
    }
}

