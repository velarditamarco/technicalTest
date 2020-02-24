using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechTest.Models;

namespace TechTest.Implementation
{
    public class UsersLogic : IUsersLogic
    {
        public void CreateUser(UsersViewModel newUser)
        {
            using (UsersDataModel data = new UsersDataModel())
            {
                var userToInsert = new User
                {
                    ID = Guid.NewGuid(),
                    FirstName = newUser.Name,
                    LastName = newUser.LastName,
                    BirthDate = newUser.BirthDate,
                    Email = newUser.Email,
                    MobileNumber = newUser.PhoneNumber
                };

                try
                {
                    data.Users.Add(userToInsert);
                    data.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

               
            }
        }

        public void DeleteUser(Guid id)
        {
            using (UsersDataModel data = new UsersDataModel())
            {
                var userToDelete = data.Users.FirstOrDefault(x => x.ID == id);

                if (userToDelete == null)
                    throw new Exception("User not found!");

                try
                {
                    data.Users.Remove(userToDelete);
                    data.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                
            }
        }

        public List<UsersViewModel> Get()
        {
            using (UsersDataModel data = new UsersDataModel())
            {
                return data.Users.Select(x => new UsersViewModel
                {
                    ID = x.ID,
                    Name = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    BirthDate = x.BirthDate,
                    PhoneNumber = x.MobileNumber
                }).ToList();
            }
        }

        public UsersViewModel GetUserByID(Guid id)
        {
            using (UsersDataModel data = new UsersDataModel())
            {
                var user = data.Users.FirstOrDefault(x => x.ID == id);

                if (user == null)
                    throw new Exception("User not found!");

                return new UsersViewModel
                {
                    ID = user.ID,
                    Name = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    BirthDate = user.BirthDate,
                    PhoneNumber = user.MobileNumber
                };
            }
        }

        public void UpdateUser(Guid id, UsersViewModel user)
        {
            using (UsersDataModel data = new UsersDataModel())
            {
                var userToUpdate = data.Users.FirstOrDefault(x => x.ID == id);

                if (userToUpdate == null)
                    throw new Exception("User not found!");

                userToUpdate.FirstName = user.Name;
                userToUpdate.LastName = user.LastName;
                userToUpdate.MobileNumber = user.PhoneNumber;
                userToUpdate.Email = user.Email;
                userToUpdate.BirthDate = user.BirthDate;

                userToUpdate.Modified = DateTime.Now;

                try
                {
                    data.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                

            }


        }
    }

    public interface IUsersLogic
    {
        List<UsersViewModel> Get();

        UsersViewModel GetUserByID(Guid id);

        void CreateUser(UsersViewModel newUser);

        void UpdateUser(Guid id, UsersViewModel user);

        void DeleteUser(Guid id);

    }
}