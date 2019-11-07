namespace P01_HospitalDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data;

    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new HospitalContext();
            db.Database.Migrate();
        }
    }
}
