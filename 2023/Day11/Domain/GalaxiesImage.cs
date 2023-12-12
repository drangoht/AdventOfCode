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
        public int EmptyMultiplier { get; set; } = 2;
        List<Point> points = [];
        List<int> linesToExpand = [];
        List<int> colsToExpand = [];
        Graph<Point> graph = new Graph<Point>();
        public void ParseLineToPoints(List<string> lines)
        {
            List<string> expandedGalaxies = [];
            
            int id = 1;
            int x = 0;
            int y = 0;
 
            // Calculate Cols and lines to expand
            y = 0;
            List<char> curLine = [];
            foreach (var line in lines)
            {
                x = 0;
                if (!line.Contains("#"))
                    linesToExpand.Add(y);

                
                foreach (var car in line)
                {
                    if (IsColEmpty(lines, x))
                        colsToExpand.Add(x);
                    x++;
                }
                y++;

            }
            //foreach (var line in lines)
            //{
            //    Console.WriteLine(line);
            //}
            y = 0;
            foreach (var line in lines)
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

        public Int64 CalculateAllDistancesBetweenGalaxies()
        {
            List<Tuple<int,int>> visited = new List<Tuple<int,int>>();
            Int64 resultSumDistances = 0;
            int maxId = points.Max(p => p.Id);
            for (int i = 1; i <= maxId; i++)
            {
                var startPoint = points.First(p => p.Id == i);
                var shortestPath = Algorithms.Algorithms.ShortestPathFunction(graph, startPoint);
                for (int j = i + 1; j <= maxId; j++)
                {
                    int cptPath = 1;
                    var paths = shortestPath(points.First(p => p.Id == j));
                    int pathsCount = paths.Count();
                    while (cptPath< pathsCount)
                    {
                        var curPoint = paths.ToList()[cptPath];
                        var nextPoint = new Point();
                        var toExpand = false;
                        if (cptPath+1< pathsCount)
                        {
                            nextPoint = paths.ToList()[cptPath+1];
                        
                            if (nextPoint.X != curPoint.X)
                                toExpand = colsToExpand.Any(x => x==curPoint.X );
                            else
                                toExpand = linesToExpand.Any(y => y ==curPoint.Y);
                        }
                        resultSumDistances += toExpand ? EmptyMultiplier  : 1;
                        cptPath++;
                    }
                    
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
            p = GetPoint(x - 1, y);
            if (p is not null) points.Add(p);

            p = GetPoint(x + 1, y );
            if (p is not null) points.Add(p);

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
