using System;

namespace WPFApp
{
    internal class SqlConnection
    {
        private object conn;

        public SqlConnection(object conn)
        {
            this.conn = conn;
        }
    }
}