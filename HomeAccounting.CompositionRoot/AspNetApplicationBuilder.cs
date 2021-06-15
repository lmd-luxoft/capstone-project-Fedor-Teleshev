using HomeAccounting.BusinessLogic;
using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.EF.ApplicationLogic;
using HomeAccounting.DataSource;
using HomeAccounting.DataSource.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.CompositionRoot
{
    public class AspNetApplicationBuilder : AbstractApplicationBuilder
    {
        public AspNetApplicationBuilder(IServiceCollection services) : base(services) { }
        
        protected override void RegisterBusinessLogic()
        {
            _services.AddTransient<IAccountingService, BusinessLogic.EF.ApplicationLogic.AccountingService>();
            _services.AddDbContext<DomainContext>();
        }

        protected override void RegisterDataSource()
        {
            _services.AddTransient<IRepository, RepositoryBaseMssql>();
        }

        protected override void RegisterInfrastructure()
        {
            //throw new NotImplementedException();
        }
    }
}
