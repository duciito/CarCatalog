using CC.ApplicationServices.DTOs;
using CC.Data.Entities;
using CC.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.ApplicationServices.Implementations
{
    public class CarService : IService<CarDto>
    {
        public List<CarDto> Get()
        {
            List<CarDto> carDtos = new List<CarDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CarRepository.Get())
                {
                    carDtos.Add(new CarDto
                    {
                        Id = item.Id,
                        Model = item.Model,
                        ReleaseYear = item.ReleaseYear,
                        HorsePower = item.HorsePower,
                        MakeId = item.MakeId,
                        TypeId = item.TypeId
                    });
                }
            }

            return carDtos;
        }

        public CarDto GetById(int id)
        {
            CarDto carDto;

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Car carEntity = unitOfWork.CarRepository.GetById(id);

                if (carEntity == null)
                    return null;

                carDto = new CarDto
                {
                    Id = carEntity.Id,
                    Model = carEntity.Model,
                    ReleaseYear = carEntity.ReleaseYear,
                    HorsePower = carEntity.HorsePower,
                    MakeId = carEntity.MakeId,
                    TypeId = carEntity.TypeId
                };
            }
            return carDto;
        }

        public bool Save(CarDto carDto)
        {
            Car carEntity = new Car
            {
                Id = carDto.Id,
                Model = carDto.Model,
                ReleaseYear = carDto.ReleaseYear,
                HorsePower = carDto.HorsePower,
                MakeId = carDto.MakeId,
                TypeId = carDto.TypeId
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (carDto.Id == 0)
                    {
                        unitOfWork.CarRepository.Insert(carEntity);
                    }
                    else
                    {
                        unitOfWork.CarRepository.Update(carEntity);
                    }
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Car carEntity = unitOfWork.CarRepository.GetById(id);
                    unitOfWork.CarRepository.Delete(carEntity);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
