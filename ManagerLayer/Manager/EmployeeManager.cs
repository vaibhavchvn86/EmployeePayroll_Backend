
using ManagerLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository repo;
        public EmployeeManager (IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public async Task<RegisterModel> AddEmp(RegisterModel add)
        {
            try
            {
                return await this.repo.AddEmp(add);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RegisterModel> DeleteEmp(string id)
        {
            try
            {
                return await this.repo.DeleteEmp(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RegisterModel> EditEmp(RegisterModel edit)
        {
            try
            {
                return await this.repo.EditEmp(edit);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<RegisterModel> GetEmp()
        {
            try
            {
                return this.repo.GetEmp();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
