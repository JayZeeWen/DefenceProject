using System;
namespace EShop.Model
{
	/// <summary>
	/// T_Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Users
	{
		public T_Users()
		{}
		#region Model
		private long _userid;
		private string _account;
		private string _pwd;
		private string _pfp;
		private decimal? _assets;
		private int? _points;
		private string _dist;
		private string _name;
		private string _sex;
		private string _phone;
		private string _address;
		private int? _state;
		/// <summary>
		/// 
		/// </summary>
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Account
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PFP
		{
			set{ _pfp=value;}
			get{return _pfp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Assets
		{
			set{ _assets=value;}
			get{return _assets;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Points
		{
			set{ _points=value;}
			get{return _points;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Dist
		{
			set{ _dist=value;}
			get{return _dist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

