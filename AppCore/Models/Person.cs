using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models
{
    public abstract class Person
    {
        [Key]
        public int? PersonId { get; set; }
        public string? IDNP { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public virtual void SetUpdate(Person person)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
            Email = person.Email;
            Phone = person.Phone;
            DateOfBirth = person.DateOfBirth;
            IDNP = person.IDNP;
        }
        
    }
}
