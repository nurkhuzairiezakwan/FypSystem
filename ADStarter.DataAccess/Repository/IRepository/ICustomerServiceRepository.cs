﻿using ADStarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface ICustomerServiceRepository : IRepository<CustomerService>
    {
        void Update(CustomerService obj);
    }
}
