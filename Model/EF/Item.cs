namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [Key]
        [StringLength(100)]
        public string Item_Title { get; set; }

        [StringLength(4000)]
        public string Item_description { get; set; }

        public long? Item_Id { get; set; }

        public bool? BidStatus { get; set; }

        public DateTime? BidStartDate { get; set; }

        public DateTime? BidEndDate { get; set; }

        public long? BidIncrement { get; set; }

        public short? MiniumBid { get; set; }

        public long? CategoryId { get; set; }
    }
}
