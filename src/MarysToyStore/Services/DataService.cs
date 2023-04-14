using MarysToyStore.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MarysToyStore.Services
{
    public class DataService
    {
        private readonly DataContext _dataContext;

        public DataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Order> GetOrders(int userId)
        {
            return _dataContext.Orders
                .Where(x => x.User.Id == userId)
                .Include(x => x.OrderLines)
                .ToList();
                
        }

        public void AddOrder(Order order)
        {
            foreach (OrderLine line in _dataContext.OrderLines)
            {
				line.Order = order;
                line.Product = null;
			}
            _dataContext.Orders.Add(order);
        }

		public CartItem GetCartItem(int userId, int productId)
        {
            CartItem cartItem =_dataContext.CartItems
                .Include(x => x.Product)
                .FirstOrDefault(x => x.User.Id == userId &&
                x.ProductId == productId && x.IsArchived == false);
            return cartItem;
        }

        public List<CartItem> GetCartItems(int userId)
        {
            return _dataContext.CartItems
                .Where(x => x.User.Id == userId && x.IsArchived == false)
                .Include(x => x.Product)
                .ToList();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _dataContext.CartItems.Update(cartItem);
            _dataContext.SaveChanges();
        }

        public CartItem AddCartItem(int userId, int productId)
        {
            CartItem cartItem = GetCartItem(userId, productId);
            if(cartItem != null)
            {
                cartItem.Quantity++;
                this.UpdateCartItem(cartItem);
            }
            else if ( cartItem == null)
            {
                cartItem = new CartItem();
                cartItem.UserId = userId;
                cartItem.ProductId = productId;
                cartItem.Quantity = 1;
                _dataContext.CartItems.Add(cartItem);
                _dataContext.SaveChanges();
                return cartItem;
            }
            return cartItem;
        }

        public void DeleteCartItem(int userId, int productId)
        {
            CartItem item = GetCartItem(userId, productId);
                item.IsArchived = true;
            _dataContext.CartItems.Update(item);
            _dataContext.SaveChanges();
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
            return _dataContext.ProductCategories.Where(x => x.IsArchived == false).ToList();
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

        public ProductCategory DeleteProductCategory(int id)
        {
            ProductCategory productCategory = GetProductCategory(id);
            productCategory.IsArchived = true;
            UpdateProductCategory(productCategory);
            _dataContext.SaveChanges();
            return productCategory;
        }

        public List<ProductCategory> GetDeletedProductCategories()
        {
            return _dataContext.ProductCategories.Where(x => x.IsArchived == true).ToList();
        }

        public ProductCategory RestoreProductCategory(int id)
        {
            ProductCategory pc = _dataContext.ProductCategories.FirstOrDefault(pc => pc.Id == id);
            pc.IsArchived = false;
            UpdateProductCategory(pc);
            return pc;
        }

        public List<Product> GetProducts()
        {
            return _dataContext.Products.Where(x => x.IsArchived == false).ToList();
        }

        public Product GetProduct(int id)
        {
            return _dataContext.Products
                .Include(p => p.ProductCategoryProducts)
                .ToList()
                .Find(x => x.Id == id);
        }

        public Product AddProduct(Product product) 
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            _dataContext.RemoveRange(_dataContext.ProductCategoriesProducts.Where(x => x.ProductId == product.Id));
            _dataContext.Update(product);
            _dataContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProduct(id);
            product.IsArchived = true;
            UpdateProduct(product);
            _dataContext.SaveChanges();
        }

        public List<Product> GetDeletedProducts()
        {
            return _dataContext.Products.Where(x => x.IsArchived == true).ToList();
        }

        public Product RestoreProduct(int id)
        {
            Product p = _dataContext.Products.FirstOrDefault(p => p.Id == id);
            p.IsArchived = false;
            UpdateProduct(p);
            return p;
        }

        public List<Brand> GetBrands()
        {
            return _dataContext.Brands.Where(x => x.IsArchived == false).ToList();
           
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

        public Brand DeleteBrand(int id)
        {
            Brand brand = GetBrand(id);
            brand.IsArchived = true;
            UpdateBrand(brand);
            _dataContext.SaveChanges();
            return brand;
        }

        public List<Brand> GetDeletedBrands()
        {
            return _dataContext.Brands.Where(x => x.IsArchived == true).ToList();
        }

        public Brand RestoreBrand(int id)
        {
            Brand b = _dataContext.Brands.FirstOrDefault(b => b.Id == id); // Don't use GetBrand here, that method will exclude the brand we need.
            b.IsArchived = false;
            UpdateBrand(b);
            return b;
        }
    }
}
