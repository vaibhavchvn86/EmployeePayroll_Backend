using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interface
{
    public interface IEmployeeManager
    {
        Task<RegisterModel> AddEmp(RegisterModel add);
        Task<RegisterModel> EditEmp(RegisterModel edit);
        Task<RegisterModel> DeleteEmp(RegisterModel del);
        IEnumerable<RegisterModel> GetEmp();
    }
}
