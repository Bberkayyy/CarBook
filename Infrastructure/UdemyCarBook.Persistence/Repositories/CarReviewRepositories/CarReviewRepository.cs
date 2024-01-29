using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarReviewInterfaces;
using UdemyCarBook.Domain;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarReviewRepositories;

public class CarReviewRepository : ICarReviewRepository
{
    private readonly CarBookContext _context;

    public CarReviewRepository(CarBookContext context)
    {
        _context = context;
    }

    public List<CarReview> GetCarReviewsByCarId(int carId)
    {
        return _context.CarReviews.Where(x => x.CarId == carId).ToList();
    }
}
