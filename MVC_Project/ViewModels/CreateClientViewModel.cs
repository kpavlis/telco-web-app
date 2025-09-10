using MVC_Project.Models;

namespace MVC_Project.ViewModels
{
    //Helper Class for CreateClient View
    public class CreateClientViewModel
    {
        public User User { get; set; }
        public Phone Phone { get; set; }
        public Client Client { get; set; }
    }
}
