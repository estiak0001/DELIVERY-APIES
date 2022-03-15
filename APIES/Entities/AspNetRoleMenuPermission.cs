using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    public partial class AspNetRoleMenuPermission
    {
        [Key]
        public string RoleId { get; set; }
        [Key]
        public Guid NavigationMenuId { get; set; }

        [ForeignKey(nameof(NavigationMenuId))]
        [InverseProperty(nameof(AspNetNavigationMenu.AspNetRoleMenuPermission))]
        public virtual AspNetNavigationMenu NavigationMenu { get; set; }
    }
}
