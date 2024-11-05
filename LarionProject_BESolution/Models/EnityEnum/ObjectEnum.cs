using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EnityEnum
{
    public class ObjectEnum
    {
        public enum PostEnum
        {
            Inactive = 0,
            Active = 1,
            Private = 2, 
            FriendOnly = 3
        }

        public enum FavoriteEnum
        {
            Inactive = 0,
            Active = 1
        }
    }
}
