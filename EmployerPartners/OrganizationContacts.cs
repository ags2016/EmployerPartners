//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployerPartners
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrganizationContacts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrganizationContacts()
        {
            this.Author = "";
        }
    
        public int Id { get; set; }
        public System.Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobiles { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual Organization Organization { get; set; }
    }
}
