﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.DTOs.CarPricingDTOs;

public class ResultCarPricingWithModelDTO
{
	public string model { get; set; }
	public decimal dailyAmount { get; set; }
	public decimal weeklyAmount { get; set; }
	public decimal monthlyAmount { get; set; }
}
