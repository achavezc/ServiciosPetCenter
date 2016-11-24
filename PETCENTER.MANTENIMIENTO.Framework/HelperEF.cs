using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace PETCENTER.MANTENIMIENTO.Framework
{
    public class HelperEF
    {
        private Database ContextoDatabase;


      
        public HelperEF(Database ContextoDatabase)
        {
            this.ContextoDatabase = ContextoDatabase;
        }
        public List<T> EjecutarFuncionOProcedimiento<T>(string NombreFuncionOProcedimiento, List<InputEF> lstInputBD)
        {
            string querySQL = "";
            SqlParameter[] lstSqlParameter = GetInputSqlParameter(NombreFuncionOProcedimiento, lstInputBD, out querySQL);
            var queryResult = ContextoDatabase.SqlQuery<T>(
                   querySQL,
                   lstSqlParameter
                );

            var salida = queryResult.ToList();
            SetOutputSqlParameter(lstInputBD, lstSqlParameter);
            return salida;
        }
        public int EjecutarFuncionOProcedimiento(string NombreFuncionOProcedimiento, List<InputEF> lstInputBD)
        {
            string querySQL = "";
            SqlParameter[] lstSqlParameter = GetInputSqlParameter(NombreFuncionOProcedimiento, lstInputBD, out querySQL);
            
            var queryResult = ContextoDatabase.ExecuteSqlCommand(
                   querySQL,
                   lstSqlParameter
                );

            var salida = queryResult;
            SetOutputSqlParameter(lstInputBD, lstSqlParameter);
            return salida;
        }

        private void SetOutputSqlParameter(List<InputEF> lstInputBD, SqlParameter[] lstSqlParameter)
        {
            for (int i = 0; i < lstInputBD.Count; i++)
                if (lstInputBD[i].ParametroDireccionGrabado == ParameterDirection.Output)
                    lstInputBD[i].Valor = lstSqlParameter.ToList().Find(x => x.ParameterName == lstInputBD[i].NombreAtributo).Value;

        }
        private SqlParameter[] GetInputSqlParameter(string NombreFuncionOProcedimiento, List<InputEF> lstInputBD, out string querySQL)
        {
            SqlParameter[] lstSqlParameter = new SqlParameter[lstInputBD.Count];
            querySQL = NombreFuncionOProcedimiento + " ";
            for (int i = 0; i < lstInputBD.Count; i++)
            {
                var item = lstInputBD[i];
                querySQL = querySQL + item.NombreAtributo;
                if (item.ParametroDireccionGrabado == ParameterDirection.Output)
                    querySQL = querySQL + " OUTPUT";
                if (i < lstInputBD.Count - 1)
                    querySQL = querySQL + ", ";

                lstSqlParameter[i] = AgregarParametroBD(item);
            }
            return lstSqlParameter;
        }
        private SqlParameter AgregarParametroBD(
            InputEF inputBD
            )
        {
            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = inputBD.NombreAtributo,
                Value = (inputBD.Valor == null ? DBNull.Value : inputBD.Valor),
                DbType = inputBD.DbTipo
            };
            
            if (inputBD.SqlDbTipo.HasValue)
                parameter.SqlDbType = inputBD.SqlDbTipo.Value;


            parameter.Direction = inputBD.ParametroDireccionGrabado;
            if (inputBD.Tamaño != null)
                parameter.Size = inputBD.Tamaño.Value;
            if (inputBD.CantidadDecimales != null)
                parameter.Scale = inputBD.CantidadDecimales.Value;
            if (inputBD.TipoNombre != null)
                parameter.TypeName = inputBD.TipoNombre;
            return parameter;
        }


        private static DbType ConvertToDbType(Type t)
        {
            System.Collections.Hashtable dbTypeTable = new System.Collections.Hashtable();
            dbTypeTable.Add(typeof(System.Boolean), DbType.Boolean);
            dbTypeTable.Add(typeof(System.Int16), DbType.Int16);
            dbTypeTable.Add(typeof(System.Int32), DbType.Int32);
            dbTypeTable.Add(typeof(System.Int64), DbType.Int64);
            dbTypeTable.Add(typeof(System.Double), DbType.Double);
            dbTypeTable.Add(typeof(System.Decimal), DbType.Decimal);
            dbTypeTable.Add(typeof(System.String), DbType.String);
            dbTypeTable.Add(typeof(System.Char), DbType.String);
            dbTypeTable.Add(typeof(System.DateTime), DbType.DateTime);
            dbTypeTable.Add(typeof(System.Byte[]), DbType.Binary);
            dbTypeTable.Add(typeof(System.Guid), DbType.Guid);

            DbType dbtype;
            try
            {
                dbtype = (DbType)dbTypeTable[t];
            }
            catch
            {
                dbtype = DbType.Object;
            }
            return dbtype;
        }
    }
}
