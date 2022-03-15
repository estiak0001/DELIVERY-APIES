using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIES.Entities
{
    public partial class AspNetNavigationMenu
    {
        public AspNetNavigationMenu()
        {
            AspNetRoleMenuPermission = new HashSet<AspNetRoleMenuPermission>();
            InverseParentMenu = new HashSet<AspNetNavigationMenu>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string Area { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsExternal { get; set; }
        public string ExternalUrl { get; set; }
        public int DisplayOrder { get; set; }
        public bool Visible { get; set; }

        [ForeignKey(nameof(ParentMenuId))]
        [InverseProperty(nameof(AspNetNavigationMenu.InverseParentMenu))]
        public virtual AspNetNavigationMenu ParentMenu { get; set; }
        [InverseProperty("NavigationMenu")]
        public virtual ICollection<AspNetRoleMenuPermission> AspNetRoleMenuPermission { get; set; }
        [InverseProperty(nameof(AspNetNavigationMenu.ParentMenu))]
        public virtual ICollection<AspNetNavigationMenu> InverseParentMenu { get; set; }
    }
}
