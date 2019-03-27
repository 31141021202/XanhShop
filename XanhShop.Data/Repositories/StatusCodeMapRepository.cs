using System.Collections.Generic;
using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;
using System.Linq;
using System;
using XanhShop.Common;

namespace XanhShop.Data.Repositories
{
    public interface IStatusCodeMapRepository : IRepository<StatusCodeMap>
    {
        StatusCodeMap GetStatusLabel(int optionValue);
    }
    public class StatusCodeMapRepository : RepositoryBase<StatusCodeMap>, IStatusCodeMapRepository
    {
        public StatusCodeMapRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public StatusCodeMap GetStatusLabel(int optionValue)
        {
            return GetSingleById(optionValue);
        }
    }
}
