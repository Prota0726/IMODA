using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IMODA.Models;

namespace IMODA.ViewModels
{
    public class RoleModViewModel
    {
        [Key]
        public int ID { get; set; }
        public role roledata
        {
            get;
            set;
        }
        
        public List<permission> PermissionsCollection
        {
            get;
            set;
        }
    }
}