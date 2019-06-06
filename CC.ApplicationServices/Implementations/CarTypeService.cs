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
    public class CarTypeService : IService<CarTypeDto>
    {
        public List<CarTypeDto> Get()
        {
            List<CarTypeDto> carTypeDtos = new List<CarTypeDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CarTypeRepository.Get())
                {
                    carTypeDtos.Add(new CarTypeDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description
                    });
                }
            }
            if (carTypeDtos.Count == 0)
                return null;

            return carTypeDtos;
        }

        public CarTypeDto GetById(int id)
        {
            CarTypeDto carTypeDto;

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                CarType carTypeEntity = unitOfWork.CarTypeRepository.GetById(id);

                if (carTypeEntity == null)
                    return null;

                carTypeDto = new CarTypeDto
                {
                    Id = carTypeEntity.Id,
                    Name = carTypeEntity.Name,
                    Description = carTypeEntity.Description
                };
            }
            return carTypeDto;
        }

        public bool Save(CarTypeDto carTypeDto)
        {
            CarType carTypeEntity = new CarType
            {
                Id = carTypeDto.Id,
                Name = carTypeDto.Name,
                Description = carTypeDto.Description
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (carTypeDto.Id == 0)
                    {
                        unitOfWork.CarTypeRepository.Insert(carTypeEntity);
                    }
                    else
                    {
                        unitOfWork.CarTypeRepository.Update(carTypeEntity);
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
                    CarType carTypeEntity = unitOfWork.CarTypeRepository.GetById(id);
                    unitOfWork.CarTypeRepository.Delete(carTypeEntity);
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
