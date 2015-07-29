using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ExpenseManager.DataAccess.Models
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        public string LoginHash { get; set; }
        [Required]
        public bool HasCar { get; set; }
        public string CarName { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        public virtual ICollection<CrewExpense> CrewExpenses { get; set; }
    }
}