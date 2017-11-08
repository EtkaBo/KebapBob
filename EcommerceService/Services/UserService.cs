using DatabaseModel;
using EcommerceService.Services;
using EcommerceService.UnitOfWork;
using KebapBobModels.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
namespace KebapBobService.Services
{
    public class UserService : IUserService
    {
        UserViewModel _user;
        private readonly UnitOfWork _unitOfWork;
        //private KebapBobEntities _db;
        public UserService()
        {
            _user = new UserViewModel();
            _unitOfWork = new UnitOfWork();
        }

        //public User GetUserFromLogin(string username, string password)
        //{
        //    return _db.User.FirstOrDefault(x => x.UserName == username && x.Password == password);
        //}



        public int Authenticate(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.Get(u => u.UserName == userName && u.Password == password);
            if (user != null && user.Id > 0)
            {
                return user.Id;
            }
            return 0;
        }


        public void Register(UserViewModel user)
        {
            using (var context = new KebapBobEntities())
            {
                var existingUser = context.User.FirstOrDefault(x => x.UserName == user.UserName);

                if (existingUser != default(User)) // null 

                {
                    throw new ArgumentException("User already exists!");
                }
                var newUser = new User
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password
                };
                context.User.Add(newUser);
                context.SaveChanges();
            }
        }
    }
}