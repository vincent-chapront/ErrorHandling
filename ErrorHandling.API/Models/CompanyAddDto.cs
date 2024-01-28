using System.ComponentModel.DataAnnotations;

namespace ErrorHandling.API.Models
{
    public class CompanyAddDto
    {
        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int UserCountMax { get; set; }
    }
}