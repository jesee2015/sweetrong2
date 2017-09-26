using SweetRong2.Domain;
using SweetRong2.IReporsitory;
using SweetRong2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.BLL
{
    public class UserService
    {
        private IUserRepository _userRepository = RepositoryFactory.UserRepository;

        public User AddUser(User user)
        {
            return _userRepository.AddEntity(user);
        }
    }
}
