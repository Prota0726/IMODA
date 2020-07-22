using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMODA.Models;
namespace IMODA.ViewModels
{
    public class MangerModViewModel
    {
        [Key]
        public int ID { get; set; }
        [NotMapped]
        public List<SelectListItem> RoleData
        {
            get;
           set;
        }
        public manger MangerData
        {
            get;
            set;
        }

    }
}