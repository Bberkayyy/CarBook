using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTOs.CarDescriptionDTOs;

public class ResultCarDescriptionByCarIdDTO
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Details { get; set; }
}
