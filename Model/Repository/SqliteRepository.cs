using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace wakeUp.Model.Repository
{
    internal class SqliteRepository
    {
        private SqliteRepository repository = null;

        private SQLiteConnection connection = null;

        private string dbPath = null;

        private int version = 3;

        public SqliteRepository(string dbPath) : this(dbPath, 3)
        {
        }

        public SqliteRepository(string dbPath, int version)
        {
            if(!System.IO.File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            this.dbPath = dbPath;
            this.version = version;
        }


        public void Connect()
        {
            if(connection == null)
            {
                connection = new SQLiteConnection($@"Data Source={dbPath};Version={version};");
            }

            connection.Open();
        }

        public void Close()
        {
            if(connection == null)
            {
                return;
            }

            connection.Close();

            connection = null;
        }

        public int ExecuteNonQuery(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, connection);

            int rtn = command.ExecuteNonQuery();

            return rtn;
        }

        public DataTable ExecuteReader(string sql)
        {
            SQLiteDataReader rdr = null;

            DataTable dtResult = new DataTable();

            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                rdr = command.ExecuteReader();

                if (rdr != null)
                {
                    dtResult.Load(rdr);

                    rdr.Close();
                }
            } 
            finally
            {
                if(rdr != null)
                {
                    rdr.Close();
                }
            }

            return dtResult;
        }
    }
}
