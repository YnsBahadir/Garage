using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MainPage
    {
        public int MainPageID { get; set; }
        public string MainPageTitle { get; set; }
        public string ProductContent { get; set; }
        public string SiteThumbnailImage { get; set; }
        public string ProductImage { get; set; }
        public DateTime SiteCrateDate { get; set; }
        public bool MainPageStatus { get; set; }
    }
}
