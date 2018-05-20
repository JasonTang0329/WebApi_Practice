namespace WEBAPI2_PRACTICE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KM_file_Temp_Path
    {
        [Key]
        public long idx { get; set; }

        [Required]
        public string file_path { get; set; }

        [Required]
        public string file_guid_path { get; set; }

        public DateTime file_createtime { get; set; }
    }
}
