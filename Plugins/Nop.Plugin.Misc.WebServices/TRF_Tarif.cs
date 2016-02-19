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
    
    public partial class TRF_Tarif
    {
        public int ID { get; set; }
        public int ID_TarifType { get; set; }
        public Nullable<int> ID_NiveauType { get; set; }
        public Nullable<int> ID_Domaine { get; set; }
        public Nullable<int> ID_CoefficientMultiplicateurType { get; set; }
        public Nullable<int> ID_PorteeType { get; set; }
        public Nullable<int> ID_Portee { get; set; }
        public int ID_Article { get; set; }
        public Nullable<int> ID_Composant { get; set; }
        public Nullable<int> ID_OperationVente { get; set; }
        public Nullable<int> ID_Devise { get; set; }
        public Nullable<decimal> TauxConversion { get; set; }
        public Nullable<System.DateTime> DateDebut { get; set; }
        public Nullable<System.DateTime> DateFin { get; set; }
        public Nullable<decimal> PrixTTC { get; set; }
        public Nullable<decimal> PrixHTNet { get; set; }
        public Nullable<decimal> PrixPondereBrut { get; set; }
        public Nullable<decimal> Remise1 { get; set; }
        public Nullable<decimal> Remise2 { get; set; }
        public Nullable<decimal> Remise3 { get; set; }
        public Nullable<decimal> Remise4 { get; set; }
        public Nullable<decimal> Frais1 { get; set; }
        public Nullable<decimal> Frais2 { get; set; }
        public Nullable<decimal> Frais3 { get; set; }
        public Nullable<decimal> Frais4 { get; set; }
        public System.DateTime DateCreation { get; set; }
        public Nullable<int> OrdrePriorite { get; set; }
        public Nullable<System.DateTime> DateModification { get; set; }
        public int ID_DernierUtilisateur { get; set; }
        public Nullable<int> RowVersion { get; set; }
    
        public virtual ART_Article ART_Article { get; set; }
    }
}