using Entities;
namespace DTO
{
    public record OrderDTO(int OrderId, DateTime OrderDate, decimal OrderSum, string UserUserName);
}
