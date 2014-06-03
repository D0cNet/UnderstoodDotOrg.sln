using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using UnderstoodDotOrg.Domain.Understood.Quiz;

namespace UnderstoodDotOrg.Domain.Membership
{
    /// <summary>
    /// Provides custom constructor for Child, which ensures ChildId is populated when new instance is created
    /// </summary>
    public partial class Child
    {
        /// <summary>
        /// Creates a new instance of Child, and ensures ChildId is populated
        /// </summary>
        public Child()
        {
            this.ChildId = Guid.NewGuid();

            this.Diagnoses = new HashSet<Diagnosis>();
            this.Issues = new HashSet<Issue>();
            this.Members = new HashSet<Member>();
            this.Grades = new HashSet<Grade>();
        }
    }

    /// <summary>
    /// Provides custom constructor for Member, which ensures MemberId is populated when new instance is created
    /// </summary>
    public partial class Member
    {
        /// <summary>
        /// Creates a new instance of Member, and ensures MemberId is populated
        /// </summary>
        public Member()
        {
            this.MemberId = Guid.NewGuid();

            this.Children = new HashSet<Child>();
            this.Interests = new HashSet<Interest>();
            this.Journeys = new HashSet<Journey>();
            this.CompletedQuizes = new HashSet<Quiz>();
        }
    }

    //public partial class Membership
    //{
    //    public static void UpdateManyToMany<TSingle, TMany>(this DbContext ctx, TSingle localItem, Func<TSingle, ICollection<TMany>> collectionSelector)
    //        where TSingle : class
    //        where TMany : class
    //    {
    //        DbSet<TSingle> localItemDbSet = ctx.Set(typeof(TSingle)).Cast<TSingle>();
    //        DbSet<TMany> manyItemDbSet = ctx.Set(typeof(TMany)).Cast<TMany>();

    //        ObjectContext objectContext = ((IObjectContextAdapter)ctx).ObjectContext;
    //        ObjectSet<TSingle> tempSet = objectContext.CreateObjectSet<TSingle>();
    //        IEnumerable<string> localItemKeyNames = tempSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name);

    //        var localItemKeysArray = localItemKeyNames.Select(kn => typeof(TSingle).GetProperty(kn).GetValue(localItem, null));

    //        localItemDbSet.Load();

    //        TSingle dbVerOfLocalItem = localItemDbSet.Find(localItemKeysArray.ToArray());
    //        IEnumerable<TMany> localCol = collectionSelector(localItem) ?? Enumerable.Empty<TMany>();
    //        ICollection<TMany> dbColl = collectionSelector(dbVerOfLocalItem);
    //        dbColl.Clear();

    //        ObjectSet<TMany> tempSet1 = objectContext.CreateObjectSet<TMany>();
    //        IEnumerable<string> collectionKeyNames = tempSet1.EntitySet.ElementType.KeyMembers.Select(k => k.Name);

    //        var selectedDbCats = localCol
    //            .Select(c => collectionKeyNames.Select(kn => typeof(TMany).GetProperty(kn).GetValue(c, null)).ToArray())
    //            .Select(manyItemDbSet.Find);
    //        foreach (TMany xx in selectedDbCats)
    //        {
    //            dbColl.Add(xx);
    //        }
    //        ctx.Entry(dbVerOfLocalItem).CurrentValues.SetValues(localItem);
    //    }
    //}
}
