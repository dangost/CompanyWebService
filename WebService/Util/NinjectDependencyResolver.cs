using System;
using System.Collections.Generic;
using Ninject;
using WebService.Abstraction;
using WebService.Realization;


namespace WebService.Util
{
    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public void Dispose()
        {
            kernel.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICountriesRepository>().To<CountriesRepository>();

            kernel.Bind<ICustomersRepository>().To<CustomersRepository>();

            kernel.Bind<ICustomerCompaniesRepository>().To<CustomerCompaniesRepository>();

            kernel.Bind<ICustomerEmployeesRepository>().To<CustomerEmployeesRepository>();

            kernel.Bind<IEmploymentsRepository>().To<EmploymentsRepository>();

            kernel.Bind<IEmploymentJobsRepository>().To<EmploymentJobsRepository>();

            kernel.Bind<IInventoriesRepository > ().To<InventoriesRepository>();

            kernel.Bind<ILocationsRepository>().To<LocationsRepository>();

            kernel.Bind<IOrderItemsRepository>().To<OrderItemsRepository>();

            kernel.Bind<IOrdersRepository>().To<OrdersRepository>();

            kernel.Bind<IPeopleRepository>().To<PeopleRepository>();

            kernel.Bind<IPersonLocationsRepository>().To<PersonLocationsRepository>();

            kernel.Bind<IPhoneNumbersRepository>().To<PhoneNumbersRepository>();

            kernel.Bind<IProductsRepository>().To<ProductsRepository>();

            kernel.Bind<IRestrictedInfoRepository>().To<RestrictedInfoRepository>();

            kernel.Bind<IWarehousesRepository>().To<WarehousesRepository>();
        }
    }
}