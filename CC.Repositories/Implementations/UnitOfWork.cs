using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Data.Entities;
using CC.Data.Contexts;

namespace CC.Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private CarCatalogDbContext context = new CarCatalogDbContext();
        private GenericRepository<Car> carRepository;
        private GenericRepository<CarMake> carMakeRepository;
        private GenericRepository<CarType> carTypeRepository;

        public GenericRepository<Car> CarRepository
        {
            get
            {

                if (this.carRepository == null)
                {
                    this.carRepository = new GenericRepository<Car>(context);
                }
                return carRepository;
            }
        }

        public GenericRepository<CarMake> CarMakeRepository
        {
            get
            {

                if (this.carMakeRepository == null)
                {
                    this.carMakeRepository = new GenericRepository<CarMake>(context);
                }
                return carMakeRepository;
            }
        }

        public GenericRepository<CarType> CarTypeRepository
        {
            get
            {

                if (this.carTypeRepository == null)
                {
                    this.carTypeRepository = new GenericRepository<CarType>(context);
                }
                return carTypeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
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
