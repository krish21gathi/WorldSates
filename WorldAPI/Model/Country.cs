using System.ComponentModel.DataAnnotations;

namespace WorldAPI.Model
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(5)]
        public string ShortName { get; set; }
        [MaxLength(10)]
        [Required]
        public string CountryCode { get; set; }
    }
}
