using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Controllers
{
    public class RepositoryController
    {  
        public static IRepository GetRepository()
        {
            IRepository repositoryType = new SQLiteServiceBase();
            return repositoryType;
        }
    }
}