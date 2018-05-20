namespace WEBAPI2_PRACTICE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KM_file_Keywords
    {
        [Key]
        public long SeqNo { get; set; }

        public Guid FlowId { get; set; }

        public string Keywords { get; set; }

        public bool? isDel { get; set; }

        public DateTime? updatetime { get; set; }

        public long? Metering { get; set; }

        public virtual KM_file KM_file { get; set; }
    }
}
