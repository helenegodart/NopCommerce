//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgrammeEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ART_Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ART_Article()
        {
            this.ART_Article1 = new HashSet<ART_Article>();
            this.ART_Article11 = new HashSet<ART_Article>();
            this.TRF_Tarif = new HashSet<TRF_Tarif>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_Saison { get; set; }
        public Nullable<int> ID_Rayon { get; set; }
        public Nullable<int> ID_Famille { get; set; }
        public Nullable<int> ID_SousFamille { get; set; }
        public string CodeArticle { get; set; }
        public string AncienCodeArticle { get; set; }
        public string CodeIDEP { get; set; }
        public string Libelle { get; set; }
        public string LibelleCourt { get; set; }
        public string Description { get; set; }
        public Nullable<bool> EstSaisonnier { get; set; }
        public Nullable<short> PoidsArticle { get; set; }
        public string GenCode { get; set; }
        public Nullable<System.DateTime> DateSuppression { get; set; }
        public Nullable<int> ID_MotifSuppression { get; set; }
        public Nullable<bool> ImprimerEtiquette { get; set; }
        public string Sexe { get; set; }
        public Nullable<int> ID_Activite { get; set; }
        public Nullable<int> ID_Gamme { get; set; }
        public Nullable<int> ID_GrilleAchat { get; set; }
        public Nullable<int> ID_CoefficientDepreciation { get; set; }
        public Nullable<int> ID_ClasseArticle { get; set; }
        public Nullable<int> ID_Forme { get; set; }
        public Nullable<int> ID_Matiere { get; set; }
        public Nullable<int> ID_Couleur { get; set; }
        public Nullable<int> ID_Griffe { get; set; }
        public Nullable<int> ID_Boite { get; set; }
        public Nullable<int> ID_Style { get; set; }
        public Nullable<int> ID_Aspect { get; set; }
        public Nullable<int> ID_Fournisseur { get; set; }
        public Nullable<int> ID_AdresseFabrication { get; set; }
        public Nullable<int> ID_AdresseFacturation { get; set; }
        public string Modele { get; set; }
        public string ReferenceFournisseur { get; set; }
        public string ReferenceAgentFournisseur { get; set; }
        public string ReferenceMaison { get; set; }
        public Nullable<System.DateTime> DatePremiereReception { get; set; }
        public Nullable<bool> AEteReceptionneAuMoinsUneFois { get; set; }
        public Nullable<System.DateTime> DateDerniereRecepetion { get; set; }
        public Nullable<short> DureeGarantie { get; set; }
        public Nullable<short> PoidsEmballage { get; set; }
        public Nullable<int> ID_GroupementAchat { get; set; }
        public Nullable<int> ID_UniteGestionAchat { get; set; }
        public Nullable<int> ID_UniteGestionStock { get; set; }
        public Nullable<int> QteUniteStock { get; set; }
        public Nullable<int> QteLot { get; set; }
        public Nullable<decimal> Guelte { get; set; }
        public Nullable<bool> EstExprimePourcentageGuelte { get; set; }
        public Nullable<decimal> QtePointConcours { get; set; }
        public Nullable<bool> EstSaisieRapide { get; set; }
        public Nullable<int> ID_NouvelArticle { get; set; }
        public Nullable<int> ID_AncienArticle { get; set; }
        public bool InverserGamme { get; set; }
        public int ID_DernierUtilisateur { get; set; }
        public System.DateTime DateCreation { get; set; }
        public Nullable<System.DateTime> DateModification { get; set; }
        public Nullable<int> RowVersion { get; set; }
        public Nullable<int> ID_ReferenceMaison { get; set; }
        public Nullable<bool> EstPhotoConforme { get; set; }
        public Nullable<bool> EstRetourSaisonnier { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ART_Article> ART_Article1 { get; set; }
        public virtual ART_Article ART_Article2 { get; set; }
        public virtual ART_Famille ART_Famille { get; set; }
        public virtual ART_Grille ART_Grille { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ART_Article> ART_Article11 { get; set; }
        public virtual ART_Article ART_Article3 { get; set; }
        public virtual ART_Rayon ART_Rayon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRF_Tarif> TRF_Tarif { get; set; }
        public virtual ART_Couleur ART_Couleur { get; set; }
        public virtual ART_Griffe ART_Griffe { get; set; }
    }
}
