namespace WEBAPI2_PRACTICE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KM_file_Comments
    {
        [Key]
        public long SeqNo { get; set; }

        public Guid FlowId { get; set; }

        public string Comments { get; set; }

        public DateTime updatetime { get; set; }

        [StringLength(50)]
        public string CommentsAuthor { get; set; }

        public virtual KM_file KM_file { get; set; }
    }
}
