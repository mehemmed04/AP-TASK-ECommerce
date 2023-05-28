﻿using App.Business.Abstract;
using App.DataAccess.Abstract;
using App.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int id)
        {
            var item = _productDal.Get(p => p.ProductId == id);
            _productDal.Delete(item);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId == 0);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        public List<Product> GetProductsAZ(List<Product> list, bool state)
        {
            return state ? list.OrderBy(p => p.ProductName).ToList() : list.OrderByDescending(p => p.ProductName).ToList();
        }

        public List<Product> GetProductsByFilterLoworHigh(List<Product> list, bool state)
        {
            return state ? list.OrderBy(p => p.UnitPrice).ToList() : list.OrderByDescending(p => p.UnitPrice).ToList();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
