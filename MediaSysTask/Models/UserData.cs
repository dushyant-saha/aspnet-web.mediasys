using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaSysTask.Models
{
    public class UserData
    {
        private List<User> _userList;

        public UserData()
        {
            //_userList = new List<User>()
            //{
            //    new User() { Id = 1, Name = "Mary", Role = "HR", Email = "mary@pragimtech.com" },
            //    new User() { Id = 2, Name = "John", Role = "IT", Email = "john@pragimtech.com" },
            //    new User() { Id = 3, Name = "Sam", Role = "IT", Email = "sam@pragimtech.com" },
            //};
        }

        public User GetUser(int Id)
        {
            return this._userList.FirstOrDefault(e => e.Id == Id);
        }
    }
}