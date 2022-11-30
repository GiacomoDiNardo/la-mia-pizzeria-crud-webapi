using la_mia_pizzeria_static.Data;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbMessageRepository : IDbMessageRepository
    {
        private PizzeriaDbContext db;

        public DbMessageRepository()
        {
            db = new PizzeriaDbContext();
        }

        public void Create(Message message)
        {

            db.Messages.Add(message);
            db.SaveChanges();

        }
    }
}
