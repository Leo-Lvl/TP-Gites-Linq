namespace cfGites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gites.gite")]
    public partial class gite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gite()
        {
            plannings = new HashSet<planning>();
            tarifs = new HashSet<tarif>();
        }

        [Key]
        public int numGite { get; set; }

        [StringLength(50)]
        public string nomGite { get; set; }

        [StringLength(50)]
        public string adresseGite { get; set; }

        [StringLength(5)]
        public string cpGite { get; set; }

        [StringLength(50)]
        public string villeGite { get; set; }

        public short? nbEpis { get; set; }

        [StringLength(100)]
        public string descriptionGite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<planning> plannings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarif> tarifs { get; set; }
    }
}
