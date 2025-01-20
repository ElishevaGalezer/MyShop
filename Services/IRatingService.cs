using Entities;

namespace Services
{
    public interface IRatingService
    {
        Task<Rating> Post(Rating rating);
    }
}