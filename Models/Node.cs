using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Node
    {
        [Key]
        public int nodeId { get; set; }
        public string nodeName { get; set; }
        public int? parentNodeId { get; set; }
        public bool isActive { get; set; }
        public DateTime startdate { get; set; }
    }
}
 