//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace THe_BOok_MArket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment_Type
    {
        public Payment_Type()
        {
            this.Sales = new HashSet<Sale>();
        }
    
        public int PaymentType_ID { get; set; }
        public string PaymentType_Name { get; set; }
        public string PaymentType_Description { get; set; }
    
        public virtual ICollection<Sale> Sales { get; set; }
    }
}