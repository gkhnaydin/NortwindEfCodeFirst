using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwindEfCodeFirst.Entities
{

    [Table("Musteri")]
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        [Key]
        [Column("CustomerId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CustomerID { get; set; }

        [Required]
        [Column("ContactText")]
        [ConcurrencyCheck]
        [MaxLength(10)]
        public string ContactName { get; set; }

        [Required]
        [Column("CompanyText")]
        [MaxLength(10)]
        [MinLength(5)]
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [NotMapped]
        public string CountryText { get; set; }

        [ForeignKey("CustomerId")]
        public List<Order> Orders { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

    }
}

//DataAnnotations
/*
 * [Table("Musteri")]
 * [Key]
 * [ForeignKey("CustomerId")]
   [Column("CustomerId")]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   [Required]
   [ConcurrencyCheck]
   [MaxLength(10)]
   [MinLength(10)]
   [NotMapped]
   [Timestamp]
 */