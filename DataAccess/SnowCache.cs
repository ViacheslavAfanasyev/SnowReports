using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class SnowCache
    {
        public static List<string> States = new List<string>();
        public static IEnumerable<string> AssigmentGroups = new List<string>();
        public static IEnumerable<string> AccumulatedAssigmentGroups = new List<string>();

        public static IEnumerable<string> Regions = new List<string>();
    }
}
