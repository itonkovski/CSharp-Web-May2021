using System;
using TestApplication.Models.Bikes;

namespace TestApplication.Services.Bikes
{
    public interface IBikeService
    {
        string Create(
            string brand,
            string model,
            string description,
            string imageUrl,
            int year,
            string categoryId,
            int dealerId);
    }
}
