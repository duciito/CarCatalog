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
    public class CarMakeService : IService<CarMakeDto>
    {
        public List<CarMakeDto> Get()
        {
            List<CarMakeDto> carMakeDtos = new List<CarMakeDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CarMakeRepository.Get())
                {
                    carMakeDtos.Add(new CarMakeDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Country = item.Country,
                        Description = item.Description
                    });
                }
            }
            if (carMakeDtos.Count == 0)
                return null;

            return carMakeDtos;
        }

        public CarMakeDto GetById(int id)
        {
            CarMakeDto carMakeDto;

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                CarMake carMakeEntity = unitOfWork.CarMakeRepository.GetById(id);

                if (carMakeEntity == null)
                    return null;

                carMakeDto = new CarMakeDto
                {
                    Id = carMakeEntity.Id,
                    Name = carMakeEntity.Name,
                    Country = carMakeEntity.Country,
                    Description = carMakeEntity.Description
                };
            }
            return carMakeDto;
        }

        public bool Save(CarMakeDto carMakeDto)
        {
            CarMake carMakeEntity = new CarMake
            {
                Id = carMakeDto.Id,
                Name = carMakeDto.Name,
                Country = carMakeDto.Country,
                Description = carMakeDto.Description
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (carMakeDto.Id == 0)
                    {
                        unitOfWork.CarMakeRepository.Insert(carMakeEntity);
                    }
                    else
                    {
                        unitOfWork.CarMakeRepository.Update(carMakeEntity);
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
                    CarMake carMakeEntity = unitOfWork.CarMakeRepository.GetById(id);
                    unitOfWork.CarMakeRepository.Delete(carMakeEntity);
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
