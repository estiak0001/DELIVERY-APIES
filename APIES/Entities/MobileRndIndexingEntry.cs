using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    [Table("MobileRND_IndexingEntry")]
    public partial class MobileRndIndexingEntry
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        [Required]
        [StringLength(50)]
        public string Grade { get; set; }
        [Required]
        [StringLength(50)]
        public string Block { get; set; }
        [Required]
        [StringLength(50)]
        public string RackNo { get; set; }
        [Required]
        [StringLength(50)]
        public string StageNo { get; set; }
        [Required]
        [StringLength(50)]
        public string ColumNo { get; set; }
        public DateTime IndexingDate { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("LUser")]
        public Guid Luser { get; set; }
    }
}
