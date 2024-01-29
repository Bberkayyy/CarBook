using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain;

namespace UdemyCarBook.Application.Interfaces.CarReviewInterfaces;

public interface ICarReviewRepository
{
    List<CarReview> GetCarReviewsByCarId(int carId);
}
