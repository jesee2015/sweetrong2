using SweetRong2.IReporsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.Repository
{
    public static class RepositoryFactory
    {
        public static IUserRepository UserRepository
        {
            get { return new UserRepository(); }
        }
    }
}
