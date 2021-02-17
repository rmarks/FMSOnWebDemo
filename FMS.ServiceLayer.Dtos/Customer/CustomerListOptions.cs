namespace FMS.ServiceLayer.Dtos
{
    public class CustomerListOptions : PagedArgsBase
    {
        public string SearchByName { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public string SearchByCity { get; set; }
        //public int PaymentTermId { get; set; }
    }
}
