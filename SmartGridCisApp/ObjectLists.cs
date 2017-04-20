using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridCisApp
{
    /// <summary>
    /// This class represents the list of Person and PersonTypes
    /// </summary>
    public class ObjectLists
    {
        private static List<Person> _persons;
        public static List<Person> Persons
        {
            get { return _persons ?? (_persons = new List<Person>()); }
            set { _persons = value; }
        }

        private static List<PersonType> _personsTypes;
        public static List<PersonType> PersonsTypes
        {
            get { return _personsTypes ?? (_personsTypes = new List<PersonType>()); }
            set { _personsTypes = value; }
        }
    }
}