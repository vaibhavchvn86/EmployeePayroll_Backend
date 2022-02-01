using ModelLayer;
using MongoDB.Driver;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<RegisterModel> Employee;
        public EmployeeRepository(IDBSetting db)
        {
            var client = new MongoClient(db.ConnectionString);
            var database = client.GetDatabase(db.DatabaseName);
            Employee = database.GetCollection<RegisterModel>("Employee");
        }

        public async Task<RegisterModel> AddEmp(RegisterModel add)
        {
            try
            {
                var check = await this.Employee.Find(x => x.UserID == add.UserID).SingleOrDefaultAsync();
                if(check == null)
                {
                    await this.Employee.InsertOneAsync(add);
                    return add;

                }
                return null;

            }
            catch(ArgumentNullException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RegisterModel> DeleteEmp(string id)
        {
            try
            {
                return await this.Employee.FindOneAndDeleteAsync(x => x.UserID == id);

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
                var checkEmp = await this.Employee.Find(x => x.UserID == edit.UserID).FirstOrDefaultAsync();
                if (checkEmp != null)
                {
                    await this.Employee.UpdateOneAsync(x => x.UserID == edit.UserID,
                                Builders<RegisterModel>.Update.Set(x => x.Name, edit.Name)
                                .Set(x => x.Gender, edit.Gender)
                                .Set(x => x.Department, edit.Department)
                                .Set(x => x.Salary, edit.Salary)
                                .Set(x => x.StartDate, edit.StartDate)
                                .Set(x => x.Notes, edit.Notes));
                    return edit;
                }
                return null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<RegisterModel> GetEmp()
        {
            return Employee.Find(FilterDefinition<RegisterModel>.Empty).ToList();
        }
    }
}
