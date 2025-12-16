using EntityLayer.Concrete;
using System.Collections.Generic;

namespace Garage.Models
{
    public class AdminDashboardViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalCategories { get; set; }

        public List<string> CategoryLabels { get; set; }
        public List<int> CategoryCounts { get; set; }

        public List<Product> LastProducts { get; set; }
        public List<Category> AllCategories { get; set; }
    }
}