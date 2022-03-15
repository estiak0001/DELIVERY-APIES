using APIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIES.Helper
{
    public static class ExtensionMethods
    {
        public static IEnumerable<AspNetUsers> WithoutPasswords(this IEnumerable<AspNetUsers> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static AspNetUsers WithoutPassword(this AspNetUsers user)
        {
            if (user == null) return null;

            user.PasswordHash = null;
            return user;
        }
    }
}