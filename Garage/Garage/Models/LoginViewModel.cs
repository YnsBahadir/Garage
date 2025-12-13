using Microsoft.AspNetCore.Mvc;

namespace Garage.Models // DİKKAT: Burası senin proje isminle aynı olmalı (örn: Baraya.Garage.Models vb.)
{
    public class LoginViewModel
    {
        // HTML formundaki name="Username" burayla eşleşecek
        public string Mail { get; set; }

        // HTML formundaki name="Password" burayla eşleşecek
        public string Password { get; set; }
    }
}
