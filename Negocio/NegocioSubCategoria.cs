using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
   public class NegocioSubCategoria
    {


        public List<SubCategoria> listarxCategoria(int categoria)
        {
            List<SubCategoria> lista = new List<SubCategoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, IDCategoria, Descripcion FROM SubCategorias where= " + categoria+";");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new SubCategoria
                    {
                        ID = (int)datos.Lector["ID"],
                        IDCategoria = (int)datos.Lector["IDCategoria"],
                        Descripcion = (string)datos.Lector["Descripcion"],


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

        public void agregar(SubCategoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values( "+nuevo.IDCategoria + ",'" + nuevo.Descripcion + "')";
                datos.setearConsulta("insert into SubCategorias (IDCategoria, Descripcion)" + valores);
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

        public void modificar(SubCategoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update SubCategorias SET Descripcion= '" + nuevo.Descripcion + "'");
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
                datos.setearConsulta("Delete From SubCategorias Where Id = " + id);
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

        public string descripcionxid(int id)
        {
            string descripcion = null;
            List<SubCategoria> lista = new List<SubCategoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, Descripcion FROM SubCategorias;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new SubCategoria
                    {
                        ID = (int)datos.Lector["ID"],
                        Descripcion = (string)datos.Lector["Descripcion"],

                    };

                    lista.Add(aux);
                }
                foreach (SubCategoria item in lista)
                {
                    if (id == item.ID)
                        return item.Descripcion;
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
            return descripcion;
        }

    }
}
