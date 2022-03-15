using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_EmployeeInformation")]
    public partial class MobileRndEmployeeInformation
    {
        public MobileRndEmployeeInformation()
        {
            MobileRndAssignedAsmToDnsm = new HashSet<MobileRndAssignedAsmToDnsm>();
            MobileRndAssignedCustomerToTso = new HashSet<MobileRndAssignedCustomerToTso>();
            MobileRndAssignedTsoToAsm = new HashSet<MobileRndAssignedTsoToAsm>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column("EmployeeID")]
        [StringLength(150)]
        public string EmployeeId { get; set; }
        [Required]
        [StringLength(250)]
        public string EmployeeName { get; set; }
        [Required]
        [StringLength(150)]
        public string ContactNumber { get; set; }
        public Guid Brand { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }
        [Required]
        [StringLength(150)]
        public string EmployeeType { get; set; }

        [InverseProperty("EmployeeDnsm")]
        public virtual ICollection<MobileRndAssignedAsmToDnsm> MobileRndAssignedAsmToDnsm { get; set; }
        [InverseProperty("EmployeeTso")]
        public virtual ICollection<MobileRndAssignedCustomerToTso> MobileRndAssignedCustomerToTso { get; set; }
        [InverseProperty("EmployeeAsm")]
        public virtual ICollection<MobileRndAssignedTsoToAsm> MobileRndAssignedTsoToAsm { get; set; }
    }
}
