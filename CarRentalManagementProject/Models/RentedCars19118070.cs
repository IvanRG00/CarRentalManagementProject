using System;
using System.Collections.Generic;

namespace CarRentalManagementProject.Models;

public partial class RentedCars19118070
{
    public int RentalId { get; set; }

    public int? CarId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? RentalDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public DateTime? LastModified19118070 { get; set; }

    public virtual Cars19118070? Car { get; set; }

    public virtual Customers19118070? Customer { get; set; }
}
