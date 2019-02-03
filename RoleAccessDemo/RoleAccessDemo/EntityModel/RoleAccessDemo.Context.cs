﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoleAccessDemo.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class TestEntities : DbContext
    {
        public TestEntities()
            : base("name=TestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<PageAccess> PageAccesses { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    
        public virtual ObjectResult<GetPageAccessByUser_Result> GetPageAccessByUser(Nullable<int> userID, Nullable<int> parentPageID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var parentPageIDParameter = parentPageID.HasValue ?
                new ObjectParameter("ParentPageID", parentPageID) :
                new ObjectParameter("ParentPageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPageAccessByUser_Result>("GetPageAccessByUser", userIDParameter, parentPageIDParameter);
        }
    
        public virtual ObjectResult<GetPagesByParentPage_Result> GetPagesByParentPage(Nullable<int> parentPageID)
        {
            var parentPageIDParameter = parentPageID.HasValue ?
                new ObjectParameter("ParentPageID", parentPageID) :
                new ObjectParameter("ParentPageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPagesByParentPage_Result>("GetPagesByParentPage", parentPageIDParameter);
        }
    
        public virtual ObjectResult<GetParentPages_Result> GetParentPages()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetParentPages_Result>("GetParentPages");
        }
    }
}