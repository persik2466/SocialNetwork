using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class UserAddedFriendView
    {
        public void Show(IEnumerable<Friend> addedFriend)
        {
            SuccessMessage.Show("Ваши друзья");

            if (addedFriend.Count() == 0)
            {
                AlertMessage.Show("У Вас нет друзей");
                return;
            }

            addedFriend.ToList().ForEach(friend =>
            {
                SuccessMessage.Show("Ваш друг "+ friend.FriendFirstName+", адрес: " + friend.FriendEmail);
            });
        }
    }
}
