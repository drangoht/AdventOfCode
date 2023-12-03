using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Domain
{
    public class EngineSchematic
    {
        List<Part> Parts = [];
        public void AddPartsFromString(string line, int x)
        {
            int y = 0;
            Part part = new Part();
            foreach (var car in line) 
            {
                if (IsDot(car))
                    part=CreateDotPart(car,x,y);


                Parts.Add(part);
                y++;
            }
            
        }
        private Part CreateDotPart(char car,int x,int y) =>
            new Part()
            {

                Coordinates.Add(new Coordinate(x, y)),
                Value = car.ToString(),
                PartType=PartType.Dot
            };

        private bool IsNumber(char ch) => Char.IsDigit(ch);
        private bool IsDot(char ch) => ch == '.';
    }
}
