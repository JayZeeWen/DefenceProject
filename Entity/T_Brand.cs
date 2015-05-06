using System;
namespace EShop.Model
{
	/// <summary>
	/// T_Brand:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Brand
	{
		public T_Brand()
		{}
		#region Model
		private long _braid;
		private string _braname;
		private string _bralogo;
		/// <summary>
		/// 
		/// </summary>
		public long BraID
		{
			set{ _braid=value;}
			get{return _braid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BraName
		{
			set{ _braname=value;}
			get{return _braname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BraLogo
		{
			set{ _bralogo=value;}
			get{return _bralogo;}
		}
		#endregion Model

	}
}

