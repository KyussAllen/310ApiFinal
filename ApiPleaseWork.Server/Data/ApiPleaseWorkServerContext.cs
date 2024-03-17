using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiPleaseWork.Models;

namespace ApiPleaseWork.Server.Data
{
    public class ApiPleaseWorkServerContext : DbContext
    {
        public ApiPleaseWorkServerContext (DbContextOptions<ApiPleaseWorkServerContext> options)
            : base(options)
        {
        }

        public DbSet<ApiPleaseWork.Models.CustomerInformation> CustomerInformation { get; set; } = default!;
        public DbSet<ApiPleaseWork.Models.CustomerContact> CustomerContact { get; set; } = default!;
        public DbSet<ApiPleaseWork.Models.CustCallAttempts> CustCallAttempts { get; set; } = default!;
    }
}
