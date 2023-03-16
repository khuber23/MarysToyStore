using MarysToyStore.DataAccess;

namespace MarysToyStore.Services
{
    public class DataService
    {
        private readonly DataContext _dataContext;

        public DataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public User AddUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return user;
        }

        public User GetUser(string emailAddress)
        {
            return _dataContext.Users.FirstOrDefault(x => x.EmailAddress.ToLower() == emailAddress.ToLower());
        }

        public List<ProductCategory> GetProductCategories()
        {
            return _dataContext.ProductCategories.ToList();
        }

        public ProductCategory GetProductCategory(int id)
        {
            return _dataContext.ProductCategories.FirstOrDefault(x => x.Id == id);
        }


        public ProductCategory AddProductCategory(ProductCategory productCategory)
        {
            _dataContext.ProductCategories.Add(productCategory);
            _dataContext.SaveChanges();
            return productCategory;
        }

        public ProductCategory UpdateProductCategory(ProductCategory productCategory)
        {
            _dataContext.ProductCategories.Update(productCategory);
            _dataContext.SaveChanges();
            return productCategory;
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

        public ProductViewModel UpdateProduct(ProductViewModel productViewModel)
        {
            _dataContext.Update(productViewModel);
            _dataContext.SaveChanges();
            return productViewModel;
        }

        public List<Brand> GetBrands()
        {
            return _dataContext.Brands.ToList();
        }

        public Brand GetBrand(int id)
        {
            return _dataContext.Brands.FirstOrDefault(x => x.Id == id);
        }

        public Brand AddBrand(Brand brand)
        {
            _dataContext.Brands.Add(brand);
            _dataContext.SaveChanges();
            return brand;
        }

        public Brand UpdateBrand(Brand brand)
        {
			_dataContext.Brands.Update(brand);
			_dataContext.SaveChanges();
            return brand;
		}
    }
}
