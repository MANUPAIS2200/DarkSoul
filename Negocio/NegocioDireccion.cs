using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioDireccion
    {
        public void agregar(Direccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values(" + "'" + nuevo.IDCiudad + "'" + ", '" + nuevo.IDProvincia + "'" + ", '" + nuevo.Calle + "'" + ", '" + nuevo.Numeracion + "'" + ", '" + nuevo.Depto + "'" + ", '" + nuevo.Piso + "'" + ", '" + nuevo.CP + "')";
                datos.setearConsulta("insert into Direcciones (IDCiudad, IDProvincia, Calle, Numeracion, Depto, Piso, CP)" + valores);
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

        public void modificar(Direccion direccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Direcciones SET IDCiudad = @IDCiudad, IDProvincia = @IDProvincia, Calle = @Calle, Numeracion = @Numeracion, Depto = @Depto, Piso = @Piso, CP = @CP WHERE ID = @id");
                datos.agregarParametro("@IDCiudad", direccion.IDCiudad);
                datos.agregarParametro("@IDProvincia", direccion.IDProvincia);
                datos.agregarParametro("@Calle", direccion.Calle);
                datos.agregarParametro("@Numeracion", direccion.Numeracion);
                datos.agregarParametro("@Depto", direccion.Depto);
                datos.agregarParametro("@Piso", direccion.Piso);
                datos.agregarParametro("@CP", direccion.CP);
                datos.agregarParametro("@id", direccion.ID);
                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearIDDireccion(int IDUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Usuarios SET IDDireccion = SCOPE_IDENTITY() WHERE ID = @id");
                datos.agregarParametro("@id", IDUsuario);
                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int buscarIDCiudad(string ciudad)
        {
            int IDCiudad;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID FROM Ciudades WHERE Descripcion = @ciudad;");
                datos.agregarParametro("@ciudad", ciudad);
                datos.ejecutarLectura();
                datos.Lector.Read();
                IDCiudad = (int)datos.Lector["ID"];
                return IDCiudad;
                
                
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

        public int buscarIDProvincia(string provincia)
        {
            int IDProvincia;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID FROM Provincias WHERE Descripcion = @provincia;");
                datos.agregarParametro("@provincia", provincia);
                datos.ejecutarLectura();
                datos.Lector.Read();
                IDProvincia = (int)datos.Lector["ID"];
                return IDProvincia;
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

        public Direccion buscarxid(int idDireccion)
        {
            Direccion direccion = new Direccion();
            
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, IDCiudad, IDProvincia, Calle, Numeracion, Depto, Piso, CP FROM Direcciones WHERE ID = @id;");
                datos.agregarParametro("@id", idDireccion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    direccion = new Direccion
                    {
                        ID = (int)datos.Lector["ID"],
                        IDCiudad = (int)datos.Lector["IDCiudad"],
                        IDProvincia = (int)datos.Lector["IDProvincia"],
                        Calle = (string)datos.Lector["Calle"],
                        Numeracion = (int)datos.Lector["Numeracion"],
                        Depto = (string)datos.Lector["Depto"],
                        Piso = (string)datos.Lector["Piso"],
                        CP = (string)datos.Lector["CP"],
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

            return direccion;
        }

        public string buscarCiudad(int id)
        {
           string Ciudad;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Descripcion FROM Ciudades WHERE ID = @id;");
                datos.agregarParametro("@id", id);
                datos.ejecutarLectura();
                datos.Lector.Read();
                Ciudad = (string)datos.Lector["Descripcion"];
                return Ciudad;
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

        public string buscarProvincia(int id)
        {
            string Provincia;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Descripcion FROM Provincias WHERE ID = @id;");
                datos.agregarParametro("@id", id);
                datos.ejecutarLectura();
                datos.Lector.Read();
                Provincia = (string)datos.Lector["Descripcion"];
                return Provincia;
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
