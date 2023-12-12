using Day10.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Domain
{
    public class SurfacePipes
    {
        List<Point> points = [];
        Graph<Point> graph = new Graph<Point>();
        Point start = new();
        public void ParseLineToPoints(List<string> lines)
        {
            int id = 1;
            int x = 0;
            int y = 0;
            foreach (var line in lines)
            {
                x = 0;
                foreach (var car in line)
                {
                    Point? point = GetPoint(x,y);
                    point.ConnectedPoints = GetNeighbourPoints(x,y,car);
                    if (car == 'S')
                        point.Origin = true;

                    point.Id = id++;
                    points.Add(point);
                    x++;
                }
                y++;
            }

            var vertices = points.ToArray();
            start = points.First(p => p.Origin);
            var pointsConnected = points.Where(p => p.ConnectedPoints.Count() >0);
            var edges = new List<Tuple<Point, Point>>();

            foreach (var point in pointsConnected)
            {
                foreach(var pc in point.ConnectedPoints)
                {
                    edges.Add(Tuple.Create(point, pc));
                }
            }

            graph = new Graph<Point>(vertices, edges);
        }

        public int FindLongestPath()
        {
            var a = Algorithms.Algorithms.BFS(graph, start);
            return (int)Math.Ceiling((double)Algorithms.Algorithms.BFS(graph, start).Count())/2;
            //return (int)Math.Ceiling((double)CalculateFullDistance() / 2);
            //return (int)Math.Ceiling((double) points.Max(p => (double)p.DistanceToOrigin)/2);
        }
        List<Point> GetNeighbourPoints(int x, int y, char direction)
        {
            List<Point> points = new List<Point>();
            Point? p = new Point();
            switch (direction)
            {
                case '|':
                    // NS
                    p = GetPoint(x, y - 1);
                    if(p is not null) points.Add(p);
                    p = GetPoint(x, y + 1);
                    if (p is not null) points.Add(p);
                    break;
                case '-':
                    // EW
                    p = GetPoint(x - 1, y);
                    if (p is not null) points.Add(p);
                    p = GetPoint(x + 1, y);
                    if (p is not null) points.Add(p);
                    break;
                case 'L':
                    // NE
                    p = GetPoint(x, y - 1);
                    if (p is not null) points.Add(p);
                    p = GetPoint(x + 1, y);
                    if (p is not null) points.Add(p);
                    break;
                case 'J':
                    // NW
                    p = GetPoint(x, y - 1);
                    if (p is not null) points.Add(p);
                    p = GetPoint(x - 1, y);
                    if (p is not null) points.Add(p);
                    break;
                case '7':
                    // SW
                    p = GetPoint(x, y + 1);
                    if (p is not null) points.Add(p);
                    p = GetPoint(x - 1, y);
                    if (p is not null) points.Add(p);
                    break;
                case 'F':
                    // SE
                    p = GetPoint(x, y + 1);
                    if (p is not null) points.Add(p);
                    p = GetPoint(x + 1, y);
                    if (p is not null) points.Add(p);
                    break;
                case 'S':
                    //points.Add(GetPoint(x, y + 1));
                    //points.Add(GetPoint(x + 1, y));
                    //points.Add(GetPoint(x, y - 1));
                    //points.Add(GetPoint(x - 1, y));
                    //break;
                case '.':
                default:
                    break;
            }
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

        public void Display()
        {
            foreach (var point in points)
            {
                Console.WriteLine(point.ToString());
            }
        }
    }


}
