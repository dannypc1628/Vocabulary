namespace VocabularyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(VocabularyMetaData))]
    public partial class Vocabulary
    {
    }
    
    public partial class VocabularyMetaData
    {
        [Required]
        public int ID { get; set; }
        public Nullable<int> UnitID { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string Word { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string PartsOfSpeech { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Chinese { get; set; }
        public Nullable<int> TypeID { get; set; }
    
        public virtual Unit Unit { get; set; }
        public virtual VocabularyType VocabularyType { get; set; }
    }
}
