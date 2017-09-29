using SweetRong2.Domain;
using SweetRong2.IReporsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
    }
}
