using Holidays.Domain.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Infrastructure.Repositories
{
    internal sealed class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
