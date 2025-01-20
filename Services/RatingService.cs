using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingService : IRatingService
    {
        IRatingRepositories _ratingRepositories;
        public RatingService(IRatingRepositories ratingRepositories)
        {
            _ratingRepositories = ratingRepositories;
        }
        public async Task<Rating> Post(Rating rating)
        {

            return await _ratingRepositories.Post(rating);

        }
    }
}
