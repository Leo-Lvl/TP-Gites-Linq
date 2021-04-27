namespace cfGites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gites.contrat")]
    public partial class contrat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public contrat()
        {
            plannings = new HashSet<planning>();
        }

        [Key]
        public int numContrat { get; set; }

        public DateTime? dateContrat { get; set; }

        public int? valide { get; set; }

        public int? annule { get; set; }

        public int? numClient { get; set; }

        public virtual client client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<planning> plannings { get; set; }
    }
}
