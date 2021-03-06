﻿using Ninject.Modules;
using WebService.Abstraction;
using WebService.Realization;

namespace WebService.DI
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICountriesRepository>().To<CountriesRepository>();
            Bind<ICustomersRepository>().To<CustomersRepository>();
            Bind<ICustomerCompaniesRepository>().To<CustomerCompaniesRepository>();
            Bind<ICustomerEmployeesRepository>().To<CustomerEmployeesRepository>();
            Bind<IEmploymentsRepository>().To<EmploymentsRepository>();
            Bind<IEmploymentJobsRepository>().To<EmploymentJobsRepository>();
            Bind<IInventoriesRepository>().To<InventoriesRepository>();
            Bind<ILocationsRepository>().To<LocationsRepository>();
            Bind<IOrderItemsRepository>().To<OrderItemsRepository>();
            Bind<IOrdersRepository>().To<OrdersRepository>();
            Bind<IPeopleRepository>().To<PeopleRepository>();
            Bind<IPersonLocationsRepository>().To<PersonLocationsRepository>();
            Bind<IPhoneNumbersRepository>().To<PhoneNumbersRepository>();
            Bind<IProductsRepository>().To<ProductsRepository>();
            Bind<IRestrictedInfoRepository>().To<RestrictedInfoRepository>();
            Bind<IWarehousesRepository>().To<WarehousesRepository>();

        }
    }
}