using SweetRong2.Domain;
using SweetRong2.IBLL;
using SweetRong2.IReporsitory;
using SweetRong2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.BLL
{
    public class UserService : BaseService<User>, IUserService
    {
        public override void SetCurrentRepository()
        {
            _currentRepository = _DbSession.UserRepository;
        }
    }
}
