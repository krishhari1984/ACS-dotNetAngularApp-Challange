using ACS_dotNetAngularApp.Business.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS_dotNetAngularApp.Business.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactUser
    {

        string NewContactUser(ContactUser contactUser);
        Task<IEnumerable<ContactUser>> GetList();
        ContactUser Get(int contactID);
        string EditUpdateUser(int id, ContactUser contactUser);
        string Delete(int id);
        IEnumerable<ContactUser> SearchUsers(string title, int? skip = null, int? take = null, string sortColumn = null, SortDirection sortDirection = SortDirection.Ascending);
    }
}
