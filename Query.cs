using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace GraphCocoApp
{
    public class Query
    {
        /// <summary>
        /// Gets all the Users.
        /// </summary>
        [UseFirstOrDefault]
        [UseSelection]
        public IQueryable<ConnectUser> GetUserById([Service]ConnectContext context, string UserId) =>
            context.ConnectUsers.Where(t => t.Id.Equals(UserId));

        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ConnectUser> GetUsers([Service]ConnectContext context) =>
            context.ConnectUsers;

    }
}
