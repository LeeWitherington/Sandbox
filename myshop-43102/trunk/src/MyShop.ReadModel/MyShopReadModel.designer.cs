﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.21006.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyShop.ReadModel
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MyShopReadModel")]
	public partial class MyShopReadModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    partial void InsertShoppingCartItem(ShoppingCartItem instance);
    partial void UpdateShoppingCartItem(ShoppingCartItem instance);
    partial void DeleteShoppingCartItem(ShoppingCartItem instance);
    partial void InsertShoppingCart(ShoppingCart instance);
    partial void UpdateShoppingCart(ShoppingCart instance);
    partial void DeleteShoppingCart(ShoppingCart instance);
    partial void InsertUserRole(UserRole instance);
    partial void UpdateUserRole(UserRole instance);
    partial void DeleteUserRole(UserRole instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertVisitor(Visitor instance);
    partial void UpdateVisitor(Visitor instance);
    partial void DeleteVisitor(Visitor instance);
    partial void InsertVisit(Visit instance);
    partial void UpdateVisit(Visit instance);
    partial void DeleteVisit(Visit instance);
    #endregion
		
		public MyShopReadModelDataContext() : 
				base(global::MyShop.ReadModel.Properties.Settings.Default.MyShopReadModelConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public MyShopReadModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyShopReadModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyShopReadModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyShopReadModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
		
		public System.Data.Linq.Table<ShoppingCartItem> ShoppingCartItems
		{
			get
			{
				return this.GetTable<ShoppingCartItem>();
			}
		}
		
		public System.Data.Linq.Table<ShoppingCart> ShoppingCarts
		{
			get
			{
				return this.GetTable<ShoppingCart>();
			}
		}
		
		public System.Data.Linq.Table<UserRole> UserRoles
		{
			get
			{
				return this.GetTable<UserRole>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Visitor> Visitors
		{
			get
			{
				return this.GetTable<Visitor>();
			}
		}
		
		public System.Data.Linq.Table<Visit> Visits
		{
			get
			{
				return this.GetTable<Visit>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Products")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Name;
		
		private string _Description;
		
		private decimal _UnitPrice;
		
		private int _UnitsInStock;
		
		private string _ImageFilename;
		
		private EntitySet<ShoppingCartItem> _ShoppingCartItems;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnUnitPriceChanging(decimal value);
    partial void OnUnitPriceChanged();
    partial void OnUnitsInStockChanging(int value);
    partial void OnUnitsInStockChanged();
    partial void OnImageFilenameChanging(string value);
    partial void OnImageFilenameChanged();
    #endregion
		
		public Product()
		{
			this._ShoppingCartItems = new EntitySet<ShoppingCartItem>(new Action<ShoppingCartItem>(this.attach_ShoppingCartItems), new Action<ShoppingCartItem>(this.detach_ShoppingCartItems));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UnitPrice", DbType="Decimal(18,0) NOT NULL")]
		public decimal UnitPrice
		{
			get
			{
				return this._UnitPrice;
			}
			set
			{
				if ((this._UnitPrice != value))
				{
					this.OnUnitPriceChanging(value);
					this.SendPropertyChanging();
					this._UnitPrice = value;
					this.SendPropertyChanged("UnitPrice");
					this.OnUnitPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UnitsInStock", DbType="Int NOT NULL")]
		public int UnitsInStock
		{
			get
			{
				return this._UnitsInStock;
			}
			set
			{
				if ((this._UnitsInStock != value))
				{
					this.OnUnitsInStockChanging(value);
					this.SendPropertyChanging();
					this._UnitsInStock = value;
					this.SendPropertyChanged("UnitsInStock");
					this.OnUnitsInStockChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageFilename", DbType="NVarChar(MAX)")]
		public string ImageFilename
		{
			get
			{
				return this._ImageFilename;
			}
			set
			{
				if ((this._ImageFilename != value))
				{
					this.OnImageFilenameChanging(value);
					this.SendPropertyChanging();
					this._ImageFilename = value;
					this.SendPropertyChanged("ImageFilename");
					this.OnImageFilenameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_ShoppingCartItem", Storage="_ShoppingCartItems", ThisKey="Id", OtherKey="ProductId")]
		public EntitySet<ShoppingCartItem> ShoppingCartItems
		{
			get
			{
				return this._ShoppingCartItems;
			}
			set
			{
				this._ShoppingCartItems.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ShoppingCartItems(ShoppingCartItem entity)
		{
			this.SendPropertyChanging();
			entity.Product = this;
		}
		
		private void detach_ShoppingCartItems(ShoppingCartItem entity)
		{
			this.SendPropertyChanging();
			entity.Product = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ShoppingCartItems")]
	public partial class ShoppingCartItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ShoppingCartId;
		
		private System.Guid _ProductId;
		
		private int _Quantity;
		
		private EntityRef<Product> _Product;
		
		private EntityRef<ShoppingCart> _ShoppingCart;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnShoppingCartIdChanging(System.Guid value);
    partial void OnShoppingCartIdChanged();
    partial void OnProductIdChanging(System.Guid value);
    partial void OnProductIdChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    #endregion
		
		public ShoppingCartItem()
		{
			this._Product = default(EntityRef<Product>);
			this._ShoppingCart = default(EntityRef<ShoppingCart>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShoppingCartId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ShoppingCartId
		{
			get
			{
				return this._ShoppingCartId;
			}
			set
			{
				if ((this._ShoppingCartId != value))
				{
					if (this._ShoppingCart.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnShoppingCartIdChanging(value);
					this.SendPropertyChanging();
					this._ShoppingCartId = value;
					this.SendPropertyChanged("ShoppingCartId");
					this.OnShoppingCartIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ProductId
		{
			get
			{
				return this._ProductId;
			}
			set
			{
				if ((this._ProductId != value))
				{
					if (this._Product.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProductIdChanging(value);
					this.SendPropertyChanging();
					this._ProductId = value;
					this.SendPropertyChanged("ProductId");
					this.OnProductIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_ShoppingCartItem", Storage="_Product", ThisKey="ProductId", OtherKey="Id", IsForeignKey=true)]
		public Product Product
		{
			get
			{
				return this._Product.Entity;
			}
			set
			{
				Product previousValue = this._Product.Entity;
				if (((previousValue != value) 
							|| (this._Product.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Product.Entity = null;
						previousValue.ShoppingCartItems.Remove(this);
					}
					this._Product.Entity = value;
					if ((value != null))
					{
						value.ShoppingCartItems.Add(this);
						this._ProductId = value.Id;
					}
					else
					{
						this._ProductId = default(System.Guid);
					}
					this.SendPropertyChanged("Product");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ShoppingCart_ShoppingCartItem", Storage="_ShoppingCart", ThisKey="ShoppingCartId", OtherKey="Id", IsForeignKey=true)]
		public ShoppingCart ShoppingCart
		{
			get
			{
				return this._ShoppingCart.Entity;
			}
			set
			{
				ShoppingCart previousValue = this._ShoppingCart.Entity;
				if (((previousValue != value) 
							|| (this._ShoppingCart.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ShoppingCart.Entity = null;
						previousValue.ShoppingCartItems.Remove(this);
					}
					this._ShoppingCart.Entity = value;
					if ((value != null))
					{
						value.ShoppingCartItems.Add(this);
						this._ShoppingCartId = value.Id;
					}
					else
					{
						this._ShoppingCartId = default(System.Guid);
					}
					this.SendPropertyChanged("ShoppingCart");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ShoppingCarts")]
	public partial class ShoppingCart : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _VisitorId;
		
		private System.Nullable<System.DateTime> _CreationTimeStamp;
		
		private EntitySet<ShoppingCartItem> _ShoppingCartItems;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnVisitorIdChanging(System.Guid value);
    partial void OnVisitorIdChanged();
    partial void OnCreationTimeStampChanging(System.Nullable<System.DateTime> value);
    partial void OnCreationTimeStampChanged();
    #endregion
		
		public ShoppingCart()
		{
			this._ShoppingCartItems = new EntitySet<ShoppingCartItem>(new Action<ShoppingCartItem>(this.attach_ShoppingCartItems), new Action<ShoppingCartItem>(this.detach_ShoppingCartItems));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VisitorId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid VisitorId
		{
			get
			{
				return this._VisitorId;
			}
			set
			{
				if ((this._VisitorId != value))
				{
					this.OnVisitorIdChanging(value);
					this.SendPropertyChanging();
					this._VisitorId = value;
					this.SendPropertyChanged("VisitorId");
					this.OnVisitorIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreationTimeStamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreationTimeStamp
		{
			get
			{
				return this._CreationTimeStamp;
			}
			set
			{
				if ((this._CreationTimeStamp != value))
				{
					this.OnCreationTimeStampChanging(value);
					this.SendPropertyChanging();
					this._CreationTimeStamp = value;
					this.SendPropertyChanged("CreationTimeStamp");
					this.OnCreationTimeStampChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ShoppingCart_ShoppingCartItem", Storage="_ShoppingCartItems", ThisKey="Id", OtherKey="ShoppingCartId")]
		public EntitySet<ShoppingCartItem> ShoppingCartItems
		{
			get
			{
				return this._ShoppingCartItems;
			}
			set
			{
				this._ShoppingCartItems.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ShoppingCartItems(ShoppingCartItem entity)
		{
			this.SendPropertyChanging();
			entity.ShoppingCart = this;
		}
		
		private void detach_ShoppingCartItems(ShoppingCartItem entity)
		{
			this.SendPropertyChanging();
			entity.ShoppingCart = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserRoles")]
	public partial class UserRole : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _UserId;
		
		private string _RoleName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    partial void OnRoleNameChanging(string value);
    partial void OnRoleNameChanged();
    #endregion
		
		public UserRole()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleName", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string RoleName
		{
			get
			{
				return this._RoleName;
			}
			set
			{
				if ((this._RoleName != value))
				{
					this.OnRoleNameChanging(value);
					this.SendPropertyChanging();
					this._RoleName = value;
					this.SendPropertyChanged("RoleName");
					this.OnRoleNameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Username;
		
		private string _Password;
		
		private string _Email;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Visitors")]
	public partial class Visitor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    #endregion
		
		public Visitor()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Visits")]
	public partial class Visit : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _VisitorId;
		
		private System.DateTime _TimeStamp;
		
		private string _Url;
		
		private string _IpAddress;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnVisitorIdChanging(System.Guid value);
    partial void OnVisitorIdChanged();
    partial void OnTimeStampChanging(System.DateTime value);
    partial void OnTimeStampChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    partial void OnIpAddressChanging(string value);
    partial void OnIpAddressChanged();
    #endregion
		
		public Visit()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VisitorId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid VisitorId
		{
			get
			{
				return this._VisitorId;
			}
			set
			{
				if ((this._VisitorId != value))
				{
					this.OnVisitorIdChanging(value);
					this.SendPropertyChanging();
					this._VisitorId = value;
					this.SendPropertyChanged("VisitorId");
					this.OnVisitorIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeStamp", DbType="DateTime NOT NULL")]
		public System.DateTime TimeStamp
		{
			get
			{
				return this._TimeStamp;
			}
			set
			{
				if ((this._TimeStamp != value))
				{
					this.OnTimeStampChanging(value);
					this.SendPropertyChanging();
					this._TimeStamp = value;
					this.SendPropertyChanged("TimeStamp");
					this.OnTimeStampChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this.OnUrlChanging(value);
					this.SendPropertyChanging();
					this._Url = value;
					this.SendPropertyChanged("Url");
					this.OnUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IpAddress", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string IpAddress
		{
			get
			{
				return this._IpAddress;
			}
			set
			{
				if ((this._IpAddress != value))
				{
					this.OnIpAddressChanging(value);
					this.SendPropertyChanging();
					this._IpAddress = value;
					this.SendPropertyChanged("IpAddress");
					this.OnIpAddressChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
