﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarFeatureRepositories;

public class CarFeatureRepository : ICarFeatureRepository
{
    private readonly CarBookContext _context;

    public CarFeatureRepository(CarBookContext context)
    {
        _context = context;
    }

    public void ChangeCarFeatureAvailableToFalse(int id)
    {
        var value = _context.CarFeatures.Where(x => x.Id == id).FirstOrDefault();
        value.Available = false;
        _context.SaveChanges();
    }

    public void ChangeCarFeatureAvailableToTrue(int id)
    {
        var value = _context.CarFeatures.Where(x => x.Id == id).FirstOrDefault();
        value.Available = true;
        _context.SaveChanges();
    }

    public void CreateCarFeatureByCar(CarFeature carFeature)
    {
        _context.CarFeatures.Add(carFeature);
        _context.SaveChanges();
    }

    public List<CarFeature> GetCarFeaturesByCarId(int carId)
    {
        var values = _context.CarFeatures.Include(x => x.Feature).Where(x => x.CarId == carId).ToList();
        return values;
    }
}
