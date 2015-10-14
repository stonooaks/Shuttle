using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Hermes.Data.Models.Mapping;

namespace Hermes.Data.Models
{
    public partial class HermesContext : DbContext
    {
        static HermesContext()
        {
            Database.SetInitializer<HermesContext>(null);
        }

        public HermesContext()
            : base("Name=HermesContext")
        {
        }

        public DbSet<Additional> Additionals { get; set; }
        public DbSet<AdditionalTrip> AdditionalTrips { get; set; }
        public DbSet<AdditionalType> AdditionalTypes { get; set; }
        public DbSet<AuthorizedUser> AuthorizedUsers { get; set; }
        public DbSet<BillingAddress> BillingAddresses { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusTime> BusTimes { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<DailyHour> DailyHours { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverShift> DriverShifts { get; set; }
        public DbSet<FamilyRole> FamilyRoles { get; set; }
        public DbSet<GasMileage> GasMileages { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<Intersection> Intersections { get; set; }
        public DbSet<KiawahAddress> KiawahAddresses { get; set; }
        public DbSet<KiawahLocation> KiawahLocations { get; set; }
        public DbSet<Kiawah> Kiawahs { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<POIs> POIs { get; set; }
        public DbSet<Regular> Regulars { get; set; }
        public DbSet<ReturnTrip> ReturnTrips { get; set; }
        public DbSet<RouteStop> RouteStops { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TripLocation> TripLocations { get; set; }
        public DbSet<TripType> TripTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdditionalMap());
            modelBuilder.Configurations.Add(new AdditionalTripMap());
            modelBuilder.Configurations.Add(new AdditionalTypeMap());
            modelBuilder.Configurations.Add(new AuthorizedUserMap());
            modelBuilder.Configurations.Add(new BillingAddressMap());
            modelBuilder.Configurations.Add(new BusMap());
            modelBuilder.Configurations.Add(new BusTimeMap());
            modelBuilder.Configurations.Add(new CostMap());
            modelBuilder.Configurations.Add(new DailyHourMap());
            modelBuilder.Configurations.Add(new DriverMap());
            modelBuilder.Configurations.Add(new DriverShiftMap());
            modelBuilder.Configurations.Add(new FamilyRoleMap());
            modelBuilder.Configurations.Add(new GasMileageMap());
            modelBuilder.Configurations.Add(new GuestMap());
            modelBuilder.Configurations.Add(new HouseholdMap());
            modelBuilder.Configurations.Add(new IntersectionMap());
            modelBuilder.Configurations.Add(new KiawahAddressMap());
            modelBuilder.Configurations.Add(new KiawahLocationMap());
            modelBuilder.Configurations.Add(new KiawahMap());
            modelBuilder.Configurations.Add(new MaintenanceMap());
            modelBuilder.Configurations.Add(new MemberMap());
            modelBuilder.Configurations.Add(new PhoneMap());
            modelBuilder.Configurations.Add(new POIsMap());
            modelBuilder.Configurations.Add(new RegularMap());
            modelBuilder.Configurations.Add(new ReturnTripMap());
            modelBuilder.Configurations.Add(new RouteStopMap());
            modelBuilder.Configurations.Add(new ShoppingCartMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TripLocationMap());
            modelBuilder.Configurations.Add(new TripTypeMap());
            modelBuilder.Configurations.Add(new VehicleMap());
        }
    }
}
