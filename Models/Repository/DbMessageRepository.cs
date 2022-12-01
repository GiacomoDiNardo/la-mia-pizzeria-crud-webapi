using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbMessageRepository : IDbMessageRepository
    {
        private PizzeriaDbContext db;

        public DbMessageRepository(DbContextOptions<PizzeriaDbContext> options)
        {
            db = new PizzeriaDbContext(options);
        }

        public void Create(Message message)
        {

            db.Messages.Add(message);
            db.SaveChanges();

        }
    }
}
