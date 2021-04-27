namespace cfGites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gites.tarif")]
    public partial class tarif
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numGite { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numPeriode { get; set; }

        public decimal? prixSemaine { get; set; }

        public virtual gite gite { get; set; }

        public virtual periode periode { get; set; }
    }
}
