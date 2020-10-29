using System;
using System.IO;
using SpectrumCC.Interfaces;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace SpectrumCC.Droid
{
    public class SQLiteDb: ISQLiteDb
    {
        public SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "spectrum.db3");
            var platform = new SQLitePlatformAndroidN();
            return new SQLiteConnection(platform, path);
        }
    }
}
