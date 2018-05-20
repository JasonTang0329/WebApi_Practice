namespace WEBAPI2_PRACTICE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KM_file
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KM_file()
        {
            KM_file_Annotation = new HashSet<KM_file_Annotation>();
            KM_file_Comments = new HashSet<KM_file_Comments>();
            KM_file_Keywords = new HashSet<KM_file_Keywords>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SeqNo { get; set; }

        [Key]
        public Guid FlowId { get; set; }

        [StringLength(1024)]
        public string file_path { get; set; }

        [StringLength(1024)]
        public string file_name { get; set; }

        [Required]
        [StringLength(10)]
        public string file_type { get; set; }

        public DateTime updatetime { get; set; }

        public bool isDel { get; set; }

        public bool isVirt { get; set; }

        public string Link { get; set; }

        public long? Metering { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KM_file_Annotation> KM_file_Annotation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KM_file_Comments> KM_file_Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KM_file_Keywords> KM_file_Keywords { get; set; }
    }
}
