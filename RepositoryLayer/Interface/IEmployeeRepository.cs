using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRepository
    {
        Task<RegisterModel> AddEmp(RegisterModel add);
        Task<RegisterModel> EditEmp(RegisterModel edit);
        Task<RegisterModel> DeleteEmp(string id);
        IEnumerable<RegisterModel> GetEmp();
    }
}
