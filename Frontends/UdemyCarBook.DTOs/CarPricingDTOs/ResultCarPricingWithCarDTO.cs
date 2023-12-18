using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTOs.CarPricingDTOs;

public class ResultCarPricingWithCarDTO
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string PricingName { get; set; }
    public decimal Amount { get; set; }



    public string BrandName { get; set; }


    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
}
