using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string EntityAdded = "Entity added to the system.";
        public static string EntityDeleted;
        public static string EntitiesListed;
        public static string EntityUpdated;
        public static string EntityUpdateError;
        internal static string UserRegistered;
        internal static User PasswordError;
        internal static User UserNotFound;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string? AuthorizationDenied;
    }
}
