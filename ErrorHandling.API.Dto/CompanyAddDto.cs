using System.ComponentModel.DataAnnotations;

namespace ErrorHandling.API.Dto
{
    public class CompanyAddDto
    {
        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, 10)]
        public int UserCountMax { get; set; }
    }
}