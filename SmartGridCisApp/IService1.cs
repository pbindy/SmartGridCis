using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmartGridCisApp
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Person> GetPersons();

        [OperationContract]
        int CreatePerson(string name, int age, int type);

        [OperationContract]
        bool DeletePerson(int id);

        [OperationContract]
        bool UpdatePerson(int id, string name, int age, int type);

        [OperationContract]
        //Dictionary<int, string> GetPersonTypes();
        List<PersonType> GetPersonTypes();
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public int Type { get; set; }
    }

    [DataContract]
    public class PersonType
    {
        [DataMember]
        public int Type { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
