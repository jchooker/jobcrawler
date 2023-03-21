using System.ComponentModel.DataAnnotations;

namespace JobCrawler.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Organization { get; set; }
        [Required]
        public string JobPlatform { get; set; }
        public string? Notes { get; set; }
        public DateTime Created
        {
            get
            {
                return this.dateCreated.HasValue
                    ? this.dateCreated.Value
                    : DateTime.Now;
            }
            set { this.dateCreated = value; }
        }
        private DateTime? dateCreated = null;
    }
}
