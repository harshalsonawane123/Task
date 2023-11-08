namespace WebApplication1.Models
{
    public class NodeViewModel
    {
        public int nodeId { get; set; }
        public string nodeName { get; set; }
        public int parentNodeId { get; set; }
        public bool isActive { get; set; }
        public DateTime startdate { get; set; }
        public List<NodeViewModel> children { get; set; }
    }
}
