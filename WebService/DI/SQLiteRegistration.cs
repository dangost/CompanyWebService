using WebService.Abstraction;
using WebService.Realization;
using WebService.Controllers;

namespace WebService.DI
{
    public class SQLiteRegistration
    {
        public static ICountriesRepository GetRepository(CountriesController controller)
        {
            return new CountriesRepository();
        }

        public static ICustomersRepository GetRepository(CustomersController controller)
        {
            return new CustomersRepository();
        }

        public static ICustomerCompaniesRepository GetRepository(CustomerCompaniesController controller)
        {
            return new CustomerCompaniesRepository();
        }

        public static ICustomerEmployeesRepository GetRepository(CustomerEmployeesController controller)
        {
            return new CustomerEmployeesRepository();
        }

        public static IEmploymentsRepository GetRepository(EmploymentsController controller)
        {
            return new EmploymentsRepository();
        }

        public static IEmploymentJobsRepository GetRepository(EmploymentJobsController controller)
        {
            return new EmploymentJobsRepository();
        }

        public static IInventoriesRepository GetRepository(InventoriesController controller)
        {
            return new InventoriesRepository();
        }

        public static ILocationsRepository GetRepository(LocationsController controller)
        {
            return new LocationsRepository();
        }

        public static IOrderItemsRepository GetRepository(OrderItemsController controller)
        {
            return new OrderItemsRepository();
        }

        public static IOrdersRepository GetRepository(OrdersController controller)
        {
            return new OrdersRepository();
        }

        public static IPeopleRepository GetRepository(PeopleController controller)
        {
            return new PeopleRepository();
        }

        public static IPersonLocationsRepository GetRepository(PersonLocationsController controller)
        {
            return new PersonLocationsRepository();
        }

        public static IPhoneNumbersRepository GetRepository(PhoneNumbersController controller)
        {
            return new PhoneNumbersRepository();
        }

        public static IProductsRepository GetRepository(ProductsController controller)
        {
            return new ProductsRepository();
        }

        public static IRestrictedInfoRepository GetRepository(RestrictedInfoController controller)
        {
            return new RestrictedInfoRepository();
        }

        public static IWarehousesRepository GetRepository(WarehousesController controller)
        {
            return new WarehousesRepository();
        }


    }
}