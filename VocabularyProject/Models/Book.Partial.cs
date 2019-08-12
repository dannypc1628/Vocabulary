namespace VocabularyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(BookMetaData))]
    public partial class Book
    {
    }
    
    public partial class BookMetaData
    {
        [Required]
        public int ID { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Name { get; set; }
    
        public virtual ICollection<Unit> Unit { get; set; }
    }
}
