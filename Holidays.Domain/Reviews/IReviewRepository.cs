﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Domain.Reviews
{
    public interface IReviewRepository
    {
        void Add(Review review);
    }
}
