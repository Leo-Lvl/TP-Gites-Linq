namespace cfGites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gites.semaine")]
    public partial class semaine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public semaine()
        {
            plannings = new HashSet<planning>();
        }

        [Key]
        public int numsemaine { get; set; }

        public DateTime dateDebutSemaine { get; set; }

        public DateTime? dateFinSemaine { get; set; }

        public int? numPeriode { get; set; }

        public virtual periode periode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<planning> plannings { get; set; }
    }
}
