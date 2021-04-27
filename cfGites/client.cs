namespace cfGites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gites.client")]
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            contrats = new HashSet<contrat>();
        }

        [Key]
        public int numClient { get; set; }

        [StringLength(50)]
        public string nomClient { get; set; }

        [StringLength(50)]
        public string adresseClient { get; set; }

        [StringLength(5)]
        public string cpClient { get; set; }

        [StringLength(50)]
        public string villeClient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contrat> contrats { get; set; }
    }
}
