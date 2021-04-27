namespace cfGites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gites.planning")]
    public partial class planning
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numSemaine { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numGite { get; set; }

        public int? numContrat { get; set; }

        public virtual contrat contrat { get; set; }

        public virtual gite gite { get; set; }

        public virtual semaine semaine { get; set; }
    }
}
