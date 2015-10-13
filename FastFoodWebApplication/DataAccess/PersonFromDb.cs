using System;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.DataAccess
{
    public class PersonFromDb: IPersonData
    {
        private readonly FastFoodDbEntities FastFoodDbEntitiesInstance;
        public PersonFromDb()
        {
            FastFoodDbEntitiesInstance = new FastFoodDbEntities();
        }

        public void CreatePerson(PersonModel personModel)
        {
            
            var person = new Person();
            person.Address = personModel.Address;
            person.Name = personModel.Name;
            person.Nit = personModel.Nit;
            person.AddressLatitude = personModel.AddressLatitude;
            person.AddressLongitude = personModel.AddressLongitude;
            person.CreatedDate = DateTime.UtcNow;
            person.PhoneNumber = personModel.PhoneNumber;

            FastFoodDbEntitiesInstance.Persons.Add(person);
            FastFoodDbEntitiesInstance.SaveChanges();

        }


        public void DeletePerson(int personId)
        {
            throw new NotImplementedException();
        }

        public void EditPerson(int personId)
        {
            throw new NotImplementedException();
        }
    }
}