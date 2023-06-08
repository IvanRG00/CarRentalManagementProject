using System;
using System.Collections.Generic;

namespace CarRentalManagementProject.Models;

public partial class Staff19118070
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? MaintainingVehicleId { get; set; }

    public DateTime? LastModified19118070 { get; set; }

    public virtual Cars19118070? MaintainingVehicle { get; set; }
}
