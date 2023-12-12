using Day11.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Domain
{
    public class GalaxiesImage
    {
        List<Point> points = [];
        Graph<Point> graph = new Graph<Point>();
        public void ParseLineToPoints(List<string> lines)
        {
            List<string> expandedGalaxies = [];
            int id = 1;
            int x = 0;
            int y = 0;
            int maxDbl = 1;


            List<char> curLine = [];
            foreach (var line in lines)
            {
                maxDbl = 1;
                if (!line.Contains("#"))
                    maxDbl = 2;
                
                var cptDbl = 0;
                while (cptDbl < maxDbl)
                {
                    //expandedGalaxies.Add(line);
                    x = 0;
                    curLine = [];
                    foreach (var car in line)
                    {
                        curLine.Add(car);
                        if (IsColEmpty( lines, x))
                            curLine.Add(car);
                        x++;
                    }
                    expandedGalaxies.Add(new string(curLine.ToArray()));
                    y++;
                    cptDbl++;
                }
                
            }
            
            foreach (var line in expandedGalaxies)
            {
                Console.WriteLine(line);
            }
            y = 0;
            foreach (var line in expandedGalaxies)
            {
                x = 0;
                foreach (var car in line)
                {
                    Point? point = GetPoint(x, y);
                    point.ConnectedPoints = GetNeighbourPoints(x, y, car);
                    point.Value = car;
                    if (car == '#')
                        point.Id = id++;
                    points.Add(point);
                    x++;
                }
                y++;
            }

            var vertices = points.ToArray();
            var pointsConnected = points.Where(p => p.ConnectedPoints.Count() > 0);
            var edges = new List<Tuple<Point, Point>>();

            foreach (var point in pointsConnected)
            {
                foreach (var pc in point.ConnectedPoints)
                {
                    edges.Add(Tuple.Create(point, pc));
                }
            }

            graph = new Graph<Point>(vertices, edges);
        }

        public int CalculateAllDistancesBetweenGalaxies()
        {
            List<Tuple<int,int>> visited = new List<Tuple<int,int>>();
            int resultSumDistances = 0;
            for(int i=1;i<=points.Max(p => p.Id);i++)
            {
                var shortestPath = Algorithms.Algorithms.ShortestPathFunction(graph, points.First(p => p.Id==i));
                for (int j = i+1; j <= points.Max(p => p.Id); j++)
                {
                    resultSumDistances += shortestPath(points.First(p => p.Id == j)).Count()-1;
                    //Console.WriteLine($" tot: {resultSumDistances} i:{i} {points.First(p => p.Id == i).ToString()} j:{j} {points.First(p => p.Id == j).ToString()} {shortestPath(points.First(p => p.Id == j)).Count()}");
                }
            }
            return resultSumDistances;

        }
        private bool IsColEmpty(List<string> lines,int col)
        {
            foreach (var line in lines)
            {
                if (line[col] == '#')
                    return false;
            }
            return true;
        }
        List<Point> GetNeighbourPoints(int x, int y, char direction)
        {
            List<Point> points = new List<Point>();
            Point? p = new Point();
            p = GetPoint(x, y - 1);
            if (p is not null) points.Add(p);
            p = GetPoint(x, y + 1);
            if (p is not null) points.Add(p);

            //p = GetPoint(x - 1, y - 1);
            //if (p is not null) points.Add(p);
            p = GetPoint(x - 1, y);
            if (p is not null) points.Add(p);
            //p = GetPoint(x - 1, y + 1);
            //if (p is not null) points.Add(p);

            //p = GetPoint(x + 1, y - 1);
            //if (p is not null) points.Add(p);
            p = GetPoint(x + 1, y );
            if (p is not null) points.Add(p);
            //p = GetPoint(x + 1, y + 1);
            //if (p is not null) points.Add(p);

            return points;
        }
        Point? GetPoint(int x, int y)
        {
            if (x < 0 || y < 0)
                return null;
            Point point;
            if (points.Any(p => p.X == x && p.Y == y))
                point = points.First(p => p.X == x && p.Y == y);
            else
                point = new Point() { X = x, Y = y };

            return point;
        }
    }
}
