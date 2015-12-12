using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Description.ToString();
        }
    }
}
