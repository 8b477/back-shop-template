using System.ComponentModel.DataAnnotations;


namespace Database_Shop.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public bool Drink { get; set; }


        [Required]
        public bool Canned { get; set; }


        [Required]
        public bool Baby { get; set; }


        [Required]
        public bool Health { get; set; }


        [Required]
        public bool Dairy { get; set; }


        [Required]
        public bool Bakery { get; set; }


        [Required]
        public bool Fruit { get; set; }


        [Required]
        public bool Vegetable { get; set; }


        [Required]
        public bool Meat { get; set; }


        [Required]
        public bool Snack { get; set; }


        [Required]
        public bool Frozen { get; set; }
    }
}
