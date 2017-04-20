using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmartGridCisApp
{
    public class Service1 : IService1
    {
        public static int _counterIdPerson = 1;
        public static int _counterIdPersonType = 1;

        public List<Person> GetPersons()
        {
            return ObjectLists.Persons;
        }

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="age">The age.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public int CreatePerson(string name, int age, int type)
        {
            if (IsValidPersonType(type))
            {
                var newPerson = new Person()
                {
                    Id = _counterIdPerson++,
                    Name = name,
                    Age = age,
                    Type = type
                };

                ObjectLists.Persons.Add(newPerson);

                Console.WriteLine("The person was created");

                return newPerson.Id;
            }

            Console.WriteLine("The person Type Id:{0} does not exist", type);

            return 0;
        }


        /// <summary>
        /// Deletes the person.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool DeletePerson(int id)
        {
            var deletedPerson = GetPersons().FirstOrDefault(x => x.Id == id);

            if (deletedPerson != null)
            {
                ObjectLists.Persons.Remove(deletedPerson);

                Console.WriteLine("The person was deleted");

                return true;
            }

            Console.WriteLine("The person could not be deleted");

            return false;
        }

        /// <summary>
        /// Updates the person.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="age">The age.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public bool UpdatePerson(int id, string name, int age, int type)
        {
            if (IsValidPersonType(type))
            {
                //Gets the person from list
                var updatedPerson = GetPersons().FirstOrDefault(x => x.Id == id);

                if (updatedPerson != null)
                {
                    updatedPerson.Name = name;
                    updatedPerson.Age = age;
                    updatedPerson.Type = type;

                    Console.WriteLine("The person was updated");

                    return true;
                }
            }

            Console.WriteLine("The person could not be updated");

            return false;
        }

        /// <summary>
        /// Gets the person types.
        /// </summary>
        /// <returns></returns>
        public List<PersonType> GetPersonTypes()
        {
            if (ObjectLists.PersonsTypes != null && ObjectLists.PersonsTypes.Count <= 0)
            {
                ObjectLists.PersonsTypes.Add(new PersonType()
                {
                    Type = 1,
                    Description = "Teachers"
                });

                ObjectLists.PersonsTypes.Add(new PersonType()
                {
                    Type = 2,
                    Description = "Students"
                });
            }

            return ObjectLists.PersonsTypes;
        }

        //public Dictionary<int, string> GetPersonTypes()
        //if (personTypesList != null && personTypesList.Count <= 0)
        //{
        //    personTypesList.Add(1, "Teachers");
        //    personTypesList.Add(2, "Students");
        //}

        //return personTypesList;

        /// <summary>
        /// Gets the type of the person.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private PersonType GetPersonType(int id)
        {
            var current = GetPersonTypes().FirstOrDefault(x => x.Type == id);

            return current;
        }

        /// <summary>
        /// Determines whether [is valid person type] [the specified identifier].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is valid person type] [the specified identifier]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsValidPersonType(int id)
        {
            var persontype = GetPersonType(id);

            return (persontype != null && persontype.Type > 0);
        }

        //private KeyValuePair<int, string> GetPersonType(int id)
        //{
        //    var current = GetPersonTypes().FirstOrDefault(x => x.Key == id);

        //    return current;
        //}
    }
}
