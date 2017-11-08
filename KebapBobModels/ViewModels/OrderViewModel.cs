using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace KebapBobModels.ViewModels
{
    public class OrderViewModel
    {
      
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TrackingNumber { get; set; }
        public string RecipientName { get; set; }
        public int AddressId { get; set; }
       // public string FullName => RecipientName + " " + RecipientLastName;
        //public string FullName {
        //    get {
        //        return RecipientName + " " + RecipientLastName;
        //    }
        //}
        public string StreetName { get; set; }
        public string City { get; set; }

        [MaxLength(2, ErrorMessage = "Maximum 2 letters")]
        public string State { get; set; }
        public int ZipCode { get; set; }
        public IEnumerable<OrderItemViewModel> OrderItems { get; set; }
    }

  
}