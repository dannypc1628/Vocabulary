namespace VocabularyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(VocabularyTypeMetaData))]
    public partial class VocabularyType
    {
    }
    
    public partial class VocabularyTypeMetaData
    {
        [Required]
        public int ID { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string Name { get; set; }
    
        public virtual ICollection<Vocabulary> Vocabulary { get; set; }
    }
}
