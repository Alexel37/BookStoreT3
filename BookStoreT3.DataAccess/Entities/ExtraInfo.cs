//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStoreT3.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExtraInfo
    {
        public int Id { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }
        public Nullable<int> Year { get; set; }
    
        public virtual Book Book { get; set; }
    }
}
