using MVC_Project.Models;

namespace MVC_Project.ViewModels
{
    //Helper Class for BillDetails View
    public class BillDetailsViewModel
    {
        public Bill Bill { get; set; }
        public List<Call> Calls { get; set; }
    }
}
