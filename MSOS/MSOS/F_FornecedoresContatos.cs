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
    
    public partial class F_FornecedoresContatos
    {
        public int ID_CONTATOF { get; set; }
        public string NOME { get; set; }
        public string ABREVIACAO { get; set; }
        public string TELEFONE { get; set; }
        public string CELULAR { get; set; }
        public string OBSERVACAO { get; set; }
    
        public virtual F_FornecedorPessoa F_FornecedorPessoa { get; set; }
    }
}
