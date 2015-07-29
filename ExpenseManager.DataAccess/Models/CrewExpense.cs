using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseManager.DataAccess.Models.Enums;

namespace ExpenseManager.DataAccess.Models
{
    public class CrewExpense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Category ExpenceCategory { get; set; }
        public double Expence { get; set; }
        public string Currency { get; set; }

        public int ProfileRefId { get; set; }
        [ForeignKey("ProfileRefId")]
        public Profile Buyer { get; set; }

        public string Description { get; set; }

        public int CarCrewRefId { get; set; }
        [ForeignKey("CarCrewRefId")]
        public virtual CarCrew CarCrew { get; set; }
    }
}