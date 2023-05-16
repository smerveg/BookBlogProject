//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookBlogProject.WebAPI.Models
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Authors = new HashSet<Author>();
        }
    
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public Nullable<int> PageCount { get; set; }
        public string Publisher { get; set; }
        public bool BookStatus { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> ReleaseYear { get; set; }
        public string BookImage { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Category Category1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Author> Authors { get; set; }
    }
}