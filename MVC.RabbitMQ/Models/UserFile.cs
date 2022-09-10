using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.RabbitMQ.Models
{
    public enum FileStatus
    {
        Creating,
        Completed
    }

    public class UserFile
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string FileStatus { get; set; }

        [NotMapped]

        public string GetCreatedDate => CreatedDate.HasValue ? CreatedDate.Value.ToShortDateString() : "-";
    }
}
