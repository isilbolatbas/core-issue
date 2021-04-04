using System;

namespace solid_issue
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleHelper oracleHelper = new OracleHelper();
            connect(oracleHelper); //upcasting super class nesne referansı sub class nesne referansının yerine geçebilir.
            question(oracleHelper); 

            SQLHelper sqlHelper = new SQLHelper();
            connect(sqlHelper); 
            question(sqlHelper); //upcasting
        }

        static void connect(DBHelper dbh)
        {
            dbh.connect();
        }
        static void question(DBHelper dbh)
        {
            dbh.question();
        }
    }
}