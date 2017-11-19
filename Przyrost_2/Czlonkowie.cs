namespace Przyrost_2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Czlonkowie")]
    public partial class Czlonkowie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_czlonkow { get; set; }

        public int? liczba_czlonkow { get; set; }

        [StringLength(30)]
        public string nazw_zesp { get; set; }

        public virtual Zespoly Zespoly { get; set; }
    }
}
