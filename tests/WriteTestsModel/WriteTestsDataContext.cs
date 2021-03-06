﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v4.2.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using WriteTests.EntityClasses;
using WriteTests.TypedListClasses;

namespace WriteTests
{
	/// <summary>Class which represents the DataContext for the project / group 'WriteTests'</summary>
	/// <remarks>Targets the catalog(s): 'LLBLGenProUnitTest'</remarks>
	public partial class WriteTestsDataContext : System.Data.Linq.DataContext
	{
		private static readonly System.Data.Linq.Mapping.MappingSource _mappingSource = new AttributeMappingSource();
		
		#region Extensibility Method Definitions
		partial void OnCreated();
		#endregion
		
		/// <summary>Initializes a new instance of the <see cref="WriteTestsDataContext"/> class.</summary>
		public WriteTestsDataContext() : 
				base(ConfigurationManager.ConnectionStrings["WriteTestsConnectionString.SQL Server (SqlClient)"].ConnectionString, _mappingSource)
		{
			OnCreated();
		}

		/// <summary>Initializes a new instance of the <see cref="WriteTestsDataContext"/> class.</summary>
		/// <param name="mappingSource">The mapping source.</param>
		public WriteTestsDataContext(System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(ConfigurationManager.ConnectionStrings["WriteTestsConnectionString.SQL Server (SqlClient)"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		/// <summary>Initializes a new instance of the <see cref="WriteTestsDataContext"/> class.</summary>
		/// <param name="connection">The connection.</param>
		public WriteTestsDataContext(string connection) : 
				base(connection, _mappingSource)
		{
			OnCreated();
		}
		
		/// <summary>Initializes a new instance of the <see cref="WriteTestsDataContext"/> class.</summary>
		/// <param name="connection">The connection.</param>
		public WriteTestsDataContext(System.Data.IDbConnection connection) : 
				base(connection, _mappingSource)
		{
			OnCreated();
		}
		
		/// <summary>Initializes a new instance of the <see cref="WriteTestsDataContext"/> class.</summary>
		/// <param name="connection">The connection.</param>
		/// <param name="mappingSource">The mapping source.</param>
		public WriteTestsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		/// <summary>Initializes a new instance of the <see cref="WriteTestsDataContext"/> class.</summary>
		/// <param name="connection">The connection.</param>
		/// <param name="mappingSource">The mapping source.</param>
		public WriteTestsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		/// <summary>Gets an open DbDataReader instance with the results of the query specified</summary>
		/// <param name="query">The query to execute</param>
		/// <returns>An open DbDataReader instance with the results of the query specified</returns>
		/// <remarks>The command behavior is set to CloseConnection.</remarks>
		public DbDataReader GetQueryAsDataReader(IQueryable query)
		{
			return SetupCommand(GetCommand(query), true).ExecuteReader(CommandBehavior.CloseConnection);
		}
		
		/// <summary>Calls the stored procedure '[dbo].[pr_ClearAll]'.</summary>
		/// <returns>The return value or result of the stored procedure called</returns>
		public int CallClearAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())));
			return ((int)(result.ReturnValue));
		}
		
		/// <summary>Calls the stored procedure '[dbo].[pr_ClearTestRunData]'.</summary>
		/// <param name="testRunId">Parameter mapped onto the stored procedure parameter '@testRunID'</param>
		/// <returns>The return value or result of the stored procedure called</returns>
		public int CallClearTestRunData(System.Guid testRunId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), testRunId);
			return ((int)(result.ReturnValue));
		}
		
		/// <summary>Gets the query to fetch the typed list AddressCustomerSpecialCustomer</summary>
		public IQueryable<AddressCustomerSpecialCustomerTypedListRow> GetAddressCustomerSpecialCustomerTypedList()
		{
			var current0 = this.SpecialCustomers;
			var current1 = from specialCustomer in current0
						   join customer in this.Customers on specialCustomer.CustomerId equals customer.CustomerId
						   join address in this.Addresses on customer.VisitingAddressId equals address.AddressId
						   select new {customer, specialCustomer, address };
			return current1.Select(v=>new AddressCustomerSpecialCustomerTypedListRow() { Country = v.address.Country, City = v.address.City, Zipcode = v.address.Zipcode, HouseNumber = v.address.HouseNumber, StreetName = v.address.StreetName, AddressId = v.address.AddressId, CompanyName = v.customer.CompanyName, CustomerSince = v.customer.CustomerSince, ContactPerson = v.customer.ContactPerson, CompanyEmailAddress = v.customer.CompanyEmailAddress, Discount = v.specialCustomer.Discount });
		}
		
		/// <summary>Gets the query to fetch the typed list OrderCustomer</summary>
		public IQueryable<OrderCustomerTypedListRow> GetOrderCustomerTypedList()
		{
			var current0 = this.Customers;
			var current1 = from customer in current0
						   join order in this.Orders on customer.CustomerId equals order.CustomerId
						   select new {order, customer };
			return current1.Select(v=>new OrderCustomerTypedListRow() { OrderId = v.order.OrderId, CompanyName = v.customer.CompanyName, ContactPerson = v.customer.ContactPerson, EmployeeId = v.order.EmployeeId, OrderDate = v.order.OrderDate, CustomerId = v.order.CustomerId, RequiredDate = v.order.RequiredDate, ShippedDate = v.order.ShippedDate });
		}
		
		/// <summary>Gets the query to fetch the typed list Product_</summary>
		public IQueryable<Product_TypedListRow> GetProduct_TypedList()
		{
			var current0 = this.Products;
			return current0.Select(v=>new Product_TypedListRow() { ProductId = v.ProductId, ShortDescription = v.ShortDescription, FullDescription = v.FullDescription, Price = v.Price, TestRunId = v.TestRunId });
		}
		
		/// <summary>Gets the query to fetch the typed list SpecialCustomerCustomerAddress</summary>
		public IQueryable<SpecialCustomerCustomerAddressTypedListRow> GetSpecialCustomerCustomerAddressTypedList()
		{
			var current0 = this.Addresses;
			var current1 = from address in current0
						   join customer in this.Customers on address.AddressId equals customer.VisitingAddressId
						   join specialCustomer in this.SpecialCustomers on customer.CustomerId equals specialCustomer.CustomerId
						   select new {customer, address, specialCustomer };
			return current1.Select(v=>new SpecialCustomerCustomerAddressTypedListRow() { AddressId = v.address.AddressId, StreetName = v.address.StreetName, HouseNumber = v.address.HouseNumber, Zipcode = v.address.Zipcode, City = v.address.City, Country = v.address.Country, CustomerId = v.customer.CustomerId, CompanyName = v.customer.CompanyName, CustomerSince = v.customer.CustomerSince, ContactPerson = v.customer.ContactPerson, CompanyEmailAddress = v.customer.CompanyEmailAddress, Discount = v.specialCustomer.Discount });
		}
		
		/// <summary>Gets the Address Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Address'.</summary>
		public System.Data.Linq.Table<Address> Addresses
		{
			get { return this.GetTable<Address>(); }
		}
		
		/// <summary>Gets the AddressDuplicateFields Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Address'.</summary>
		public System.Data.Linq.Table<AddressDuplicateFields> AddressDuplicateFields
		{
			get { return this.GetTable<AddressDuplicateFields>(); }
		}
		
		/// <summary>Gets the AddressSimple Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Address'.</summary>
		public System.Data.Linq.Table<AddressSimple> AddressSimples
		{
			get { return this.GetTable<AddressSimple>(); }
		}
		
		/// <summary>Gets the Ball Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Ball'.</summary>
		public System.Data.Linq.Table<Ball> Balls
		{
			get { return this.GetTable<Ball>(); }
		}
		
		/// <summary>Gets the BallColor Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.BallColor'.</summary>
		public System.Data.Linq.Table<BallColor> BallColors
		{
			get { return this.GetTable<BallColor>(); }
		}
		
		/// <summary>Gets the Color Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Color'.</summary>
		public System.Data.Linq.Table<Color> Colors
		{
			get { return this.GetTable<Color>(); }
		}
		
		/// <summary>Gets the Company Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Company'.</summary>
		public System.Data.Linq.Table<Company> Companies
		{
			get { return this.GetTable<Company>(); }
		}
		
		/// <summary>Gets the CompanyProperty Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.CompanyProperty'.</summary>
		public System.Data.Linq.Table<CompanyProperty> CompanyProperties
		{
			get { return this.GetTable<CompanyProperty>(); }
		}
		
		/// <summary>Gets the Customer Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Customer'.</summary>
		public System.Data.Linq.Table<Customer> Customers
		{
			get { return this.GetTable<Customer>(); }
		}
		
		/// <summary>Gets the DerivedType1 Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.GuidTPEHTester'.</summary>
		public System.Data.Linq.Table<DerivedType1> DerivedType1s
		{
			get { return this.GetTable<DerivedType1>(); }
		}
		
		/// <summary>Gets the DerivedType2 Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.GuidTPEHTester'.</summary>
		public System.Data.Linq.Table<DerivedType2> DerivedType2s
		{
			get { return this.GetTable<DerivedType2>(); }
		}
		
		/// <summary>Gets the Employee Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Employee'.</summary>
		public System.Data.Linq.Table<Employee> Employees
		{
			get { return this.GetTable<Employee>(); }
		}
		
		/// <summary>Gets the EnumTester Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.EnumTester'.</summary>
		public System.Data.Linq.Table<EnumTester> EnumTesters
		{
			get { return this.GetTable<EnumTester>(); }
		}
		
		/// <summary>Gets the GuidTpehTester Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.GuidTPEHTester'.</summary>
		public System.Data.Linq.Table<GuidTpehTester> GuidTpehTesters
		{
			get { return this.GetTable<GuidTpehTester>(); }
		}
		
		/// <summary>Gets the Order Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Order'.</summary>
		public System.Data.Linq.Table<Order> Orders
		{
			get { return this.GetTable<Order>(); }
		}
		
		/// <summary>Gets the OrderRow Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.OrderRow'.</summary>
		public System.Data.Linq.Table<OrderRow> OrderRows
		{
			get { return this.GetTable<OrderRow>(); }
		}
		
		/// <summary>Gets the Product Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.Product'.</summary>
		public System.Data.Linq.Table<Product> Products
		{
			get { return this.GetTable<Product>(); }
		}
		
		/// <summary>Gets the SpecialCustomer Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.SpecialCustomer'.</summary>
		public System.Data.Linq.Table<SpecialCustomer> SpecialCustomers
		{
			get { return this.GetTable<SpecialCustomer>(); }
		}
		
		/// <summary>Gets the SpecialProduct Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.SpecialProduct'.</summary>
		public System.Data.Linq.Table<SpecialProduct> SpecialProducts
		{
			get { return this.GetTable<SpecialProduct>(); }
		}
		
		/// <summary>Gets the SplitOffBlobData Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.SplitOffTest'.</summary>
		public System.Data.Linq.Table<SplitOffBlobData> SplitOffBlobDatas
		{
			get { return this.GetTable<SplitOffBlobData>(); }
		}
		
		/// <summary>Gets the SplitOffNoBlobData Table definition. Mapped on table 'LLBLGenProUnitTest.dbo.SplitOffTest'.</summary>
		public System.Data.Linq.Table<SplitOffNoBlobData> SplitOffNoBlobDatas
		{
			get { return this.GetTable<SplitOffNoBlobData>(); }
		}
		
		/// <summary>Sets up the command specified. It wires it to the current connection and transaction, sets command timeout and if requested, it also opens the command</summary>
		/// <param name="toSetup">The command to setup</param>
		/// <param name="openConnection">If set to true, the connection is also opened if it's not already open, otherwise it's left as-is</param>
		/// <returns>The passed in DbCommand</returns>
		private DbCommand SetupCommand(DbCommand toSetup, bool openConnection)
		{
			if(toSetup==null)
			{
				return toSetup;
			}
			toSetup.Connection = this.Connection;
			toSetup.Transaction = this.Transaction;
			toSetup.CommandTimeout = this.CommandTimeout;
			if((toSetup.Connection!=null) && openConnection && (toSetup.Connection.State!=ConnectionState.Open))
			{
				toSetup.Connection.Open();
			}
			return toSetup;
		}
				        
		/// <summary>Creates a new stored procedure call command and sets it up to make it ready to use.</summary>
		/// <param name="storedProcedureToCall">The stored procedure to call.</param>
		/// <returns>ready to use command</returns>
		private DbCommand CreateStoredProcCallCommand(string storedProcedureToCall)
		{
			var cmd = this.Connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = storedProcedureToCall;
			return SetupCommand(cmd, false);
		}
        
		/// <summary>Adds a new parameter created from the input specified to the command specified</summary>
		/// <param name="cmd">The command to add the new parameter to</param>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="type">The type.</param>
		/// <param name="length">The length.</param>
		/// <param name="direction">The direction.</param>
		/// <param name="value">The value for the parameter</param>
		private static void AddParameter(DbCommand cmd, string parameterName, SqlDbType type, int length, ParameterDirection direction, object value)
		{
			cmd.Parameters.Add(new SqlParameter(parameterName, type, length) { Direction = direction, Value = value });
		}

	}
}
