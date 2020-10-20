using System;
using SQLite.Net;

namespace SpectrumCC.Interfaces
{
    public interface ISQLiteDb
    {
        SQLiteConnection GetConnection();
    }
}
