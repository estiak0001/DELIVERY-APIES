using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_Assigned_TSO_TO_ASM")]
    public partial class MobileRndAssignedTsoToAsm
    {
        [Key]
        public Guid Id { get; set; }
        [Column("EmployeeASMID")]
        public Guid EmployeeAsmid { get; set; }
        [Column("AssignedEmployeeTSOID")]
        public Guid? AssignedEmployeeTsoid { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }

        [ForeignKey(nameof(EmployeeAsmid))]
        [InverseProperty(nameof(MobileRndEmployeeInformation.MobileRndAssignedTsoToAsm))]
        public virtual MobileRndEmployeeInformation EmployeeAsm { get; set; }
    }
}
