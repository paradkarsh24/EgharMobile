namespace Egharpay.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trend")]
    public partial class Trend
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trend()
        {
            TrendComments = new HashSet<TrendComment>();
            CreatedDateTime = DateTime.UtcNow;
        }

        public int TrendId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        public string Detail { get; set; }

        public string ShortDescription { get; set; }

        public string Filename { get; set; }

        public DateTime CreatedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrendComment> TrendComments { get; set; }
    }
}
