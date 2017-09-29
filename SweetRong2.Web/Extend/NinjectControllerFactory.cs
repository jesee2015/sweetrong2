using Ninject;
using SweetRong2.BLL;
using SweetRong2.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetRong2.Web.Extend
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            this.ninjectKernel = new StandardKernel();
            AddBinders();
        }

        private void AddBinders()
        {
            //增加服务绑定
            ninjectKernel.Bind<IUserService>().To<UserService>();
            ninjectKernel.Bind<IProductService>().To<ProductService>();
        }
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }
}