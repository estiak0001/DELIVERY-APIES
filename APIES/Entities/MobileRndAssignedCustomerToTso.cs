using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_Assigned_Customer_TO_TSO")]
    public partial class MobileRndAssignedCustomerToTso
    {
        [Key]
        public Guid Id { get; set; }
        [Column("EmployeeTSOID")]
        public Guid EmployeeTsoid { get; set; }
        [Column("AssignedCustomerID")]
        public Guid? AssignedCustomerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }

        [ForeignKey(nameof(EmployeeTsoid))]
        [InverseProperty(nameof(MobileRndEmployeeInformation.MobileRndAssignedCustomerToTso))]
        public virtual MobileRndEmployeeInformation EmployeeTso { get; set; }
    }
}
