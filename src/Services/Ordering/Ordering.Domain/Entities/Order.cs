using System;
using System.ComponentModel.DataAnnotations;
using Ordering.Domain.Common;

namespace Ordering.Domain.Entities
{
    public class Order:EntityBase
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string? State { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string? ZipCode { get; set; }

        // Payment
        [Required(AllowEmptyStrings = true)]
        public string CardName { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string? CardNumber { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string? Expiration { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string? CVV { get; set; }
        [Required(AllowEmptyStrings = true)]
        public int? PaymentMethod { get; set; }
    }
}

