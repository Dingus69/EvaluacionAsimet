using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace EvaluacionG5.DATAACCESS
{
    public abstract class Database
    {
        public static readonly string CONN_STRING_ALTACOM = ConfigurationManager.AppSettings["ConectionStringSql"];
        private static Hashtable parameterCache = Hashtable.Synchronized(new Hashtable());


        public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlConnection conn = new SqlConnection(connString);
            return ExecuteNonQuery(conn, cmdType, cmdText, cmdParms);
        }

        public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = null;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new SqlCommand();
                GenerarComando(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();

                conn.Close();
                cmd.Dispose();

                return val;
            }
            catch (Exception ex)
            {
                if ((conn != null) && (conn.State != ConnectionState.Closed))
                    conn.Close();
                if (cmd != null)
                    cmd.Dispose();

                throw ex;
            }
        }

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            GenerarComando(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static SqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(connString);
                cmd = new SqlCommand();
                GenerarComando(cmd, conn, null, cmdType, cmdText, cmdParms);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                cmd.Dispose();

                return rdr;
            }
            catch (SystemException ex)
            {
                if (rdr != null)
                    rdr.Close();
                if (cmd != null)
                    cmd.Dispose();
                if ((conn != null) && (conn.State != ConnectionState.Closed))
                    conn.Close();

                throw ex;
            }
        }

        public static DataTable dtExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlConnection conn = null;
            DataTable dt = null;

            try
            {
                conn = new SqlConnection(connString);
                dt = dtExecuteReader(conn, cmdType, cmdText, cmdParms);

                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                if ((conn != null) && (conn.State != ConnectionState.Closed))
                    conn.Close();
                if (dt != null)
                    dt.Dispose();
                throw ex;
            }
        }

        public static DataTable dtExecuteReader(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = null;
            DataTable dt = null;

            try
            {
                dt = new DataTable();
                cmd = new SqlCommand();

                GenerarComando(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                cmd.Parameters.Clear();

                return (dt);
            }
            catch (Exception ex)
            {
                if ((conn != null) && (conn.State != ConnectionState.Closed))
                    conn.Close();
                if (cmd != null)
                    cmd.Dispose();
                if (dt != null)
                    dt.Dispose();

                throw ex;
            }
        }

        public static DataSet dsExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            SqlDataAdapter da = null;
            DataSet ds = null;

            try
            {
                cmd = new SqlCommand();
                conn = new SqlConnection(connString);

                GenerarComando(cmd, conn, null, cmdType, cmdText, cmdParms);

                ds = new DataSet();
                da = new SqlDataAdapter(cmd);

                ds.EnforceConstraints = false;
                da.Fill(ds);

                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                cmd.Dispose();
                da.Dispose();

                return ds;
            }
            catch (Exception ex)
            {
                if ((conn != null) && (conn.State != ConnectionState.Closed))
                    conn.Close();
                if (cmd != null)
                    cmd.Dispose();
                if (da != null)
                    da.Dispose();
                if (ds != null)
                    ds.Dispose();

                throw ex;
            }
        }

        public static DataSet dsExecuteReader(SqlTransaction trans, string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            SqlDataAdapter da = null;
            DataSet ds = null;

            try
            {
                cmd = new SqlCommand();
                conn = new SqlConnection(connString);

                GenerarComando(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);

                ds = new DataSet();
                da = new SqlDataAdapter(cmd);

                ds.EnforceConstraints = false;
                da.Fill(ds);

                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                cmd.Dispose();
                da.Dispose();

                return ds;
            }
            catch (Exception ex)
            {
                if ((conn != null) && (conn.State != ConnectionState.Closed))
                    conn.Close();
                if (cmd != null)
                    cmd.Dispose();
                if (da != null)
                    da.Dispose();
                if (ds != null)
                    ds.Dispose();

                throw ex;
            }
        }

        public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand();
                conn = new SqlConnection(connString);

                GenerarComando(cmd, conn, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();

                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                cmd.Dispose();

                return val;
            }
            catch (Exception ex)
            {
                if ((conn != null) && (conn.State != ConnectionState.Closed))
                    conn.Close();
                if (cmd != null)
                    cmd.Dispose();

                throw ex;
            }
        }

        public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            GenerarComando(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();

            return val;
        }

        public static void ParametrosEmCache(string cacheKey, params SqlParameter[] cmdParms)
        {
            parameterCache[cacheKey] = cmdParms;
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] ccParameters = (SqlParameter[])parameterCache[cacheKey];
            if (ccParameters == null)
                return null;

            SqlParameter[] clParameters = new SqlParameter[ccParameters.Length];
            for (int i = 0, j = ccParameters.Length; i < j; i++)
                clParameters[i] = (SqlParameter)((ICloneable)ccParameters[i]).Clone();
            return clParameters;
        }


        public static SqlConnection Connection(string connString)
        {
            SqlConnection conn = new SqlConnection(connString);

            if (conn.State != ConnectionState.Open)
                conn.Open();

            return conn;
        }

        private static void GenerarComando(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 180;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        public static SqlCommand GenerarComando(SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            SqlCommand cmd = new SqlCommand();
            GenerarComando(cmd, conn, trans, cmdType, cmdText, cmdParms);

            return cmd;
        }
    }
}
