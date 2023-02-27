using System.Linq;
using MarysToyStore.Data;
using MarysToyStore.Models;

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

        public Product AddProduct(Product product) 
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
            return product;
        }

        public List<Brand> GetBrands()
        {
            return _dataContext.Brands.ToList();
        }

        public Brand AddBrand(Brand brand)
        {
            _dataContext.Brands.Add(brand);
            _dataContext.SaveChanges();
            return brand;
        }
    }
}
