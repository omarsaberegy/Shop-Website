using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class UserInfoModel
    {
        public UserInformation GetUserInformation(string guId)
        {
            ShopEntities db = new ShopEntities();
            UserInformation info = (from x in db.UserInformations
                                    where x.GUID == guId
                                    select x).FirstOrDefault();
            return info;
        }
        public void InsertUserInformation(UserInformation info)
        {
            ShopEntities db = new ShopEntities();
            db.UserInformations.Add(info);
            db.SaveChanges();
        }
    }
}