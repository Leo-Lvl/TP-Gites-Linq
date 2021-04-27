namespace cfGites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gites.periode")]
    public partial class periode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public periode()
        {
            semaines = new HashSet<semaine>();
            tarifs = new HashSet<tarif>();
        }

        [Key]
        public int numPeriode { get; set; }

        public DateTime? dateDebutPeriode { get; set; }

        public DateTime? dateFinPeriode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<semaine> semaines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarif> tarifs { get; set; }
    }
}
