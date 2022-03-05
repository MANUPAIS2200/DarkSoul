using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;

namespace Negocio
{
   public class NegocioProducto
    {

        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            List<Imagen> listaimagen = new List<Imagen>();

            AccesoDatos datos = new AccesoDatos();
            NegocioImagen negocioImagen = new NegocioImagen();
            try
            {
                datos.setearConsulta("SELECT ID, Nombre, IDCategoria ,IDSubCategoria,FechaCarga , Precio, Stock, Descripcion, Marca FROM Producto WHERE baja=0;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new Producto
                    {
                         
                        ID = (int)datos.Lector["ID"],
                        Nombre = (string)datos.Lector["Nombre"],
                        IDCategoria = (int)datos.Lector["IDCategoria"],
                        IDSubCategoria = (int)datos.Lector["IDSubCategoria"],
                        FechaCarga = (DateTime)datos.Lector["FechaCarga"],
                        Precio = (decimal)datos.Lector["Precio"],
                        Stock = (int)datos.Lector["Stock"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        IDMarca = (int)datos.Lector["Marca"],
                        

                    };
                    aux.Items = negocioImagen.listar(aux.ID);
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

        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values(" + "'" + nuevo.Nombre + "'" + "', " + nuevo.IDCategoria + ", " + nuevo.IDCategoria + ", '" + nuevo.Precio + "','" + nuevo.Stock + "','" + nuevo.Descripcion + "', " + nuevo.IDMarca + ")";
                datos.setearConsulta("insert into Producto (Nombre, IDCategoria, IDSubCategoria, Precio, Stock, Descripcion , Marca )" + valores);
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

        public void modificar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Producto SET Nombre= '" + nuevo.Nombre + "', IDCategoria= " + nuevo.IDCategoria + ", IDSubCategoria= " + nuevo.IDSubCategoria + ", Precio= '" + nuevo.Precio + "', Stock= " + nuevo.Stock + ", Descripcion= '" + nuevo.IDSubCategoria + "', Marca= " + nuevo.IDMarca + " WHERE ID= '" + nuevo.ID + "'");
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
                datos.setearConsulta("UPDATE Producto SET baja = 1 Where Id = " + id);
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

    }
}
