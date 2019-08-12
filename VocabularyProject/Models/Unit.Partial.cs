namespace VocabularyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(UnitMetaData))]
    public partial class Unit
    {
    }
    
    public partial class UnitMetaData
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int Number { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Topic { get; set; }
        public Nullable<int> BookID { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual ICollection<Vocabulary> Vocabulary { get; set; }
    }
}
