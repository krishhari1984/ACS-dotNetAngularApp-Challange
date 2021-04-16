using ACS_dotNetAngularApp.Business.Abstractions;
using ACS_dotNetAngularApp.Business.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ACS_dotNetAngularApp.Business
{
    public class UserService : IContactUser
    {
        private readonly UsersContext _usersContext;
        private readonly ILogger<UserService> _logger;
        public UserService(UsersContext usersContext, ILogger<UserService> logger) {
            _usersContext = usersContext;
            _logger = logger;
        }

        private IEnumerable<ContactUser> _users { get; set; }

          /// <summary>
          /// List of users
          /// </summary>
          /// <returns></returns>
        public async Task<IEnumerable<ContactUser>> GetList()
        {
            try
            {
                return _usersContext.ContactUserDbSet.ToList();
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw ex.InnerException; 
            }
        }

        /// <summary>
        /// Find specific user details.
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public ContactUser Get(int contactID)
        {
            try
            {
                return _usersContext.ContactUserDbSet.Find(contactID);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
           
        }

        /// <summary>
        /// Adding new user details
        /// </summary>
        /// <param name="contactUser"></param>
        /// <returns></returns>
        public string NewContactUser(ContactUser contactUser)
        {
            try
            {
                var usr = _usersContext.ContactUserDbSet.Where(x => x.FName == contactUser.FName && x.LName == contactUser.LName && x.DOB == contactUser.DOB).FirstOrDefault();
                if (usr!=null)
                {
                    return Constants.UserExists;
                }
                _usersContext.ContactUserDbSet.Add(contactUser);
                _usersContext.SaveChanges();
                return Constants.NewUser;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
          
        }
        
        /// <summary>
        /// Edit and update user details.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactUser"></param>
        /// <returns></returns>
        public string EditUpdateUser(int id, ContactUser contactUser)
        {
            try
            {
                var user = _usersContext.ContactUserDbSet.Find(id);
                if (user == null)
                {
                    return Constants.NoUser;
                }

                _usersContext.ContactUserDbSet.Update(contactUser);
                _usersContext.SaveChanges();
                return Constants.EditUpdate;


            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
        }
     
        /// <summary>
        /// Deleting user detsils from DB.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            try
            {
                var user = _usersContext.ContactUserDbSet.Find(id);
                if (user == null)
                {
                    return Constants.NoUser;
                }

                _usersContext.ContactUserDbSet.Remove(user);
                _usersContext.SaveChanges();
                return Constants.Deleted;
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Search user
        /// </summary>
        /// <param name="title"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        public IEnumerable<ContactUser> SearchUsers(string title, int? skip = null, int? take = null, string sortColumn = null, SortDirection sortDirection = SortDirection.Ascending)
        {
            throw new NotImplementedException();
        }
    }
}
