//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nop.Plugin.Misc.WebServices
{
    using System;
    using System.Collections.Generic;
    
    public partial class ART_Rayon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ART_Rayon()
        {
            this.ART_Article = new HashSet<ART_Article>();
            this.ART_Famille = new HashSet<ART_Famille>();
        }
    
        public int ID { get; set; }
        public string Libelle { get; set; }
        public string CodeRayon { get; set; }
        public Nullable<int> ID_Activite { get; set; }
        public short NumeroArticle { get; set; }
        public string CodeMAPAP { get; set; }
        public int ID_DernierUtilisateur { get; set; }
        public System.DateTime DateCreation { get; set; }
        public Nullable<System.DateTime> DateModification { get; set; }
        public Nullable<int> RowVersion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ART_Article> ART_Article { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ART_Famille> ART_Famille { get; set; }
    }
}
