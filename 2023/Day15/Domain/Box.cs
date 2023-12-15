using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15.Domain
{
    public class Box
    {
        public int Id = -1;
        public List<Lens> lenses = [];
        public void RemoveLens(string lensLabel)
        {
            var lensToDelete = lenses.FirstOrDefault(l => l.Label == lensLabel);
            if (lensToDelete is not null)
                lenses.Remove(lensToDelete);
        }
    }
}
