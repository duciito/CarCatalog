using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.ApplicationServices.Implementations
{
    public interface IService<TDto>
    {
        List<TDto> Get();
        TDto GetById(int id);
        bool Save(TDto dto);
        bool Delete(int id);
    }
}
