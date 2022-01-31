using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRepository
    {
        Task<RegisterModel> AddEmp(RegisterModel add);
        IEnumerable<RegisterModel> GetEmp();
    }
}
