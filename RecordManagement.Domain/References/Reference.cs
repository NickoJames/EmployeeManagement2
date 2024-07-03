using RecordManagement.Domain.Common.Models;
using RecordManagement.Domain.References.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace RecordManagement.Domain.References;
    public class Reference : Entity<ReferenceId>
        {
     
        public string Name { get; }
        public string ContactInformation { get; }

        private Reference(string name, string contactInformation
           ) : base(ReferenceId.CreateUnique())
        {
            Name = name;
            ContactInformation = contactInformation;
        }

        public static Reference Create(
            string name,
            string contactInformation)
            {
        return new Reference(name ,contactInformation
           );       
            }


    



#pragma warning disable CS8618 
    private Reference() { }
#pragma warning restore CS8618
}