using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Domain
{
    public class Node
    {
        public string Id { get; set; } = string.Empty;
        public string? LeftNodeId { get; set; }
        public string? RightNodeId { get; set; }

        public override string ToString()
        {
            return $"{Id} {LeftNodeId},{RightNodeId}";
        }

    }
}
