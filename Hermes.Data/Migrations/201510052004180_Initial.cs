namespace Hermes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Additional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdditionalTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdditionalType", t => t.AdditionalTypeId, cascadeDelete: true)
                .Index(t => t.AdditionalTypeId);
            
            CreateTable(
                "dbo.AdditionalTrip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegularId = c.Int(nullable: false),
                        AdditionalId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Notes = c.String(maxLength: 225),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Additional", t => t.AdditionalId, cascadeDelete: true)
                .ForeignKey("dbo.Regulars", t => t.RegularId, cascadeDelete: true)
                .Index(t => t.RegularId)
                .Index(t => t.AdditionalId);
            
            CreateTable(
                "dbo.Regulars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HHID = c.Int(nullable: false),
                        MemberId = c.Int(),
                        TripTypeId = c.Int(nullable: false),
                        KiawahLocation = c.String(nullable: false, maxLength: 50),
                        TripLocation = c.String(nullable: false, maxLength: 50),
                        NonKiawahPickup = c.Boolean(nullable: false),
                        DriverId = c.Int(),
                        Date = c.DateTime(nullable: false),
                        PickupTime = c.Time(nullable: false, precision: 7),
                        OfficerName = c.String(nullable: false, maxLength: 50),
                        VehicleId = c.Int(),
                        Email = c.String(nullable: false, maxLength: 50),
                        Notes = c.String(),
                        IsCancelled = c.Boolean(nullable: false),
                        otherAddress = c.String(maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Count = c.Int(),
                        Cost = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.Households", t => t.HHID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.TripTypes", t => t.TripTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.HHID)
                .Index(t => t.MemberId)
                .Index(t => t.TripTypeId)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        License = c.String(),
                        ShiftId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DriverShift", t => t.ShiftId)
                .Index(t => t.ShiftId);
            
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StopsId = c.Int(nullable: false),
                        TripTypeId = c.Int(nullable: false),
                        Kiawah_Id = c.Int(),
                        DriverId = c.Int(nullable: false),
                        BusTimeId = c.Int(),
                        Date = c.DateTime(),
                        GuestId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusTime", t => t.BusTimeId)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.GuestId)
                .ForeignKey("dbo.Intersections", t => t.StopsId, cascadeDelete: true)
                .ForeignKey("dbo.Kiawahs", t => t.Kiawah_Id)
                .ForeignKey("dbo.RouteStops", t => t.StopsId, cascadeDelete: true)
                .ForeignKey("dbo.TripTypes", t => t.TripTypeId, cascadeDelete: true)
                .Index(t => t.StopsId)
                .Index(t => t.TripTypeId)
                .Index(t => t.Kiawah_Id)
                .Index(t => t.DriverId)
                .Index(t => t.BusTimeId)
                .Index(t => t.GuestId);
            
            CreateTable(
                "dbo.BusTime",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StopTime = c.Time(precision: 7),
                        StopLocation = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        RegularId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regulars", t => t.RegularId, cascadeDelete: true)
                .Index(t => t.RegularId);
            
            CreateTable(
                "dbo.Intersections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        POIId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.POIs", t => t.POIId, cascadeDelete: true)
                .Index(t => t.POIId);
            
            CreateTable(
                "dbo.POIs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RouteStops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        POIId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.POIs", t => t.POIId, cascadeDelete: false)
                .Index(t => t.POIId);
            
            CreateTable(
                "dbo.Kiawahs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        FamilyRolesId = c.Int(),
                        Email = c.String(),
                        HouseholdId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyRoles", t => t.FamilyRolesId)
                .ForeignKey("dbo.Households", t => t.HouseholdId, cascadeDelete: true)
                .Index(t => t.FamilyRolesId)
                .Index(t => t.HouseholdId);
            
            CreateTable(
                "dbo.FamilyRoles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(maxLength: 50),
                        AuthorizedUser = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Households",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorizedUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseholdId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        DateCreated = c.DateTime(),
                        DateExpired = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Households", t => t.HouseholdId, cascadeDelete: true)
                .Index(t => t.HouseholdId);
            
            CreateTable(
                "dbo.BillingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                        Address1 = c.String(),
                        HouseholdId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Households", t => t.HouseholdId)
                .Index(t => t.HouseholdId);
            
            CreateTable(
                "dbo.KiawahAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address1 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.TripTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Costs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        twoperprice = c.Double(),
                        addperprice = c.Double(),
                        TripTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TripTypes", t => t.TripTypeId)
                .Index(t => t.TripTypeId);
            
            CreateTable(
                "dbo.DriverShift",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DriverShift = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReturnTrip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegularId = c.Int(nullable: false),
                        PickupTime = c.Time(precision: 7),
                        TripLocation = c.String(maxLength: 50),
                        KiawahLocation = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regulars", t => t.RegularId, cascadeDelete: false )
                .Index(t => t.RegularId);
            
            CreateTable(
                "dbo.ShoppingCart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegularId = c.Int(nullable: false),
                        TotalCost = c.Double(),
                        ShoppingCartDate = c.DateTime(),
                        HouseholdID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regulars", t => t.RegularId, cascadeDelete: true)
                .Index(t => t.RegularId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DailyHours",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                        Miles = c.Double(nullable: false),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.GasMileages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Mileage = c.Single(nullable: false),
                        Gallons = c.Single(nullable: false),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Maintenance",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Date = c.DateTime(),
                        Type = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Cost = c.Double(),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.AdditionalType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KiawahLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Directions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.TripLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Directions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ownership",
                c => new
                    {
                        HouseholdId = c.Int(nullable: false),
                        KiawahLocationsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HouseholdId, t.KiawahLocationsId })
                .ForeignKey("dbo.Households", t => t.HouseholdId, cascadeDelete: true)
                .ForeignKey("dbo.KiawahAddresses", t => t.KiawahLocationsId, cascadeDelete: true)
                .Index(t => t.HouseholdId)
                .Index(t => t.KiawahLocationsId);
            
            CreateTable(
                "dbo.RegularTrips",
                c => new
                    {
                        MemberId = c.Int(nullable: false),
                        RegularId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberId, t.RegularId })
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Regulars", t => t.RegularId, cascadeDelete: false)
                .Index(t => t.MemberId)
                .Index(t => t.RegularId);
            
            CreateTable(
                "dbo.BusTrips",
                c => new
                    {
                        BusId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BusId, t.MemberId })
                .ForeignKey("dbo.Buses", t => t.BusId, cascadeDelete: false)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.BusId)
                .Index(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Additional", "AdditionalTypeId", "dbo.AdditionalType");
            DropForeignKey("dbo.AdditionalTrip", "RegularId", "dbo.Regulars");
            DropForeignKey("dbo.Regulars", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Maintenance", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.GasMileages", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.DailyHours", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Regulars", "TripTypeId", "dbo.TripTypes");
            DropForeignKey("dbo.ShoppingCart", "RegularId", "dbo.Regulars");
            DropForeignKey("dbo.ReturnTrip", "RegularId", "dbo.Regulars");
            DropForeignKey("dbo.Regulars", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Regulars", "HHID", "dbo.Households");
            DropForeignKey("dbo.Regulars", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "ShiftId", "dbo.DriverShift");
            DropForeignKey("dbo.Buses", "TripTypeId", "dbo.TripTypes");
            DropForeignKey("dbo.Costs", "TripTypeId", "dbo.TripTypes");
            DropForeignKey("dbo.Buses", "StopsId", "dbo.RouteStops");
            DropForeignKey("dbo.BusTrips", "MemberId", "dbo.Members");
            DropForeignKey("dbo.BusTrips", "BusId", "dbo.Buses");
            DropForeignKey("dbo.RegularTrips", "RegularId", "dbo.Regulars");
            DropForeignKey("dbo.RegularTrips", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Phones", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "HouseholdId", "dbo.Households");
            DropForeignKey("dbo.Ownership", "KiawahLocationsId", "dbo.KiawahAddresses");
            DropForeignKey("dbo.Ownership", "HouseholdId", "dbo.Households");
            DropForeignKey("dbo.BillingAddresses", "HouseholdId", "dbo.Households");
            DropForeignKey("dbo.AuthorizedUsers", "HouseholdId", "dbo.Households");
            DropForeignKey("dbo.Members", "FamilyRolesId", "dbo.FamilyRoles");
            DropForeignKey("dbo.Buses", "Kiawah_Id", "dbo.Kiawahs");
            DropForeignKey("dbo.Buses", "StopsId", "dbo.Intersections");
            DropForeignKey("dbo.Intersections", "POIId", "dbo.POIs");
            DropForeignKey("dbo.RouteStops", "POIId", "dbo.POIs");
            DropForeignKey("dbo.Buses", "GuestId", "dbo.Guests");
            DropForeignKey("dbo.Guests", "RegularId", "dbo.Regulars");
            DropForeignKey("dbo.Buses", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Buses", "BusTimeId", "dbo.BusTime");
            DropForeignKey("dbo.AdditionalTrip", "AdditionalId", "dbo.Additional");
            DropIndex("dbo.BusTrips", new[] { "MemberId" });
            DropIndex("dbo.BusTrips", new[] { "BusId" });
            DropIndex("dbo.RegularTrips", new[] { "RegularId" });
            DropIndex("dbo.RegularTrips", new[] { "MemberId" });
            DropIndex("dbo.Ownership", new[] { "KiawahLocationsId" });
            DropIndex("dbo.Ownership", new[] { "HouseholdId" });
            DropIndex("dbo.Maintenance", new[] { "VehicleId" });
            DropIndex("dbo.GasMileages", new[] { "VehicleId" });
            DropIndex("dbo.DailyHours", new[] { "VehicleId" });
            DropIndex("dbo.ShoppingCart", new[] { "RegularId" });
            DropIndex("dbo.ReturnTrip", new[] { "RegularId" });
            DropIndex("dbo.Costs", new[] { "TripTypeId" });
            DropIndex("dbo.Phones", new[] { "MemberId" });
            DropIndex("dbo.BillingAddresses", new[] { "HouseholdId" });
            DropIndex("dbo.AuthorizedUsers", new[] { "HouseholdId" });
            DropIndex("dbo.Members", new[] { "HouseholdId" });
            DropIndex("dbo.Members", new[] { "FamilyRolesId" });
            DropIndex("dbo.RouteStops", new[] { "POIId" });
            DropIndex("dbo.Intersections", new[] { "POIId" });
            DropIndex("dbo.Guests", new[] { "RegularId" });
            DropIndex("dbo.Buses", new[] { "GuestId" });
            DropIndex("dbo.Buses", new[] { "BusTimeId" });
            DropIndex("dbo.Buses", new[] { "DriverId" });
            DropIndex("dbo.Buses", new[] { "Kiawah_Id" });
            DropIndex("dbo.Buses", new[] { "TripTypeId" });
            DropIndex("dbo.Buses", new[] { "StopsId" });
            DropIndex("dbo.Drivers", new[] { "ShiftId" });
            DropIndex("dbo.Regulars", new[] { "VehicleId" });
            DropIndex("dbo.Regulars", new[] { "DriverId" });
            DropIndex("dbo.Regulars", new[] { "TripTypeId" });
            DropIndex("dbo.Regulars", new[] { "MemberId" });
            DropIndex("dbo.Regulars", new[] { "HHID" });
            DropIndex("dbo.AdditionalTrip", new[] { "AdditionalId" });
            DropIndex("dbo.AdditionalTrip", new[] { "RegularId" });
            DropIndex("dbo.Additional", new[] { "AdditionalTypeId" });
            DropTable("dbo.BusTrips");
            DropTable("dbo.RegularTrips");
            DropTable("dbo.Ownership");
            DropTable("dbo.TripLocations");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.KiawahLocations");
            DropTable("dbo.AdditionalType");
            DropTable("dbo.Maintenance");
            DropTable("dbo.GasMileages");
            DropTable("dbo.DailyHours");
            DropTable("dbo.Vehicles");
            DropTable("dbo.ShoppingCart");
            DropTable("dbo.ReturnTrip");
            DropTable("dbo.DriverShift");
            DropTable("dbo.Costs");
            DropTable("dbo.TripTypes");
            DropTable("dbo.Phones");
            DropTable("dbo.KiawahAddresses");
            DropTable("dbo.BillingAddresses");
            DropTable("dbo.AuthorizedUsers");
            DropTable("dbo.Households");
            DropTable("dbo.FamilyRoles");
            DropTable("dbo.Members");
            DropTable("dbo.Kiawahs");
            DropTable("dbo.RouteStops");
            DropTable("dbo.POIs");
            DropTable("dbo.Intersections");
            DropTable("dbo.Guests");
            DropTable("dbo.BusTime");
            DropTable("dbo.Buses");
            DropTable("dbo.Drivers");
            DropTable("dbo.Regulars");
            DropTable("dbo.AdditionalTrip");
            DropTable("dbo.Additional");
        }
    }
}
