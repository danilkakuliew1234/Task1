using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Table;

namespace UITable.Model
{
    class CreateTableFromView
    {
        DataBase dataBase;
        public CreateTableFromView()
        {
            dataBase = new DataBase(@"Data Source=DESKTOP-R9FOSLF\SQLEXPRESS;Initial Catalog=Pred;Integrated Security=True");
        }
        public bool CreateTable()
        {
            bool status;

            SqlCommand sqlCommand = new SqlCommand($"CREATE TABLE Cities(c_id int not null identity, c_name nchar(255) not null)", dataBase.sqlConnection);

            dataBase.OpenConnection();

            status = sqlCommand.ExecuteNonQuery() == -1;

            dataBase.CloseConnection();

            return status;
        }
        public bool LoadTable(List<City> cities)
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = dataBase.sqlConnection;

            dataBase.OpenConnection();

            foreach(City city in cities)
            {
                sqlCommand.CommandText = $"INSERT INTO Cities(c_name) VALUES ('{city.c_name}')";
                if (sqlCommand.ExecuteNonQuery() != 1)
                {
                    dataBase.CloseConnection();
                    return false;
                }
            }

            dataBase.CloseConnection();

            return true;
        }
    }
}
