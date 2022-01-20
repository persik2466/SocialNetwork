using System.Text;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }
        public IEnumerable<Friend> GetAddedFriendByUserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(m =>
            {
                var userUserEntity = userRepository.FindById(m.user_id);
                var friendUserEntity = userRepository.FindById(m.friend_id);

                friends.Add(new Friend(m.id, userUserEntity.email, friendUserEntity.email, friendUserEntity.firstname));
            });

            return friends;
        } 
        public void FriendAdd(FriendData friendData)
        {
            var findUserEntity = this.userRepository.FindByEmail(friendData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendData.UserId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
