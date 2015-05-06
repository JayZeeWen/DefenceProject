using System;
namespace EShop.Model
{
	/// <summary>
	/// T_Products:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Products
	{
		public T_Products()
		{}
		#region Model
		private long _proid;
		private long? _ctid;
		private long? _braid;
		private string _proname;
		private decimal? _price;
		private int? _salepoint;
		private string _Des;
		private int? _stock;
		private string _img;
		private DateTime? _shelvedate;
		/// <summary>
		/// 
		/// </summary>
		public long ProID
		{
			set{ _proid=value;}
			get{return _proid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? CTID
		{
			set{ _ctid=value;}
			get{return _ctid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? BraID
		{
			set{ _braid=value;}
			get{return _braid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProName
		{
			set{ _proname=value;}
			get{return _proname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SalePoint
		{
			set{ _salepoint=value;}
			get{return _salepoint;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Des
		{
			set{ _Des=value;}
			get{return _Des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Img
		{
			set{ _img=value;}
			get{return _img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ShelveDate
		{
			set{ _shelvedate=value;}
			get{return _shelvedate;}
		}
		#endregion Model

	}
}

