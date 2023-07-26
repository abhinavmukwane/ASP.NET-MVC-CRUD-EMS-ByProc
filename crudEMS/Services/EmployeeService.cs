using crudEMS.Models;
using MongoDB.Driver;

namespace crudEMS.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IMongoCollection<MongoEmployee> _Registration;

        public MongoEmployee Create(MongoEmployee registrationModel)
        {
            throw new NotImplementedException();
        }

        public List<MongoEmployee> Get()
        {
            throw new NotImplementedException();
        }

        public MongoEmployee Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, MongoEmployee registrationModel)
        {
            throw new NotImplementedException();
        }
    }
}
