//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployerPartners
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faculty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faculty()
        {
            this.ObrazProgram = new HashSet<ObrazProgram>();
            this.OrganizationFaculty = new HashSet<OrganizationFaculty>();
            this.PartnerPersonFaculty = new HashSet<PartnerPersonFaculty>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Acronym { get; set; }
        public string Code { get; set; }
        public string RodName { get; set; }
        public string DatName { get; set; }
        public string WebSite { get; set; }
        public string Crypt { get; set; }
        public string AcronymEng { get; set; }
        public Nullable<int> ExpertOrder { get; set; }
        public Nullable<bool> IsOpen { get; set; }
        public string Holder { get; set; }
        public Nullable<bool> IsArchive { get; set; }
        public Nullable<bool> IsCommonUniversity { get; set; }
        public string Author { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObrazProgram> ObrazProgram { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationFaculty> OrganizationFaculty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartnerPersonFaculty> PartnerPersonFaculty { get; set; }
    }
}
