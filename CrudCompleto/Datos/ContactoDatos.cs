using CrudCompleto.Models;
using System.Data.SqlClient;
using System.Data;

namespace CrudCompleto.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarE", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            sueldos = dr["sueldos"].ToString(),
                            id_departamento = Convert.ToInt32(dr["id_departamento"]),
                            puesto = dr["puesto"].ToString(),
                            jerarquia = dr["jerarquia"].ToString(),
                            fecha_ingreso = dr["fecha_ingreso"].ToString(),
                            fecha_aumento = dr["fecha_aumento"].ToString(),
                            fecha_baja = dr["fecha_baja"].ToString(),
                        }); 
                    }
                }
                return oLista;
            }
        }

        public ContactoModel Obtener(int IdContacto)
        {
            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerE", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.sueldos = dr["sueldos"].ToString();
                        oContacto.id_departamento = Convert.ToInt32(dr["id_departamento"]);
                        oContacto.puesto = dr["puesto"].ToString();
                        oContacto.jerarquia = dr["jerarquia"].ToString();
                        oContacto.fecha_ingreso = dr["fecha_ingreso"].ToString();
                        oContacto.fecha_aumento = dr["fecha_aumento"].ToString();
                        oContacto.fecha_baja = dr["fecha_baja"].ToString();
                    }
                }
                return oContacto;
            }
        }





        public bool Guardar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarE", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("sueldos", ocontacto.sueldos);
                    cmd.Parameters.AddWithValue("id_departamento", ocontacto.id_departamento);
                    cmd.Parameters.AddWithValue("puesto", ocontacto.puesto);
                    cmd.Parameters.AddWithValue("jerarquia", ocontacto.jerarquia);
                    cmd.Parameters.AddWithValue("fecha_ingreso", ocontacto.fecha_ingreso);
                    cmd.Parameters.AddWithValue("fecha_aumento", ocontacto.fecha_aumento);
                    cmd.Parameters.AddWithValue("fecha_baja", ocontacto.fecha_baja);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }catch(Exception e){
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarE", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("sueldos", ocontacto.sueldos);
                    cmd.Parameters.AddWithValue("id_departamento", ocontacto.id_departamento);
                    cmd.Parameters.AddWithValue("puesto", ocontacto.puesto);
                    cmd.Parameters.AddWithValue("jerarquia", ocontacto.jerarquia);
                    cmd.Parameters.AddWithValue("fecha_ingreso", ocontacto.fecha_ingreso);
                    cmd.Parameters.AddWithValue("fecha_aumento", ocontacto.fecha_aumento);
                    cmd.Parameters.AddWithValue("fecha_baja", ocontacto.fecha_baja);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

       


    }
}
