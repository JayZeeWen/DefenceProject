using System;
namespace EShop.Model
{
	/// <summary>
	/// T_Orders:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Orders
	{
		public T_Orders()
		{}
		#region Model
		private long _orderid;
		private long? _userid;
		private DateTime? _orderdate;
		/// <summary>
		/// 
		/// </summary>
		public long OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OrderDate
		{
			set{ _orderdate=value;}
			get{return _orderdate;}
		}
		#endregion Model

	}
}

