using System;
using System.Collections.Generic;
using EF_Core_2.Models;


namespace EF_Core_2.Services
{

    public interface IProductService
    {
        IEnumerable<Product> GetList();

        Product CreateProduct(ProductDTO product);

        Product Update(ProductDTO product);

        List<Product> Delete(ProductDTO product);
        Product Detail(int id);

    }

}