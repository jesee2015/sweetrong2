using SweetRong2.Domain;
using SweetRong2.IBLL;
using SweetRong2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.BLL
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public override void SetCurrentRepository()
        {
            _currentRepository = RepositoryFactory.ProductRepository;
        }
    }
}
