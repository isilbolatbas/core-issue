using System;

namespace solid_issue
{
    public class SQLHelper : DBHelper
    {
        public override void connect()
        {
            Console.Write("connect to SQL");
        }

        public override void question()
        {
            Console.Write("T-SQL");
        }
    }
}