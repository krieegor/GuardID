using System;
using System.IO;
using GuardID.iOS.Storage.Implementations;
using GuardID.Storage.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace GuardID.iOS.Storage.Implementations
{
    class SQLiteIOS : ISQLite
    {
        public SQLiteIOS()
        {

        }
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFileName = "TodoSQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFileName);
            //criação da conexão
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}