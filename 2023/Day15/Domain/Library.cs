using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15.Domain
{
    public class Library
    {
        List<Box> boxes = [];
        public string HashMap {  get; set; }   = string.Empty;
        public int HashString(string toHash)
        {
            int result = 0;
            foreach (var car in toHash)
            {
                var asc = (int)car;
                result = ((result + asc) * 17) % 256;
            }
            return result;
        }
        public void OrderBoxes()
        {
            var sequences = HashMap.Split(',');
            foreach (var seq in sequences)
            {
                if(seq.Contains('='))
                {
                    var arrSeq = seq.Split('=');
                    var boxNumber = HashString(arrSeq[0]);
                    
                    Lens lens = new Lens(arrSeq[0],Convert.ToInt32(arrSeq[1]));
                    AddBox(boxNumber, lens);
                }
                if(seq.EndsWith("-"))
                {
                    var arrSeq = seq.Split('-');
                    var boxNumber = HashString(arrSeq[0]);
                    var currBox = boxes.FirstOrDefault(b => b.Id == boxNumber);
                    if(currBox is not null)
                    {
                        currBox.RemoveLens(arrSeq[0]);
                    }
                }
            }
        }
        public Int64 CalculateFocusingPower()
        {
            Int64 result = 0;
            Int64 totResult = 0;
            foreach( var box in boxes)
            {
                int lensRank = 1;
                foreach(var lens in box.lenses)
                {
                    result = (box.Id + 1);
                    result *= lensRank*lens.FocalLength;
                    lensRank++;
                    totResult += result;
                }
                
            }
            return totResult;
        }
        private void AddBox(int boxNumber, Lens lens)
        {

            var box = boxes.FirstOrDefault(b => b.Id == boxNumber);
            if (box is not null)
            {
                var foundLens = box.lenses.FirstOrDefault(l => l.Label == lens.Label);
                if(foundLens is not null)
                {
                    foundLens.FocalLength = lens.FocalLength;
                }
                else
                    box.lenses.Add(lens);
            }
            else
                boxes.Add(new Box() { Id=boxNumber,lenses = new List<Lens> { lens } });
        }

    }

    
}
