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
    
    public partial class Templates
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
        public System.DateTime DateLoad { get; set; }
        public double FileSizeKBytes { get; set; }
    }
}
