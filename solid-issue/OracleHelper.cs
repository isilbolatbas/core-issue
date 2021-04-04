using System;

namespace solid_issue
{
    public class OracleHelper : DBHelper
    {
        public override void connect()
        {
            Console.Write("connect to Oracle");
        }

        public override void question()
        {
            Console.Write("PL-SQL");
        }
    }
}