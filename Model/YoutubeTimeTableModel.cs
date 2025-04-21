using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wakeUp.Model.Repository;

namespace wakeUp.Model
{
    internal class YoutubeTimeTableModel
    {
        private static SqliteRepository repository = null;
        
        private static YoutubeTimeTableModel youtubeTimeTableModel = null;

        private static readonly string DB_NAME = "C:\\Users\\jchye\\Documents\\wakeUp\\bin\\Debug\\wakeupDB";

        private static readonly string TABLE_NAME = "youtube_time_table";

        private YoutubeTimeTableModel() 
        {
            repository = new SqliteRepository(DB_NAME);

            CreateTable();
        }

        public static YoutubeTimeTableModel GetSingletonInstance()
        {
            if(youtubeTimeTableModel == null)
            {
                youtubeTimeTableModel = new YoutubeTimeTableModel();
            }

            return youtubeTimeTableModel;
        }

        private void CreateTable()
        {
            try 
            {
                repository.Connect();

                string createTableSql = $@"CREATE TABLE IF NOT EXISTS {TABLE_NAME} (
                                                seq INTEGER primary key autoincrement
                                                , start_time varchar(4)
                                                , channel varchar(50)
                                                , title_keyword varchar(1000)
                                                , execute_mode int
                                            )";
                
                int rtn = repository.ExecuteNonQuery(createTableSql);

                if(rtn != 0)
                {
                    throw new Exception("테이블 생성 실패");
                }
            }
            finally
            {
                repository.Close();
            }
        }

        public List<YoutubeTimeTable> Select()
        {
            List<YoutubeTimeTable> youtubeTimeTableList = new List<YoutubeTimeTable>();

            string sql = $@"select seq, start_time, channel, title_keyword, execute_mode from {TABLE_NAME} order by start_time";

            DataTable dtResult = null;

            try
            {
                repository.Connect();

                dtResult = repository.ExecuteReader(sql);
            }
            finally
            {
                repository.Close();
            }

            foreach(DataRow drResult in dtResult.Rows)
            {
                int seq = Int32.Parse(drResult["seq"].ToString());
                string startTime = drResult["start_time"].ToString();
                string channel = drResult["channel"].ToString();
                string titleKeyword = drResult["title_keyword"].ToString();
                int executeMOde = Int32.Parse(drResult["execute_mode"].ToString());

                youtubeTimeTableList.Add(new YoutubeTimeTable(seq, startTime, channel, titleKeyword, (YoutubeTimeTable.ExecuteMode)executeMOde));
            }

            return youtubeTimeTableList;
        }

        public void InsertNUpdate(List<YoutubeTimeTable> youtubeTimeTableList)
        {
            InsertNUpdate(youtubeTimeTableList.ToArray());
        }

        public void DeleteNInsert(List<YoutubeTimeTable> youtubeTimeTableList)
        {
            try
            {
                if (youtubeTimeTableList == null)
                {
                    return;
                }

                StringBuilder sb = new StringBuilder();
                sb.Append($@"delete from {TABLE_NAME};");
                foreach (YoutubeTimeTable ytimeTable in youtubeTimeTableList)
                {
                    string sql = $@"insert into {TABLE_NAME}(start_time, channel, title_keyword, execute_mode) values(
                                        '{ytimeTable.GetStartTime()}'
                                        , '{ytimeTable.GetChannel()}'
                                        , '{ytimeTable.GetTitleKeyword()}'
                                        , {ytimeTable.GetExecuteModeValue()}
                                );";

                    sb.AppendLine(sql);
                }

                repository.Connect();

                repository.ExecuteNonQuery(sb.ToString());
            }
            finally
            {
                repository.Close();
            }
        }

        public void InsertNUpdate(YoutubeTimeTable youtubeTimeTable)
        {
            InsertNUpdate(new YoutubeTimeTable[] { youtubeTimeTable });
        }

        public void InsertNUpdate(YoutubeTimeTable[] youtubeTimeTables)
        {
            try
            {
                if(youtubeTimeTables == null || youtubeTimeTables.Length == 0)
                {
                    return;
                }

                StringBuilder sb = new StringBuilder();
                foreach (YoutubeTimeTable ytimeTable in youtubeTimeTables)
                {
                    int seq = ytimeTable.GetSeq();

                    string sql = "";

                    if(seq == -1)
                    {
                        sql = $@"insert into {TABLE_NAME}(start_time, channel, title_keyword, execute_mode) values(
                                        '{ytimeTable.GetStartTime()}'
                                        , '{ytimeTable.GetChannel()}'
                                        , '{ytimeTable.GetTitleKeyword()}'
                                        , {ytimeTable.GetExecuteModeValue()}
                                );";
                    }
                    else
                    {
                        sql = $@"update {TABLE_NAME} set 
                                        start_time = '{ytimeTable.GetStartTime()}'
                                        , channel = '{ytimeTable.GetChannel()}'
                                        , title_keyword = '{ytimeTable.GetTitleKeyword()}'
                                        , execute_mode = {ytimeTable.GetExecuteModeValue()}
                                 where seq = {seq};";
                    }

                    sb.AppendLine(sql);
                }
                
                repository.Connect();

                repository.ExecuteNonQuery(sb.ToString());
            }
            finally
            {
                repository.Close();
            }
        }

        public void Delete(int seq)
        {
            try
            {
                repository.Connect();

                string deleteSql = $@"delete from {TABLE_NAME} where seq = {seq}";

                int rtn = repository.ExecuteNonQuery(deleteSql);

                if (rtn != 0)
                {
                    throw new Exception("데이터 삭제 실패");
                }
            }
            finally
            {
                repository.Close();
            }
        }

        public void Delete()
        {
            try
            {
                repository.Connect();

                string deleteSql = $@"delete from {TABLE_NAME}";

                int rtn = repository.ExecuteNonQuery(deleteSql);

                if (rtn != 0)
                {
                    throw new Exception("데이터 삭제 실패");
                }
            }
            finally
            {
                repository.Close();
            }
        }
    }
}
