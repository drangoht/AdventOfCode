using System.Reflection.Metadata.Ecma335;

namespace Day2.Tools
{
    public static class Tools
    {
        public static bool IsSafe(List<int>? reports)
        {
            var prec = -1;
            var precOrder = 0;
            
            foreach(var r in reports)
            {
                if(prec != -1)
                {
                    var diff = Math.Abs(r - prec); 
                    if (diff > 3)
                        return false; 
                    if (diff == 0)
                        return false;
                    if (precOrder != 0)
                    {
                       
                        if (precOrder != ((r - prec) / diff))
                            return false;
                    }
                    precOrder = (r - prec) / diff;
                }
                prec = r;
            }
            return true;
        }
    }
}
