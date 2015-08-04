using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManager.DataAccess.Models
{
    public class CarCrew
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsCarOwner { get; set; }
        public bool IsDriver { get; set; }

//        public int ProfileRefId { get; set; }
//
//        [ForeignKey("ProfileRefId")]
        public Profile CrewMember { get; set; }
        public int TournamentRefId { get; set; }
        [ForeignKey("TournamentRefId")]
        public virtual Tournament Tournament { get; set; }

        public virtual ICollection<CrewExpense> CrewExpenses { get; set; }

    }
}