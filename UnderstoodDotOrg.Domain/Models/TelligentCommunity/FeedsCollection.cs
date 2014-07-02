using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public class FeedsCollection :  IList<INotificationFeed>
    {
        private IList<INotificationFeed> _list = new List<INotificationFeed>();

        private IList<INotificationFeed> ConvertToFeedList(IEnumerable<INotification> notifs)
        {
            IList<INotificationFeed> lnf = new List<INotificationFeed>();
            //Sort list by notification date
            notifs.ToList().Sort();
            //Group sorted list and extract notification groups into feed then add feed to feed list
            foreach (var item in notifs.GroupBy(x=>x.NotificationDate).Select(x=>x).ToList()  )
            {
                
                INotificationFeed nf = new NotificationFeed(item.ToList(),item.Key);
                lnf.Add(nf);

              

            }

            return lnf;
        }

        public FeedsCollection(IEnumerable<INotification> notifs)
        {
            ///Call some functionality to sort notifications and set the feed lists and the customDate fields of
            ///INotificationFeeds
            if(notifs!=null)
            {
                _list = ConvertToFeedList(notifs);
            }
        }

        public FeedsCollection(IEnumerable<INotificationFeed> notifeeds)
        {
            if (notifeeds != null)
            {
                _list = notifeeds.ToList();
            }
            
        }
        #region IList Implementation
        public int IndexOf(INotificationFeed item)
        {
            return _list.IndexOf(item);
          
        }

        public void Insert(int index, INotificationFeed item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public INotificationFeed this[int index]
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

        public void Add(INotificationFeed item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(INotificationFeed item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(INotificationFeed[] array, int arrayIndex)
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

        public bool Remove(INotificationFeed item)
        {
            return _list.Remove(item);
        }

        public IEnumerator<INotificationFeed> GetEnumerator()
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
