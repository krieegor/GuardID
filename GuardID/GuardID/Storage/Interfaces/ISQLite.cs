using SQLite;

namespace GuardID.Storage.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();

    }
}
