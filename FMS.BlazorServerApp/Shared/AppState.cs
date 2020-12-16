using FMS.ServiceLayer.Dtos;

namespace FMS.BlazorServerApp.Shared
{
    public class AppState
    {
        public bool BackToCustomerList { get; set; }
        public CustomerListOptions CustomerListOptions { get; set; }

        public ProductListOptions ProductListOptions { get; set; }
    }
}
