




















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `DefaultConnection`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=MauliMarineDBRES;Integrated Security=True`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace MauliMarineRes
{

	public partial class Repository : Database
	{
		public Repository() 
			: base("DefaultConnection")
		{
			CommonConstruct();
		}

		public Repository(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			Repository GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static Repository GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new Repository();
        }

		[ThreadStatic] static Repository _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static Repository repo { get { return Repository.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

		}

	}
	



    

	[TableName("dbo.__MigrationHistory")]



	[PrimaryKey("MigrationId", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class __MigrationHistory : Repository.Record<__MigrationHistory>  
    {



		[Column] public string MigrationId { get; set; }





		[Column] public string ContextKey { get; set; }





		[Column] public byte[] Model { get; set; }





		[Column] public string ProductVersion { get; set; }



	}

    

	[TableName("dbo.__RefactorLog")]



	[PrimaryKey("OperationKey", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class __RefactorLog : Repository.Record<__RefactorLog>  
    {



		[Column] public Guid OperationKey { get; set; }



	}

    

	[TableName("dbo.AspNetRoles")]



	[PrimaryKey("Id", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class AspNetRole : Repository.Record<AspNetRole>  
    {



		[Column] public string Id { get; set; }





		[Column] public string Name { get; set; }



	}

    

	[TableName("dbo.AspNetUserClaims")]



	[PrimaryKey("Id")]




	[ExplicitColumns]

    public partial class AspNetUserClaim : Repository.Record<AspNetUserClaim>  
    {



		[Column] public int Id { get; set; }





		[Column] public string UserId { get; set; }





		[Column] public string ClaimType { get; set; }





		[Column] public string ClaimValue { get; set; }



	}

    

	[TableName("dbo.AspNetUserLogins")]



	[PrimaryKey("LoginProvider", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class AspNetUserLogin : Repository.Record<AspNetUserLogin>  
    {



		[Column] public string LoginProvider { get; set; }





		[Column] public string ProviderKey { get; set; }





		[Column] public string UserId { get; set; }



	}

    

	[TableName("dbo.AspNetUserRoles")]



	[PrimaryKey("UserId", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class AspNetUserRole : Repository.Record<AspNetUserRole>  
    {



		[Column] public string UserId { get; set; }





		[Column] public string RoleId { get; set; }



	}

    

	[TableName("dbo.AspNetUsers")]



	[PrimaryKey("Id", AutoIncrement=false)]


	[ExplicitColumns]

    public partial class AspNetUser : Repository.Record<AspNetUser>  
    {



		[Column] public string Id { get; set; }





		[Column] public string Email { get; set; }





		[Column] public bool EmailConfirmed { get; set; }





		[Column] public string PasswordHash { get; set; }





		[Column] public string SecurityStamp { get; set; }





		[Column] public string PhoneNumber { get; set; }





		[Column] public bool PhoneNumberConfirmed { get; set; }





		[Column] public bool TwoFactorEnabled { get; set; }





		[Column] public DateTime? LockoutEndDateUtc { get; set; }





		[Column] public bool LockoutEnabled { get; set; }





		[Column] public int AccessFailedCount { get; set; }





		[Column] public string UserName { get; set; }



	}

    

	[TableName("dbo.Material")]



	[PrimaryKey("MaterialId")]




	[ExplicitColumns]

    public partial class Material : Repository.Record<Material>  
    {



		[Column] public int MaterialId { get; set; }





		[Column] public string MaterialName { get; set; }





		[Column] public string Quantity { get; set; }





		[Column] public int? UnitId { get; set; }



	}

    

	[TableName("dbo.Supplier")]



	[PrimaryKey("SupplierId")]




	[ExplicitColumns]

    public partial class Supplier : Repository.Record<Supplier>  
    {



		[Column] public int SupplierId { get; set; }





		[Column] public string SupplierName { get; set; }





		[Column] public string ContactName { get; set; }





		[Column] public string ContactNo { get; set; }





		[Column] public string Email { get; set; }





		[Column] public string Address { get; set; }



	}

    

	[TableName("dbo.Transactions")]



	[PrimaryKey("TicketNo")]




	[ExplicitColumns]

    public partial class Transaction : Repository.Record<Transaction>  
    {



		[Column] public int TicketNo { get; set; }





		[Column] public int? UnitId { get; set; }





		[Column] public int? VeichleId { get; set; }





		[Column] public decimal? LoadedWeight { get; set; }





		[Column] public decimal? EmptyWeight { get; set; }





		[Column] public decimal? NetWeight { get; set; }





		[Column] public int? SupplierId { get; set; }





		[Column] public int? MaterialId { get; set; }





		[Column] public decimal? RecievedAmt { get; set; }





		[Column] public DateTime? Tdate { get; set; }



	}

    

	[TableName("dbo.Units")]



	[PrimaryKey("UnitId")]




	[ExplicitColumns]

    public partial class Unit : Repository.Record<Unit>  
    {



		[Column] public int UnitId { get; set; }





		[Column] public string UnitName { get; set; }



	}

    

	[TableName("dbo.VeichleEntry")]



	[PrimaryKey("VeichleId")]




	[ExplicitColumns]

    public partial class VeichleEntry : Repository.Record<VeichleEntry>  
    {



		[Column] public int VeichleId { get; set; }





		[Column] public string VeichleNumber { get; set; }



	}


}
