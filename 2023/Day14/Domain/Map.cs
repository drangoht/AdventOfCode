using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14.Domain
{
    public class Map
    {
        List<Point> points = [];
        public void ParseLineToPoints(List<string> lines)
        {
            List<string> expandedGalaxies = [];

            int id = 1;
            int x = 0;
            int y = 0;

            y = 0;
            foreach (var line in lines)
            {
                x = 0;
                foreach (var car in line)
                {
                    Point point =new Point();
                    point.X = x;
                    point.Y = y;
                    point.Value = car;
                    points.Add(point);
                    x++;
                }
                y++;
            }

            //foreach (var line in lines)
            //{
            //    Console.WriteLine(line);
            //}
        }
        public int CalculateSumOfRoundedRocks()
        {
            var maxX = points.Max(p => p.X); 
            var maxY = points.Max(p => p.Y);

            
            int[] rocksByRow = new int [maxY+1];
            
            for (int x= 0; x <= maxX; x++) 
            {
                var blockTile = -1;
                for (int y= 0; y <= maxY; y++)
                {
                    var curCell = points.First(p => p.X == x && p.Y == y);
                    if (curCell.Value=='#')
                        blockTile = y;

                    if (curCell.Value == 'O')
                    {
                        if (blockTile == -1) // no block
                            blockTile = 0;
                        else if (blockTile != y)
                            blockTile++;
                        rocksByRow[blockTile]++;
                        
                    }
                }
            }
            int weight = 0;
            for(int y=0;y< rocksByRow.Length; y++)
            {
                var rank = (maxY - y)+1;
                weight += rocksByRow[y]*rank;
            }
            return weight;
        }
    }
}
