using System;
using System.Collections.Generic;
using System.Linq;
using EF_Core_2.Models;
using EF_Core_2.Services;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Services
{

    public class ProductService : IProductService
    {
        private ProductContext _productContext;
        public ProductService(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public Product CreateProduct(ProductDTO product)
        {
            using var transaction = _productContext.Database.BeginTransaction(); //using  transaction
            try
            {
                var newProduct = new Product
                {
                    ProductName = product.ProductName,
                    Manifacture = product.Manifacture,
                    CategoryId = product.CategoryId,
                };

                _productContext.Products.Add(newProduct);
                _productContext.SaveChanges();
                transaction.Commit();

                return newProduct;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Product> Delete(ProductDTO product)
        {
            using var transaction = _productContext.Database.BeginTransaction(); //using  transaction

            try
            {
                Product existing = _productContext.Products.Find(product.ID); // get primary key of obj
                if (existing != null)
                {
                    _productContext.Remove(existing);
                    _productContext.SaveChanges();
                    transaction.Commit();

                    return _productContext.Products.ToList();
                }
                else{
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Product> GetList()
        {
            
            using var transaction = _productContext.Database.BeginTransaction(); //using  transaction

            try
            {
                return _productContext.Products.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Product Update(ProductDTO product)
        {

            using var transaction = _productContext.Database.BeginTransaction(); //using  transaction

            try
            {
                var existing = _productContext.Products.Find(product.ID); // get primary key of obj
                if (existing != null)
                {

                    existing.ProductName = product.ProductName;
                    existing.Manifacture = product.Manifacture;
                    existing.CategoryId = product.CategoryId;

                    _productContext.SaveChanges();
                    transaction.Commit();

                    return existing;
                }
                else{
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Product Detail(int id)
        {

            using var transaction = _productContext.Database.BeginTransaction(); //using  transaction

            try
            {
                return _productContext.Products.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}