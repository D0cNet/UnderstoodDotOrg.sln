using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Search
{
    public class SessionSearchResult
    {
        public List<BehaviorAdvice> Results { get; set; }
        public string Challenge { get; set; }
        public string Grade { get; set; }
        public string SearchUrlTitle { get; set; }

        public BehaviorAdvice GetPreviousResult(ID id)
        {
            int currentIndex = GetResultIndex(id);
            if (currentIndex == -1 || currentIndex == 0)
            {
                return null;
            }

            return Results[currentIndex - 1];
        }

        public BehaviorAdvice GetNextResult(ID id)
        {
            int currentIndex = GetResultIndex(id);
            if (currentIndex == -1 || currentIndex == Results.Count - 1)
            {
                return null;
            }

            return Results[currentIndex + 1];
        }

        private int GetResultIndex(ID id)
        {
            return Results.FindIndex(x => x.ItemId == id);
        }

        public List<BehaviorAdvice> GetResultsExcluding(ID id)
        {
            return Results.Where(x => x.ItemId != id).ToList();
        }
    }
}
