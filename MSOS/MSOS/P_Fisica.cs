//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSOS
{
    using System;
    using System.Collections.Generic;
    
    public partial class P_Fisica
    {
        public int ID_PESSOA_FISICA { get; set; }
        public Nullable<int> ID_PESSOA_TIPO { get; set; }
        public string SEXO { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public Nullable<System.DateTime> DATA_NASCIMENTO { get; set; }
        public string CELULAR { get; set; }
        public string CELULAR2 { get; set; }
    
        public virtual P_ClientePessoa P_ClientePessoa { get; set; }
    }
}
