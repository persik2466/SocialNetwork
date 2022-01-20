using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddView
    {
        UserService userService;
        FriendService friendService;

        public FriendAddView(UserService userService, FriendService friendService)
        {
            this.userService = userService;
            this.friendService = friendService;
        }

          public void Show(User user)
        {
            var friendData = new FriendData();

            Console.Write("Введите почтовый адрес друга: ");
            friendData.FriendEmail = Console.ReadLine();

            friendData.UserId = user.Id;

            try
            {
                friendService.FriendAdd(friendData);

                SuccessMessage.Show("Друг добавлен!");

                //user = userService.FindById(user.Id);
                user = userService.FindByEmail(friendData.FriendEmail);
                SuccessMessage.Show("Вашего друга зовут " + user.FirstName);

            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга!");
            }
        }
    }
}
