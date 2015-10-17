namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class StudentContactInformation
    {
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        [Column("Email")]
        public string EmailAddress { get; set; }

        [MaxLength(20)]
        [Column("Phone")]
        public string PhoneNumber { get; set; }
    }
}
