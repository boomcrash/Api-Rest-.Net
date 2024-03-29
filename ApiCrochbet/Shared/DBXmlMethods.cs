﻿using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ApiCrochbet.Shared
{
    public static class DBXmlMethods
    {
        public static XDocument GetXml<T>(T criterio)
        {
            XDocument resultado = new XDocument(new XDeclaration("1.0","utf-8","true"));
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using XmlWriter xw = resultado.CreateWriter();
                xs.Serialize(xw, criterio);
                return resultado;
            }catch(Exception e)
            {
                return null;
            }
        }


        public static async Task<DataSet> EjecutaBase(string nombreProcedimiento,string cadenaConexion,string proceso,string dataXml)
        {
            DataSet dsResultado = new DataSet();
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adt = new SqlDataAdapter();
                cmd.CommandText = nombreProcedimiento;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                cmd.CommandTimeout = 120;
                cmd.Parameters.Add("@iTransaccion", SqlDbType.VarChar).Value = proceso;
                cmd.Parameters.Add("@iXml", SqlDbType.Xml).Value = dataXml.ToString();
                await cnn.OpenAsync().ConfigureAwait(false);
                adt = new SqlDataAdapter(cmd);
                adt.Fill(dsResultado);
                cmd.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine("error Base",e.ToString());

            }
            finally{
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return dsResultado;
        }
    }
}
