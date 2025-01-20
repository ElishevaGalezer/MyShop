using Entities;

namespace Repositories
{
    public interface IRatingRepositories
    {
        Task<Rating> Post(Rating rating);
    }
}