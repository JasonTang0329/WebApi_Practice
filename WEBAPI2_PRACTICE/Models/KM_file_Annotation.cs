namespace WEBAPI2_PRACTICE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KM_file_Annotation
    {
        [Key]
        public long SeqNo { get; set; }

        public Guid FlowId { get; set; }

        public string Annotation { get; set; }

        public DateTime updatetime { get; set; }

        public virtual KM_file KM_file { get; set; }
    }
}
