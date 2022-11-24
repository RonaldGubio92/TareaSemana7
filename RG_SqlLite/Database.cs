using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RG_SqlLite
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
         
    }
}
