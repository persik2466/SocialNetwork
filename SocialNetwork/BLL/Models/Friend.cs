using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; }
        public string UserEmail { get; }
        public string FriendEmail { get; }
        public string FriendFirstName { get; }

        public Friend(int id, string userEmail, string friendEmail, string friendFirstName)
        {
            this.Id = id;
            this.UserEmail = userEmail;
            this.FriendEmail = friendEmail;
            this.FriendFirstName = friendFirstName;
        }
    }
}
