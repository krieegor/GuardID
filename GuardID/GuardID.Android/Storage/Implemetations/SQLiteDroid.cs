using GuardID.Droid.Storage.Implemetations;
using GuardID.Storage.Interfaces;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDroid))]
namespace GuardID.Droid.Storage.Implemetations
{
    class SQLiteDroid : ISQLite
    {
        public SQLiteDroid()
        {

        }
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFileName = "TodoSQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLiteConnection(path);
            return conn;
        }

        
    }
}