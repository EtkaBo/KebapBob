using System.ComponentModel;


namespace KebapBobModels.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ItemName { get; set; }
        public string itemDescription { get; set; }
    }

}
