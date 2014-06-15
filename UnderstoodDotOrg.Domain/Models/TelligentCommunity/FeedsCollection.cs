using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public class FeedsCollection :  IList<NotificationFeed>
    {
        private IList<NotificationFeed> _list = new List<NotificationFeed>();

        private IList<NotificationFeed> ConvertToFeedList(IEnumerable<INotification> notifs)
        {
            IList<NotificationFeed> lnf = new List<NotificationFeed>();
            //Sort list by notification date
            notifs.ToList().Sort();
            //Group sorted list and extract notification groups into feed then add feed to feed list
            foreach (var item in notifs.GroupBy(x=>x.NotificationDate).Select(x=>x).ToList()  )
            {
                
                NotificationFeed nf = new NotificationFeed(item.ToList(),item.Key);
                lnf.Add(nf);

              

            }

            return lnf;
        }

        public FeedsCollection(IEnumerable<INotification> notifs)
        {
            ///Call some functionality to sort notifications and set the feed lists and the customDate fields of
            ///NotificationFeeds
            if(notifs!=null)
            {
                _list = ConvertToFeedList(notifs);
            }
        }

        public FeedsCollection(IEnumerable<NotificationFeed> notifeeds)
        {
            if (notifeeds != null)
            {
                _list = notifeeds.ToList();
            }
            
        }
        #region IList Implementation
        public int IndexOf(NotificationFeed item)
        {
            return _list.IndexOf(item);
          
        }

        public void Insert(int index, NotificationFeed item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public NotificationFeed this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }

        public void Add(NotificationFeed item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(NotificationFeed item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(NotificationFeed[] array, int arrayIndex)
        {
           _list.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }

        public bool Remove(NotificationFeed item)
        {
            return _list.Remove(item);
        }

        public IEnumerator<NotificationFeed> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
