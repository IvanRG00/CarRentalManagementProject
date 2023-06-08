using System;
using System.Collections.Generic;

namespace CarRentalManagementProject.Models;

public partial class Cars19118070
{
    public int CarId { get; set; }

    public string? CarMake { get; set; }

    public string? CarModel { get; set; }

    public string? CarColor { get; set; }

    public int? CarHorsePower { get; set; }

    public DateTime? LastModified19118070 { get; set; }

    public virtual ICollection<Customers19118070> Customers19118070s { get; set; } = new List<Customers19118070>();

    public virtual ICollection<RentedCars19118070> RentedCars19118070s { get; set; } = new List<RentedCars19118070>();

    public virtual ICollection<Staff19118070> Staff19118070s { get; set; } = new List<Staff19118070>();
}
