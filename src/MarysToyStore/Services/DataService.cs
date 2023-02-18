using System.Linq;
using MarysToyStore.Data;

namespace MarysToyStore.Services
{
    public class DataService
    {
        private readonly DataContext _dataContext;

        public DataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Product> GetProducts()
        {
            return _dataContext.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return _dataContext.Products.FirstOrDefault(x => x.Id == id);
        }
    }
}
