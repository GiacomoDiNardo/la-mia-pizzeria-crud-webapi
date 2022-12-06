using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbPizzeriaRepository : IDbPizzeriaRepository
    {
        private PizzeriaDbContext db;

        public DbPizzeriaRepository(PizzeriaDbContext _db)
        {
            db = _db;
        }

        public List<Pizza> All()
        {
            return AllWithRelations();
        }

        public List<Pizza> AllWithRelations()
        {
            return db.Pizze.Include(pizza => pizza.Category).ToList();
        }

        public Pizza GetById(int id)
        {
            return db.Pizze.Where(p => p.PizzaId == id).Include("Ingredients").Include("Category").FirstOrDefault();
        }

        public void Create(Pizza pizza, List<int> selectedIngredients)
        {
            pizza.Ingredients = new List<Ingredient>();

            foreach (int ingredientId in selectedIngredients)
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
                pizza.Ingredients.Add(ingredient);
            }

            db.Pizze.Add(pizza);
            db.SaveChanges();
        }

        public void Update(Pizza pizza, Pizza formData, List<int> selectedIngredients)
        {


            if (selectedIngredients == null)
            {
                selectedIngredients = new List<int>();
            }

            pizza.Name = formData.Name;
            pizza.Description = formData.Description;
            pizza.Image = formData.Image;
            pizza.Prezzo = formData.Prezzo;
            pizza.CategoryId = formData.CategoryId;

            pizza.Ingredients.Clear();



            foreach (int ingredientId in selectedIngredients)
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
                pizza.Ingredients.Add(ingredient);
            }

            //db.Update(pizza);
            db.SaveChanges();
        }

        public void Delete(Pizza pizza)
        {
            db.Pizze.Remove(pizza);
            db.SaveChanges();
        }

        public List<Pizza> SearchByTitle(string? title)
        {
            IQueryable<Pizza> query = db.Pizze.Include("Category").Include("Ingredients");

            if (title == null)
                return query.ToList();

            return query.Where(pizza => pizza.Name.ToLower().Contains(title.ToLower())).ToList();
        }
    }
}
