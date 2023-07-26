using crudEMS.Models;

namespace crudEMS.Services
{
    public interface IEmployeeService
    {
        List<MongoEmployee> Get();
        MongoEmployee Get(string id);

        MongoEmployee Create(MongoEmployee registrationModel);

        void Update(string id, MongoEmployee registrationModel);
        void Remove(string id);
    }
}
