﻿using Holidays.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Domain.Reviews
{
    public sealed record Rating
    {
        public static readonly Error Invalid = new("Rating.Invalid", "The rating is invalid");
        public int Value { get; init; }

        private Rating(int value) => Value = value;

        public static Result<Rating> Create(int value)
        {
            if (value < 1 || value > 5)
            {
                return Result.Failure<Rating>(Invalid);
            }

            return new Rating(value);
        }
    }
}
