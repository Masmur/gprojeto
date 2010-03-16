﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3607
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GerenciadorProjeto.Models
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Projetos")]
	public partial class ModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEmpresa(Empresa instance);
    partial void UpdateEmpresa(Empresa instance);
    partial void DeleteEmpresa(Empresa instance);
    partial void InsertBacklogItem(BacklogItem instance);
    partial void UpdateBacklogItem(BacklogItem instance);
    partial void DeleteBacklogItem(BacklogItem instance);
    partial void InsertSprintBackLog(SprintBackLog instance);
    partial void UpdateSprintBackLog(SprintBackLog instance);
    partial void DeleteSprintBackLog(SprintBackLog instance);
    partial void InsertProduto(Produto instance);
    partial void UpdateProduto(Produto instance);
    partial void DeleteProduto(Produto instance);
    partial void InsertColaborador(Colaborador instance);
    partial void UpdateColaborador(Colaborador instance);
    partial void DeleteColaborador(Colaborador instance);
    partial void InsertSprint(Sprint instance);
    partial void UpdateSprint(Sprint instance);
    partial void DeleteSprint(Sprint instance);
    #endregion
		
		public ModelDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ProjetosConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Empresa> Empresas
		{
			get
			{
				return this.GetTable<Empresa>();
			}
		}
		
		public System.Data.Linq.Table<BacklogItem> BacklogItems
		{
			get
			{
				return this.GetTable<BacklogItem>();
			}
		}
		
		public System.Data.Linq.Table<SprintBackLog> SprintBackLogs
		{
			get
			{
				return this.GetTable<SprintBackLog>();
			}
		}
		
		public System.Data.Linq.Table<Produto> Produtos
		{
			get
			{
				return this.GetTable<Produto>();
			}
		}
		
		public System.Data.Linq.Table<Colaborador> Colaboradors
		{
			get
			{
				return this.GetTable<Colaborador>();
			}
		}
		
		public System.Data.Linq.Table<Sprint> Sprints
		{
			get
			{
				return this.GetTable<Sprint>();
			}
		}
		
		public System.Data.Linq.Table<vBackLogProduto> vBackLogProdutos
		{
			get
			{
				return this.GetTable<vBackLogProduto>();
			}
		}
		
		public System.Data.Linq.Table<vSprintBackLog> vSprintBackLogs
		{
			get
			{
				return this.GetTable<vSprintBackLog>();
			}
		}
	}
	
	[Table(Name="dbo.Empresas")]
	public partial class Empresa : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _EmpresaId;
		
		private string _Nome;
		
		private EntitySet<Produto> _Produtos;
		
		private EntitySet<Colaborador> _Colaboradors;
		
		private EntitySet<Sprint> _Sprints;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmpresaIdChanging(long value);
    partial void OnEmpresaIdChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    #endregion
		
		public Empresa()
		{
			this._Produtos = new EntitySet<Produto>(new Action<Produto>(this.attach_Produtos), new Action<Produto>(this.detach_Produtos));
			this._Colaboradors = new EntitySet<Colaborador>(new Action<Colaborador>(this.attach_Colaboradors), new Action<Colaborador>(this.detach_Colaboradors));
			this._Sprints = new EntitySet<Sprint>(new Action<Sprint>(this.attach_Sprints), new Action<Sprint>(this.detach_Sprints));
			OnCreated();
		}
		
		[Column(Storage="_EmpresaId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long EmpresaId
		{
			get
			{
				return this._EmpresaId;
			}
			set
			{
				if ((this._EmpresaId != value))
				{
					this.OnEmpresaIdChanging(value);
					this.SendPropertyChanging();
					this._EmpresaId = value;
					this.SendPropertyChanged("EmpresaId");
					this.OnEmpresaIdChanged();
				}
			}
		}
		
		[Column(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[Association(Name="Empresa_Produto", Storage="_Produtos", ThisKey="EmpresaId", OtherKey="EmpresaId")]
		public EntitySet<Produto> Produtos
		{
			get
			{
				return this._Produtos;
			}
			set
			{
				this._Produtos.Assign(value);
			}
		}
		
		[Association(Name="Empresa_Colaborador", Storage="_Colaboradors", ThisKey="EmpresaId", OtherKey="EmpresaId")]
		public EntitySet<Colaborador> Colaboradors
		{
			get
			{
				return this._Colaboradors;
			}
			set
			{
				this._Colaboradors.Assign(value);
			}
		}
		
		[Association(Name="Empresa_Sprint", Storage="_Sprints", ThisKey="EmpresaId", OtherKey="EmpresaId")]
		public EntitySet<Sprint> Sprints
		{
			get
			{
				return this._Sprints;
			}
			set
			{
				this._Sprints.Assign(value);
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
		
		private void attach_Produtos(Produto entity)
		{
			this.SendPropertyChanging();
			entity.Empresa = this;
		}
		
		private void detach_Produtos(Produto entity)
		{
			this.SendPropertyChanging();
			entity.Empresa = null;
		}
		
		private void attach_Colaboradors(Colaborador entity)
		{
			this.SendPropertyChanging();
			entity.Empresa = this;
		}
		
		private void detach_Colaboradors(Colaborador entity)
		{
			this.SendPropertyChanging();
			entity.Empresa = null;
		}
		
		private void attach_Sprints(Sprint entity)
		{
			this.SendPropertyChanging();
			entity.Empresa = this;
		}
		
		private void detach_Sprints(Sprint entity)
		{
			this.SendPropertyChanging();
			entity.Empresa = null;
		}
	}
	
	[Table(Name="dbo.BacklogItem")]
	public partial class BacklogItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _BacklogItemId;
		
		private long _ProdutoId;
		
		private string _Nome;
		
		private string _Nota;
		
		private System.DateTime _Data;
		
		private double _Estimativa;
		
		private EntitySet<SprintBackLog> _SprintBackLogs;
		
		private EntityRef<Produto> _Produto;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBacklogItemIdChanging(long value);
    partial void OnBacklogItemIdChanged();
    partial void OnProdutoIdChanging(long value);
    partial void OnProdutoIdChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnNotaChanging(string value);
    partial void OnNotaChanged();
    partial void OnDataChanging(System.DateTime value);
    partial void OnDataChanged();
    partial void OnEstimativaChanging(double value);
    partial void OnEstimativaChanged();
    #endregion
		
		public BacklogItem()
		{
			this._SprintBackLogs = new EntitySet<SprintBackLog>(new Action<SprintBackLog>(this.attach_SprintBackLogs), new Action<SprintBackLog>(this.detach_SprintBackLogs));
			this._Produto = default(EntityRef<Produto>);
			OnCreated();
		}
		
		[Column(Storage="_BacklogItemId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long BacklogItemId
		{
			get
			{
				return this._BacklogItemId;
			}
			set
			{
				if ((this._BacklogItemId != value))
				{
					this.OnBacklogItemIdChanging(value);
					this.SendPropertyChanging();
					this._BacklogItemId = value;
					this.SendPropertyChanged("BacklogItemId");
					this.OnBacklogItemIdChanged();
				}
			}
		}
		
		[Column(Storage="_ProdutoId", DbType="BigInt NOT NULL")]
		public long ProdutoId
		{
			get
			{
				return this._ProdutoId;
			}
			set
			{
				if ((this._ProdutoId != value))
				{
					if (this._Produto.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProdutoIdChanging(value);
					this.SendPropertyChanging();
					this._ProdutoId = value;
					this.SendPropertyChanged("ProdutoId");
					this.OnProdutoIdChanged();
				}
			}
		}
		
		[Column(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[Column(Storage="_Nota", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Nota
		{
			get
			{
				return this._Nota;
			}
			set
			{
				if ((this._Nota != value))
				{
					this.OnNotaChanging(value);
					this.SendPropertyChanging();
					this._Nota = value;
					this.SendPropertyChanged("Nota");
					this.OnNotaChanged();
				}
			}
		}
		
		[Column(Storage="_Data", DbType="SmallDateTime NOT NULL", IsDbGenerated=true)]
		public System.DateTime Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[Column(Storage="_Estimativa", DbType="Float NOT NULL")]
		public double Estimativa
		{
			get
			{
				return this._Estimativa;
			}
			set
			{
				if ((this._Estimativa != value))
				{
					this.OnEstimativaChanging(value);
					this.SendPropertyChanging();
					this._Estimativa = value;
					this.SendPropertyChanged("Estimativa");
					this.OnEstimativaChanged();
				}
			}
		}
		
		[Association(Name="BacklogItem_SprintBackLog", Storage="_SprintBackLogs", ThisKey="BacklogItemId", OtherKey="BacklogItemId")]
		public EntitySet<SprintBackLog> SprintBackLogs
		{
			get
			{
				return this._SprintBackLogs;
			}
			set
			{
				this._SprintBackLogs.Assign(value);
			}
		}
		
		[Association(Name="Produto_BacklogItem", Storage="_Produto", ThisKey="ProdutoId", OtherKey="ProdutoId", IsForeignKey=true)]
		public Produto Produto
		{
			get
			{
				return this._Produto.Entity;
			}
			set
			{
				Produto previousValue = this._Produto.Entity;
				if (((previousValue != value) 
							|| (this._Produto.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Produto.Entity = null;
						previousValue.BacklogItems.Remove(this);
					}
					this._Produto.Entity = value;
					if ((value != null))
					{
						value.BacklogItems.Add(this);
						this._ProdutoId = value.ProdutoId;
					}
					else
					{
						this._ProdutoId = default(long);
					}
					this.SendPropertyChanged("Produto");
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
		
		private void attach_SprintBackLogs(SprintBackLog entity)
		{
			this.SendPropertyChanging();
			entity.BacklogItem = this;
		}
		
		private void detach_SprintBackLogs(SprintBackLog entity)
		{
			this.SendPropertyChanging();
			entity.BacklogItem = null;
		}
	}
	
	[Table(Name="dbo.SprintBackLog")]
	public partial class SprintBackLog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _SprintId;
		
		private long _BacklogItemId;
		
		private EntityRef<BacklogItem> _BacklogItem;
		
		private EntityRef<Sprint> _Sprint;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSprintIdChanging(long value);
    partial void OnSprintIdChanged();
    partial void OnBacklogItemIdChanging(long value);
    partial void OnBacklogItemIdChanged();
    #endregion
		
		public SprintBackLog()
		{
			this._BacklogItem = default(EntityRef<BacklogItem>);
			this._Sprint = default(EntityRef<Sprint>);
			OnCreated();
		}
		
		[Column(Storage="_SprintId", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long SprintId
		{
			get
			{
				return this._SprintId;
			}
			set
			{
				if ((this._SprintId != value))
				{
					if (this._Sprint.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSprintIdChanging(value);
					this.SendPropertyChanging();
					this._SprintId = value;
					this.SendPropertyChanged("SprintId");
					this.OnSprintIdChanged();
				}
			}
		}
		
		[Column(Storage="_BacklogItemId", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long BacklogItemId
		{
			get
			{
				return this._BacklogItemId;
			}
			set
			{
				if ((this._BacklogItemId != value))
				{
					if (this._BacklogItem.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBacklogItemIdChanging(value);
					this.SendPropertyChanging();
					this._BacklogItemId = value;
					this.SendPropertyChanged("BacklogItemId");
					this.OnBacklogItemIdChanged();
				}
			}
		}
		
		[Association(Name="BacklogItem_SprintBackLog", Storage="_BacklogItem", ThisKey="BacklogItemId", OtherKey="BacklogItemId", IsForeignKey=true)]
		public BacklogItem BacklogItem
		{
			get
			{
				return this._BacklogItem.Entity;
			}
			set
			{
				BacklogItem previousValue = this._BacklogItem.Entity;
				if (((previousValue != value) 
							|| (this._BacklogItem.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._BacklogItem.Entity = null;
						previousValue.SprintBackLogs.Remove(this);
					}
					this._BacklogItem.Entity = value;
					if ((value != null))
					{
						value.SprintBackLogs.Add(this);
						this._BacklogItemId = value.BacklogItemId;
					}
					else
					{
						this._BacklogItemId = default(long);
					}
					this.SendPropertyChanged("BacklogItem");
				}
			}
		}
		
		[Association(Name="Sprint_SprintBackLog", Storage="_Sprint", ThisKey="SprintId", OtherKey="SprintId", IsForeignKey=true)]
		public Sprint Sprint
		{
			get
			{
				return this._Sprint.Entity;
			}
			set
			{
				Sprint previousValue = this._Sprint.Entity;
				if (((previousValue != value) 
							|| (this._Sprint.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Sprint.Entity = null;
						previousValue.SprintBackLogs.Remove(this);
					}
					this._Sprint.Entity = value;
					if ((value != null))
					{
						value.SprintBackLogs.Add(this);
						this._SprintId = value.SprintId;
					}
					else
					{
						this._SprintId = default(long);
					}
					this.SendPropertyChanged("Sprint");
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
	
	[Table(Name="dbo.Produtos")]
	public partial class Produto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ProdutoId;
		
		private long _EmpresaId;
		
		private string _Nome;
		
		private System.DateTime _Data;
		
		private EntitySet<BacklogItem> _BacklogItems;
		
		private EntityRef<Empresa> _Empresa;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProdutoIdChanging(long value);
    partial void OnProdutoIdChanged();
    partial void OnEmpresaIdChanging(long value);
    partial void OnEmpresaIdChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnDataChanging(System.DateTime value);
    partial void OnDataChanged();
    #endregion
		
		public Produto()
		{
			this._BacklogItems = new EntitySet<BacklogItem>(new Action<BacklogItem>(this.attach_BacklogItems), new Action<BacklogItem>(this.detach_BacklogItems));
			this._Empresa = default(EntityRef<Empresa>);
			OnCreated();
		}
		
		[Column(Storage="_ProdutoId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ProdutoId
		{
			get
			{
				return this._ProdutoId;
			}
			set
			{
				if ((this._ProdutoId != value))
				{
					this.OnProdutoIdChanging(value);
					this.SendPropertyChanging();
					this._ProdutoId = value;
					this.SendPropertyChanged("ProdutoId");
					this.OnProdutoIdChanged();
				}
			}
		}
		
		[Column(Storage="_EmpresaId", DbType="BigInt NOT NULL")]
		public long EmpresaId
		{
			get
			{
				return this._EmpresaId;
			}
			set
			{
				if ((this._EmpresaId != value))
				{
					if (this._Empresa.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmpresaIdChanging(value);
					this.SendPropertyChanging();
					this._EmpresaId = value;
					this.SendPropertyChanged("EmpresaId");
					this.OnEmpresaIdChanged();
				}
			}
		}
		
		[Column(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[Column(Storage="_Data", DbType="SmallDateTime NOT NULL", IsDbGenerated=true)]
		public System.DateTime Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[Association(Name="Produto_BacklogItem", Storage="_BacklogItems", ThisKey="ProdutoId", OtherKey="ProdutoId")]
		public EntitySet<BacklogItem> BacklogItems
		{
			get
			{
				return this._BacklogItems;
			}
			set
			{
				this._BacklogItems.Assign(value);
			}
		}
		
		[Association(Name="Empresa_Produto", Storage="_Empresa", ThisKey="EmpresaId", OtherKey="EmpresaId", IsForeignKey=true)]
		public Empresa Empresa
		{
			get
			{
				return this._Empresa.Entity;
			}
			set
			{
				Empresa previousValue = this._Empresa.Entity;
				if (((previousValue != value) 
							|| (this._Empresa.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Empresa.Entity = null;
						previousValue.Produtos.Remove(this);
					}
					this._Empresa.Entity = value;
					if ((value != null))
					{
						value.Produtos.Add(this);
						this._EmpresaId = value.EmpresaId;
					}
					else
					{
						this._EmpresaId = default(long);
					}
					this.SendPropertyChanged("Empresa");
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
		
		private void attach_BacklogItems(BacklogItem entity)
		{
			this.SendPropertyChanging();
			entity.Produto = this;
		}
		
		private void detach_BacklogItems(BacklogItem entity)
		{
			this.SendPropertyChanging();
			entity.Produto = null;
		}
	}
	
	[Table(Name="dbo.Colaboradores")]
	public partial class Colaborador : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ColaboradorId;
		
		private long _EmpresaId;
		
		private string _Nome;
		
		private EntityRef<Empresa> _Empresa;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnColaboradorIdChanging(long value);
    partial void OnColaboradorIdChanged();
    partial void OnEmpresaIdChanging(long value);
    partial void OnEmpresaIdChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    #endregion
		
		public Colaborador()
		{
			this._Empresa = default(EntityRef<Empresa>);
			OnCreated();
		}
		
		[Column(Storage="_ColaboradorId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ColaboradorId
		{
			get
			{
				return this._ColaboradorId;
			}
			set
			{
				if ((this._ColaboradorId != value))
				{
					this.OnColaboradorIdChanging(value);
					this.SendPropertyChanging();
					this._ColaboradorId = value;
					this.SendPropertyChanged("ColaboradorId");
					this.OnColaboradorIdChanged();
				}
			}
		}
		
		[Column(Storage="_EmpresaId", DbType="BigInt NOT NULL")]
		public long EmpresaId
		{
			get
			{
				return this._EmpresaId;
			}
			set
			{
				if ((this._EmpresaId != value))
				{
					if (this._Empresa.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmpresaIdChanging(value);
					this.SendPropertyChanging();
					this._EmpresaId = value;
					this.SendPropertyChanged("EmpresaId");
					this.OnEmpresaIdChanged();
				}
			}
		}
		
		[Column(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[Association(Name="Empresa_Colaborador", Storage="_Empresa", ThisKey="EmpresaId", OtherKey="EmpresaId", IsForeignKey=true)]
		public Empresa Empresa
		{
			get
			{
				return this._Empresa.Entity;
			}
			set
			{
				Empresa previousValue = this._Empresa.Entity;
				if (((previousValue != value) 
							|| (this._Empresa.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Empresa.Entity = null;
						previousValue.Colaboradors.Remove(this);
					}
					this._Empresa.Entity = value;
					if ((value != null))
					{
						value.Colaboradors.Add(this);
						this._EmpresaId = value.EmpresaId;
					}
					else
					{
						this._EmpresaId = default(long);
					}
					this.SendPropertyChanged("Empresa");
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
	
	[Table(Name="dbo.Sprint")]
	public partial class Sprint : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _SprintId;
		
		private long _EmpresaId;
		
		private string _Objetivo;
		
		private System.DateTime _Data;
		
		private EntitySet<SprintBackLog> _SprintBackLogs;
		
		private EntityRef<Empresa> _Empresa;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSprintIdChanging(long value);
    partial void OnSprintIdChanged();
    partial void OnEmpresaIdChanging(long value);
    partial void OnEmpresaIdChanged();
    partial void OnObjetivoChanging(string value);
    partial void OnObjetivoChanged();
    partial void OnDataChanging(System.DateTime value);
    partial void OnDataChanged();
    #endregion
		
		public Sprint()
		{
			this._SprintBackLogs = new EntitySet<SprintBackLog>(new Action<SprintBackLog>(this.attach_SprintBackLogs), new Action<SprintBackLog>(this.detach_SprintBackLogs));
			this._Empresa = default(EntityRef<Empresa>);
			OnCreated();
		}
		
		[Column(Storage="_SprintId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long SprintId
		{
			get
			{
				return this._SprintId;
			}
			set
			{
				if ((this._SprintId != value))
				{
					this.OnSprintIdChanging(value);
					this.SendPropertyChanging();
					this._SprintId = value;
					this.SendPropertyChanged("SprintId");
					this.OnSprintIdChanged();
				}
			}
		}
		
		[Column(Storage="_EmpresaId", DbType="BigInt NOT NULL")]
		public long EmpresaId
		{
			get
			{
				return this._EmpresaId;
			}
			set
			{
				if ((this._EmpresaId != value))
				{
					if (this._Empresa.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmpresaIdChanging(value);
					this.SendPropertyChanging();
					this._EmpresaId = value;
					this.SendPropertyChanged("EmpresaId");
					this.OnEmpresaIdChanged();
				}
			}
		}
		
		[Column(Storage="_Objetivo", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Objetivo
		{
			get
			{
				return this._Objetivo;
			}
			set
			{
				if ((this._Objetivo != value))
				{
					this.OnObjetivoChanging(value);
					this.SendPropertyChanging();
					this._Objetivo = value;
					this.SendPropertyChanged("Objetivo");
					this.OnObjetivoChanged();
				}
			}
		}
		
		[Column(Storage="_Data", DbType="SmallDateTime NOT NULL", IsDbGenerated=true)]
		public System.DateTime Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[Association(Name="Sprint_SprintBackLog", Storage="_SprintBackLogs", ThisKey="SprintId", OtherKey="SprintId")]
		public EntitySet<SprintBackLog> SprintBackLogs
		{
			get
			{
				return this._SprintBackLogs;
			}
			set
			{
				this._SprintBackLogs.Assign(value);
			}
		}
		
		[Association(Name="Empresa_Sprint", Storage="_Empresa", ThisKey="EmpresaId", OtherKey="EmpresaId", IsForeignKey=true)]
		public Empresa Empresa
		{
			get
			{
				return this._Empresa.Entity;
			}
			set
			{
				Empresa previousValue = this._Empresa.Entity;
				if (((previousValue != value) 
							|| (this._Empresa.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Empresa.Entity = null;
						previousValue.Sprints.Remove(this);
					}
					this._Empresa.Entity = value;
					if ((value != null))
					{
						value.Sprints.Add(this);
						this._EmpresaId = value.EmpresaId;
					}
					else
					{
						this._EmpresaId = default(long);
					}
					this.SendPropertyChanged("Empresa");
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
		
		private void attach_SprintBackLogs(SprintBackLog entity)
		{
			this.SendPropertyChanging();
			entity.Sprint = this;
		}
		
		private void detach_SprintBackLogs(SprintBackLog entity)
		{
			this.SendPropertyChanging();
			entity.Sprint = null;
		}
	}
	
	[Table(Name="dbo.vBackLogProdutos")]
	public partial class vBackLogProduto
	{
		
		private long _BacklogItemId;
		
		private long _ProdutoId;
		
		private string _Nome;
		
		private string _Nota;
		
		private System.DateTime _Data;
		
		private double _Estimativa;
		
		private long _EmpresaId;
		
		private string _NomeProduto;
		
		public vBackLogProduto()
		{
		}
		
		[Column(Storage="_BacklogItemId", DbType="BigInt NOT NULL")]
		public long BacklogItemId
		{
			get
			{
				return this._BacklogItemId;
			}
			set
			{
				if ((this._BacklogItemId != value))
				{
					this._BacklogItemId = value;
				}
			}
		}
		
		[Column(Storage="_ProdutoId", DbType="BigInt NOT NULL")]
		public long ProdutoId
		{
			get
			{
				return this._ProdutoId;
			}
			set
			{
				if ((this._ProdutoId != value))
				{
					this._ProdutoId = value;
				}
			}
		}
		
		[Column(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this._Nome = value;
				}
			}
		}
		
		[Column(Storage="_Nota", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Nota
		{
			get
			{
				return this._Nota;
			}
			set
			{
				if ((this._Nota != value))
				{
					this._Nota = value;
				}
			}
		}
		
		[Column(Storage="_Data", DbType="SmallDateTime NOT NULL")]
		public System.DateTime Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this._Data = value;
				}
			}
		}
		
		[Column(Storage="_Estimativa", DbType="Float NOT NULL")]
		public double Estimativa
		{
			get
			{
				return this._Estimativa;
			}
			set
			{
				if ((this._Estimativa != value))
				{
					this._Estimativa = value;
				}
			}
		}
		
		[Column(Storage="_EmpresaId", DbType="BigInt NOT NULL")]
		public long EmpresaId
		{
			get
			{
				return this._EmpresaId;
			}
			set
			{
				if ((this._EmpresaId != value))
				{
					this._EmpresaId = value;
				}
			}
		}
		
		[Column(Storage="_NomeProduto", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string NomeProduto
		{
			get
			{
				return this._NomeProduto;
			}
			set
			{
				if ((this._NomeProduto != value))
				{
					this._NomeProduto = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.vSprintBackLog")]
	public partial class vSprintBackLog
	{
		
		private long _SprintId;
		
		private long _BacklogItemId;
		
		private long _ProdutoId;
		
		private string _Nome;
		
		private string _Nota;
		
		private System.DateTime _Data;
		
		private double _Estimativa;
		
		private string _Objetivo;
		
		private string _NomeProduto;
		
		public vSprintBackLog()
		{
		}
		
		[Column(Storage="_SprintId", DbType="BigInt NOT NULL")]
		public long SprintId
		{
			get
			{
				return this._SprintId;
			}
			set
			{
				if ((this._SprintId != value))
				{
					this._SprintId = value;
				}
			}
		}
		
		[Column(Storage="_BacklogItemId", DbType="BigInt NOT NULL")]
		public long BacklogItemId
		{
			get
			{
				return this._BacklogItemId;
			}
			set
			{
				if ((this._BacklogItemId != value))
				{
					this._BacklogItemId = value;
				}
			}
		}
		
		[Column(Storage="_ProdutoId", DbType="BigInt NOT NULL")]
		public long ProdutoId
		{
			get
			{
				return this._ProdutoId;
			}
			set
			{
				if ((this._ProdutoId != value))
				{
					this._ProdutoId = value;
				}
			}
		}
		
		[Column(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this._Nome = value;
				}
			}
		}
		
		[Column(Storage="_Nota", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Nota
		{
			get
			{
				return this._Nota;
			}
			set
			{
				if ((this._Nota != value))
				{
					this._Nota = value;
				}
			}
		}
		
		[Column(Storage="_Data", DbType="SmallDateTime NOT NULL")]
		public System.DateTime Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this._Data = value;
				}
			}
		}
		
		[Column(Storage="_Estimativa", DbType="Float NOT NULL")]
		public double Estimativa
		{
			get
			{
				return this._Estimativa;
			}
			set
			{
				if ((this._Estimativa != value))
				{
					this._Estimativa = value;
				}
			}
		}
		
		[Column(Storage="_Objetivo", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Objetivo
		{
			get
			{
				return this._Objetivo;
			}
			set
			{
				if ((this._Objetivo != value))
				{
					this._Objetivo = value;
				}
			}
		}
		
		[Column(Storage="_NomeProduto", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string NomeProduto
		{
			get
			{
				return this._NomeProduto;
			}
			set
			{
				if ((this._NomeProduto != value))
				{
					this._NomeProduto = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
