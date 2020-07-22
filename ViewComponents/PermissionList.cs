using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IMODA.Models;


namespace IMODA.ViewComponents
{
    public class PermissionList 
    {
        private static test1Entities db = new test1Entities();

        public static List<permission> Permission()
        {
            var menus =  db.permission.OrderBy(m => m.id).ToList();
            //menus = "<div>Item String " + menus + "</div>";
            return menus;
        }
    }
}