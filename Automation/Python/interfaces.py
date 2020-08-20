path = r"D:\Projects\Regula\Web\CompanyWebService\Automation\Controllers"

class_names = ["Country", "Customer", "CustomerCompany", "CustomerEmployee","Employment","EmploymentJobs","Inventory","Location","OrderItem", "Orders", "Person", "PersonLocation", "PhoneNumber", "Product", "RestrictedInfo", "Warehouse"]
list_names = ["Countries", "Customers", "CustomerCompanies", "CustomerEmployees","Employments", "EmploymentJobs", "Inventories","Locations","OrderItems", "Orders", "People", "PersonLocations","PhoneNumbers", "Products", "RestrictedInfo", "Warehouses"]

for i in range(len(class_names)):
    temp_path = path + "\\" + list_names[i] + "Controller.cs"
    file = open(temp_path, 'w')

    file.write('''using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class '''+list_names[i]+'''Controller : ApiController
    {
        public I'''+list_names[i]+'''Repository db;

        public '''+list_names[i]+'''Controller()
        {
            db = SQLiteRegistration.GetRepository(this);
        }

        // GET api/'''+list_names[i]+'''
        public IEnumerable<'''+class_names[i]+'''> Get() { return db.Get'''+list_names[i]+'''(); }

        // GET api/'''+list_names[i]+'''/{id}
        public '''+class_names[i]+''' Get(int id) { return db.Get'''+class_names[i]+'''Id(id); }

        // POST api/'''+list_names[i]+'''
        public IHttpActionResult Post([FromBody]'''+class_names[i]+''' value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Country), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/'''+list_names[i]+'''/{id}
        public IHttpActionResult Put(int id, [FromBody]'''+class_names[i]+''' value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof('''+class_names[i]+'''), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/'''+list_names[i]+'''/{id}
        public void Delete(int id) { db.Delete'''+class_names[i]+'''(id); }
    }
}''')
