using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AppDbContext:DbContext{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Property>Properties{get ; set ;}
    public DbSet<Manager>Managers{get ; set ;}
    public DbSet<Tenant>Tenants{get ; set ;}
    public DbSet<Location>Locations{get ; set ;}
    public DbSet<Application>Applications{get ; set ;}
    public DbSet<Lease>Leases{get ; set ;}
    public DbSet<Payment>Payments{get ; set ;}

    // Optional: If using Enums or converting special types
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Add enum-to-string conversions if needed
    }

}
public enum Highlight
{
    HighSpeedInternetAccess,
    WasherDryer,
    AirConditioning,
    Heating,
    SmokeFree,
    CableReady,
    SatelliteTV,
    DoubleVanities,
    TubShower,
    Intercom,
    SprinklerSystem,
    RecentlyRenovated,
    CloseToTransit,
    GreatView,
    QuietNeighborhood
}

public enum Amenity
{
    WasherDryer,
    AirConditioning,
    Dishwasher,
    HighSpeedInternet,
    HardwoodFloors,
    WalkInClosets,
    Microwave,
    Refrigerator,
    Pool,
    Gym,
    Parking,
    PetsAllowed,
    WiFi
}

public enum PropertyType
{
    Rooms,
    Tinyhouse,
    Apartment,
    Villa,
    Townhouse,
    Cottage
}

public enum ApplicationStatus
{
    Pending,
    Denied,
    Approved
}

public enum PaymentStatus
{
    Pending,
    Paid,
    PartiallyPaid,
    Overdue
}

public class Property
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public float PricePerMonth { get; set; }
    public float SecurityDeposit { get; set; }
    public float ApplicationFee { get; set; }
    public List<string> PhotoUrls { get; set; }
    public List<Amenity> Amenities { get; set; }
    public List<Highlight> Highlights { get; set; }
    public bool IsPetsAllowed { get; set; } = false;
    public bool IsParkingIncluded { get; set; } = false;
    public int Beds { get; set; }
    public float Baths { get; set; }
    public int SquareFeet { get; set; }
    public PropertyType PropertyType { get; set; }
    public DateTime PostedDate { get; set; } = DateTime.Now;
    public float? AverageRating { get; set; } = 0;
    public int? NumberOfReviews { get; set; } = 0;

    public int LocationId { get; set; }
    public Location Location { get; set; }

    public string ManagerCognitoId { get; set; }
    public Manager Manager { get; set; }

    public List<Lease> Leases { get; set; }
    public List<Application> Applications { get; set; }
}



public class Manager
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string CognitoId { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public List<Property> ManagedProperties { get; set; }
}


public class Tenant
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string CognitoId { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public List<Lease> Leases { get; set; }
    public List<Application> Applications { get; set; }
}


public class Location
{
    [Key]
    public int Id { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }

    public List<Property> Properties { get; set; }
}

public class Application
{
    [Key]
    public int Id { get; set; }

    public DateTime ApplicationDate { get; set; }
    public ApplicationStatus Status { get; set; }

    public int PropertyId { get; set; }
    public Property Property { get; set; }

    public string TenantCognitoId { get; set; }
    public Tenant Tenant { get; set; }

    public int? LeaseId { get; set; }
    public Lease Lease { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
}


public class Lease
{
    [Key]
    public int Id { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public float Rent { get; set; }
    public float Deposit { get; set; }

    public int PropertyId { get; set; }
    public Property Property { get; set; }

    public string TenantCognitoId { get; set; }
    public Tenant Tenant { get; set; }

    public Application Application { get; set; }
    public List<Payment> Payments { get; set; }
}


public class Payment
{
    [Key]
    public int Id { get; set; }
    public float AmountDue { get; set; }
    public float AmountPaid { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    [ForeignKey("Lease")]
    public int LeaseId { get; set; }
    public Lease Lease { get; set; }
}
