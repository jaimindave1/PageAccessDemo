using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleAccessDemo.Models
{
    public class PageAccessViewModel
    {
        public int PageAccessID { get; set; }
        public string PageName { get; set; }
        public bool isEditVisible { get; set; }
        public bool View { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
    }
}