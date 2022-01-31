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
        IEnumerable<RegisterModel> GetEmp();
    }
}
