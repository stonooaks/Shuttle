
using Hermes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Service
{
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// Common Database Context
        /// </summary>
        private HermesContext context = new HermesContext();
        
        /// <summary>
        /// Creating repositories from the general repository
        /// </summary>
        private GenericRepository<Regular> regularRepository;
        //private GenericRepository<RegularReturn> regularReturnRepository;
        private GenericRepository<Bus> busRepository;
        //private GenericRepository<BusReturn> busReturnRepository;
        private GenericRepository<TripType> tripTypeRepository;
        private GenericRepository<RouteStop> routeStopRepository;
        private GenericRepository<Intersection> intersectionRepository;
        private GenericRepository<Kiawah> kiawahRepository;
        private GenericRepository<Driver> driverRepository;
        private GenericRepository<POIs> poiRepository;
        //private GenericRepository<Location> locationRepository;
        private GenericRepository<Cost> costRepository;
        private GenericRepository<Vehicle> vehicleRepository;
        private GenericRepository<Member> memberRepository;
        private GenericRepository<KiawahLocation> kiawahLocationRepository;
        private GenericRepository<Household> householdRepository;
        private GenericRepository<TripLocation> tripLocationRepository;

        #region Repositories
        /// <summary>
        /// Repository for the Regular Trip
        /// </summary>
        public GenericRepository<Regular> RegularRepository
        {
            get
            {
                if (this.regularRepository == null) {

                    this.regularRepository = new GenericRepository<Regular>(context);
                }
                return regularRepository;
            }
        }

        /// <summary>
        /// Repository for the Regular Return Trip
        /// </summary>
        //public GenericRepository<RegularReturn> RegularReturnRepository
        //{
        //    get
        //    {
        //        if (this.regularReturnRepository == null) {

        //            this.regularReturnRepository = new GenericRepository<RegularReturn>(context);
        //        }
        //        return regularReturnRepository;
        //    }
        //}

        /// <summary>
        /// Repository for the Bus Trip
        /// </summary>
        public GenericRepository<Bus> BusRepository
        {
            get
            {
                if (this.busRepository == null) {

                    this.busRepository = new GenericRepository<Bus>(context);
                }
                return busRepository;
            }
        }

        /// <summary>
        /// Repository for the Bus Return Trip
        /// </summary>
        //public GenericRepository<BusReturn> BusReturnRepository
        //{
        //    get
        //    {
        //        if (this.busReturnRepository == null) {

        //            this.busReturnRepository = new GenericRepository<BusReturn>(context);
        //        }
        //        return busReturnRepository;
        //    }
        //}
        
        /// <summary>
        /// Repository for the TripType        /// </summary>
        public GenericRepository<TripType> TripTypeRepository
        {
            get
            {
                if (this.tripTypeRepository == null) {

                    this.tripTypeRepository = new GenericRepository<TripType>(context);
                }
                return tripTypeRepository;
            }
        }

        /// <summary>
        /// Repository for the RouteStops
        /// </summary>
        public GenericRepository<RouteStop> RouteStopRepository
        {
            get
            {
                if (this.routeStopRepository == null) {

                    this.routeStopRepository = new GenericRepository<RouteStop>(context);
                }
                return routeStopRepository;
            }
        }

        /// <summary>
        /// Repository for the Intersections
        /// </summary>
        public GenericRepository<Intersection> IntersectionRepository
        {
            get
            {
                if (this.intersectionRepository == null) {

                    this.intersectionRepository = new GenericRepository<Intersection>(context);
                }
                return intersectionRepository;
            }
        }

        /// <summary>
        /// Repository for the KiawahBusStops
        /// </summary>
        public GenericRepository<Kiawah> KiawahRepository
        {
            get
            {
                if (this.kiawahRepository == null) {

                    this.kiawahRepository = new GenericRepository<Kiawah>(context);
                }
                return kiawahRepository;
            }
        }

        /// <summary>
        /// Repository for the Driver
        /// </summary>
        public GenericRepository<Driver> DriverRepository
        {
            get
            {
                if (this.driverRepository == null) {

                    this.driverRepository = new GenericRepository<Driver>(context);
                }
                return driverRepository;
            }
        }

        /// <summary>
        /// Repository for the Bus Return Trip
        /// </summary>
        public GenericRepository<POIs> POIRepository
        {
            get
            {
                if (this.poiRepository == null) {

                    this.poiRepository = new GenericRepository<POIs>(context);
                }
                return poiRepository;
            }
        }

        /// <summary>
        /// Repository for the Bus Return Trip
        /// </summary>
        //public GenericRepository<Location> LocationRepository
        //{
        //    get
        //    {
        //        if (this.locationRepository == null) {

        //            this.locationRepository = new GenericRepository<Location>(context);
        //        }
        //        return locationRepository;
        //    }
        //}

        /// <summary>
        /// Repository for the Bus Return Trip
        /// </summary>
        public GenericRepository<Cost> CostRepository
        {
            get
            {
                if (this.costRepository == null) {

                    this.costRepository = new GenericRepository<Cost>(context);
                }
                return costRepository;
            }
        }

        /// <summary>
        /// Repository for the Bus Return Trip
        /// </summary>
        public GenericRepository<Vehicle> VehicleRepository
        {
            get
            {
                if (this.vehicleRepository == null) {

                    this.vehicleRepository = new GenericRepository<Vehicle>(context);
                }
                return vehicleRepository;
            }
        }

        #endregion

        public GenericRepository<Member> MemberRepository
        {
            get
            {
                if (this.memberRepository == null) {
                    this.memberRepository = new GenericRepository<Member>(context);
                }
                return memberRepository;
            }
        }

        public GenericRepository<TripLocation> TripLocationRepository
        {
            get
            {
                if (this.tripLocationRepository == null) {
                    this.tripLocationRepository = new GenericRepository<TripLocation>(context);
                }
                return tripLocationRepository;
            }
        }

        public GenericRepository<KiawahLocation> KiawahLocationRepository
        {
            get
            {
                if (this.kiawahLocationRepository== null) {
                    this.kiawahLocationRepository = new GenericRepository<KiawahLocation>(context);
                }
                return kiawahLocationRepository;
            }
        }

        public GenericRepository<Household> HouseholdRepository
        {
            get
            {
                if (this.householdRepository == null) {
                    this.householdRepository = new GenericRepository<Household>(context);
                }
                return householdRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed) {
                
                context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
    }
}
