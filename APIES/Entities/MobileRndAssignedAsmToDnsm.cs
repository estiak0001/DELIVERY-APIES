using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_Assigned_ASM_TO_DNSM")]
    public partial class MobileRndAssignedAsmToDnsm
    {
        [Key]
        public Guid Id { get; set; }
        [Column("EmployeeDNSMID")]
        public Guid EmployeeDnsmid { get; set; }
        [Column("AssignedEmployeeASMID")]
        public Guid? AssignedEmployeeAsmid { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }

        [ForeignKey(nameof(EmployeeDnsmid))]
        [InverseProperty(nameof(MobileRndEmployeeInformation.MobileRndAssignedAsmToDnsm))]
        public virtual MobileRndEmployeeInformation EmployeeDnsm { get; set; }
    }
}
