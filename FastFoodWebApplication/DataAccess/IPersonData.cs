using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.DataAccess
{
    public interface IPersonData
    {
        void CreatePerson(PersonModel personModel);

        void DeletePerson(int personId);

        void EditPerson(int personId);
    }
}
