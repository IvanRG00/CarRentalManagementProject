using System;
using System.Collections.Generic;

namespace CarRentalManagementProject.Models;

public partial class Customers19118070
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int? RentedCarId { get; set; }

    public DateTime? LastModified19118070 { get; set; }

    public virtual Cars19118070? RentedCar { get; set; }

    public virtual ICollection<RentedCars19118070> RentedCars19118070s { get; set; } = new List<RentedCars19118070>();
}
