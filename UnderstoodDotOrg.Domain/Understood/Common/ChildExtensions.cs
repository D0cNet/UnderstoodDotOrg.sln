using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;


namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public static class ChildExtensions
    {
        
       public static List<ChildCardModel> ConvertToChildCardModelList(this ICollection<Child> chList)
        {
            List<ChildCardModel> chModelList = new List<ChildCardModel>();

            try
            {
                foreach (var ch in chList)
                {
                    ChildCardModel chModel = new ChildCardModel();
                    chModel = ch;
                    chModelList.Add(chModel);
                }

            }catch(Exception)
            {
                chModelList = null;
            }
            return chModelList;
        }
    }
}
