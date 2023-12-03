using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Domain
{
    public class EngineSchematic
    {
        public List<Part> Parts = [];
        public void AddPartsFromLine(string line, int y)
        {
            Part part = new Part();
            for (int x=0;x<line.Length; x++) 
            {
                if (IsDot(line[x]))
                    part=CreateDotPart(line[x], x,y);
                else if (char.IsNumber(line[x]))
                    (part,x) = CreateNumberPart(line, x, y);
                else
                    part = CreateSymbolPart(line[x], x, y);

                Parts.Add(part);
            }
            
        }
        public List<Part> GetNumberPartsNearSymbolPart()
        {
            List<Part> partsNearSymbol = new List<Part>();
            bool symbolFound = false;
            foreach (Part part in Parts.Where(p => p.PartType == PartType.Number))
            {
                symbolFound = true;
                foreach (Coordinate coord in part.Coordinates)
                {
                    var neighbourCoords = ListNeighbourCoordinates(coord);
                    var neighbourParts = GetPartsFromCoords(neighbourCoords);
                    symbolFound = IsSymbolPresentOnPartsList(neighbourParts);
                    if(symbolFound)
                        break; // ugly but avoid other loop iteration
                    
                }
                if(symbolFound)
                    partsNearSymbol.Add(part);
            }
            return partsNearSymbol;
        }
        private bool IsSymbolPresentOnPartsList(List<Part> parts) =>   parts.Any(p => p.PartType == PartType.Symbol);

        private List<Part> GetPartsFromCoords(List<Coordinate> coords)
        {
            var parts = new List<Part?>();
            foreach (Coordinate coord in coords)
            {
                var part = GetPartFromCoord(coord);

                if (part is not null)
                    parts.Add(part);
            }
            return parts;
        }
        private Part? GetPartFromCoord(Coordinate coord) => 
            Parts.FirstOrDefault(p => p.Coordinates.Any(c => c.X == coord.X && c.Y == coord.Y));
        private List<Coordinate> ListNeighbourCoordinates(Coordinate coord) =>
             new List<Coordinate> { 
                // left
                new Coordinate(coord.X-1,coord.Y),
                // up left,
                new Coordinate(coord.X-1,coord.Y-1) ,
                // down left
                new Coordinate(coord.X-1,coord.Y+1) ,
                // up
                new Coordinate(coord.X,coord.Y-1) ,
                // down
                new Coordinate(coord.X,coord.Y+1) ,
                // right
                new Coordinate(coord.X+1,coord.Y),
                // up right,
                new Coordinate(coord.X+1,coord.Y-1) ,
                // down right
                new Coordinate(coord.X+1,coord.Y+1)

            };

        public void DisplayNumberParts() =>
            DisplayParts(Parts.Where(p => p.PartType == PartType.Number).ToList());

        public void DisplayParts(List<Part> parts)
        {
            foreach (Part part in parts)
            {
                Console.WriteLine($"Val: {part.Value}");
                Console.WriteLine($"Coords:");
                foreach (Coordinate coord in part.Coordinates)
                {
                    Console.WriteLine(coord.ToString());
                }
            }
        }
        private Part CreateDotPart(char car, int x, int y)
        {
            List<Coordinate> coords = new List<Coordinate>();
            coords.Add(  new(x,y));
            return new Part()
            {

                Coordinates = coords,
                Value = car.ToString(),
                PartType=PartType.Dot
            };
        }

        private Part CreateSymbolPart(char car, int x, int y)
        {
            List<Coordinate> coords = new List<Coordinate>();
            coords.Add(new(x, y));
            return new Part()
            {

                Coordinates = coords,
                Value = car.ToString(),
                PartType = PartType.Symbol
            };
        }
        private (Part, int) CreateNumberPart(string line, int x, int y)
        {
            List<Coordinate> coords = new List<Coordinate>();

            string val = string.Empty;
            while (x < line.Length && Char.IsNumber(line[x]))
            {
                val += line[x];
                coords.Add(new(x, y));
                x++;
            }
            return (new Part()
            {

                Coordinates = coords,
                Value = val,
                PartType = PartType.Number
            }, x-1);
        }
        private bool IsDot(char ch) => ch == '.';
    }
}
