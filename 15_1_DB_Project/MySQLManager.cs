using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace _15_1_DB_Project
{
    public class MySQLManager
    {
        public MySqlConnection myConnection;
        public MySqlCommand myCommand;
        public MySqlDataReader myReader;

        public MySQLManager()
        {
            myConnection = new MySqlConnection();
            myCommand = new MySqlCommand();
        }

        public bool initMySQL()
        {
            try
            {
                myConnection.ConnectionString = @"
                    Data Source=" +
                                    "localhost"         // 노트북 -> 노트북
                                    //"192.168.0.6"       // 집 컴퓨터 -> 노트북
                                    //"219.240.19.131"    // 외부 -> 노트북
                    + "; Port=" + "5555"
                    + "; Database=" + "db_project_todolist"
                    + "; User Id=" + "YDG_DB_PROJECT"
                    + "; Password=" + "11050038"
                    + "; Allow User Variables=True"
                    ;
                myConnection.Open();
                myCommand.Connection = myConnection;

                return true;
            }
            catch (MySqlException _e)
            {
                MessageBox.Show(_e.Message);

                return false;
            }
        }

        public void closeMySQL()
        {
            try
            {
                myConnection.Close();
            }
            catch (MySqlException _e)
            {
                MessageBox.Show(_e.Message);
            }
        }

        public bool joinToMySQL(string joinName, string joinPassword)
        {
            try
            {
                string query = @"insert into member ("
                    + "name, password"
                    + ") values ('"
                    + joinName + "', '"
                    + joinPassword + "');";

                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException _e)
            {
                MessageBox.Show(_e.Message);

                return false;
            }
        }

        public int loginNameCheck(string loginName, string loginPassword)
        {
            try
            {
                string result = "";
                int countMembersByName;

                myCommand.CommandText = @"select count(*) from member "
                    + "where name='" + loginName
                    + "';";
                countMembersByName = Convert.ToInt32(myCommand.ExecuteScalar());
                if (countMembersByName != 1)
                {
                    return -1;
                }
                else
                {
                    myCommand.CommandText = @"select name, password from member "
                        + "where name='" + loginName
                        + "';";

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        result = myReader["password"].ToString();
                    }
                    myReader.Close();

                    if (result == loginPassword)
                    {
                        myCommand.CommandText = @"select member_id from member "
                            + "where name='" + loginName
                            + "' and password='" + loginPassword
                            + "';";

                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            result = myReader[0].ToString();
                        }
                        myReader.Close();

                        return Int32.Parse(result);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (MySqlException _e)
            {
                MessageBox.Show(_e.Message);

                return -1;
            }
        }

        /* (결과 테이블을 다뤄야하는) 모든 SQL문들은 이 메소드를 통해 테이블을 List<Dictionary<string, string>> 형식으로 반환
         * 먼저 columnName 은 각 필드, rowList 는 각 레코드
         * myReader는 레코드 별로 읽어와 값을 제공하므로,
         * row의 인덱스를 0부터 하여 첫 번째 레코드(myReader[0])를 columnName을 이용해 그대로 rowList[0](첫 번째 레코드)로 넣음
         * 따라서 rowList[0](첫 번째 레코드)의 첫 요소는 columnName으로 구분된 Dictionary
         * 예) 필드 이름이 F1, F2, F3 이고 총 레코드 수가 3이라면 그 rowList의 각 요소(Dictionary) 안의 각 키값들은 
         * 첫 번째 레코드(rowList[0])의 경우 F1+0, F2+0, F3+0, 두 번째 레코드(rowList[1])의 경우 F2+1, F2+1, F3+1, ...
         * rowList의 각 요소는 Dictionary 이므로 F1+0 등 각 키에 대한 값 또한 같이 저장됨 */
        public List<Dictionary<string, string>> commandMySQL(string query)
        {
            try
            {
                // MessageBox.Show(query);

                switch (query.Substring(0, 6))
                {
                    case "select":
                        List<Dictionary<string, string>> resultTable = new List<Dictionary<string, string>>();

                        ArrayList columnName = new ArrayList();
                        ArrayList rowList = new ArrayList();
                        Dictionary<string, string> tempDic;

                        string checkingCountOfRows = @"select count(*) from";
                        int rowCount = 0;
                        int fieldCount = 0;
                        string[] separator = { " from " };
                        string[] tempSplitted = query.Split(separator, StringSplitOptions.None);

                        if (query.Contains("where"))
                        {
                            separator[0] = " where ";
                            tempSplitted = tempSplitted[1].Split(separator, StringSplitOptions.None);

                            checkingCountOfRows += " ";
                            checkingCountOfRows += tempSplitted[0];
                            checkingCountOfRows += " where ";
                            checkingCountOfRows += tempSplitted[1];
                        }
                        else
                        {
                            if (tempSplitted[1].Substring(0, 4) == "memb")
                                checkingCountOfRows += " member";
                            else if (tempSplitted[1].Substring(0, 4) == "todo")
                                checkingCountOfRows += " todolist";
                            else if (tempSplitted[1].Substring(0, 4) == "memo")
                                checkingCountOfRows += " memo";
                            checkingCountOfRows += ";";
                        }
                        
                        myCommand.CommandText = checkingCountOfRows;
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            rowCount += Convert.ToInt32(myReader[0]); 
                        }
                        myReader.Close();

                        myCommand.CommandText = query;
                        myReader = myCommand.ExecuteReader();
                        fieldCount = myReader.FieldCount;

                        if (rowCount == 0)
                        {
                            myReader.Close();

                            return null;
                        }

                        for (int fieldNum = 0; fieldNum < fieldCount; fieldNum++)
                            columnName.Add(myReader.GetName(fieldNum));
                        for (int rowNum = 0; rowNum < rowCount; rowNum++)
                            rowList.Add(new Dictionary<string, string>());


                        for (int i = 0; i < rowCount; i++)
                        {
                            myReader.Read();
                            for (int j = 0; j < fieldCount; j++)
                            {
                                tempDic = (Dictionary<string, string>)rowList[i];
                                tempDic.Add((string)columnName[j] + "+" + i, myReader[columnName[j].ToString()].ToString());
                                rowList[i] = (object)tempDic;
                            }
                        }
                        myReader.Close();

                        if (((Dictionary<string, string>)rowList[0]).Count == 0)
                            return null;
                        else 
                        {
                            for (int i = 0; i < rowCount; i++)
                                resultTable.Add((Dictionary<string, string>)rowList[i]);

                            return resultTable;
                        }
                    case "insert":
                    case "delete":
                    case "update":
                        myCommand.CommandText = query;
                        myCommand.ExecuteNonQuery();
                        break;
                    default:
                        break;
                }

                return null;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                myReader.Close();

                return null;
            }
            catch (Exception _e)
            {
                MessageBox.Show(_e.Message);
                myReader.Close();

                return null;
            }
        }
    }
}
