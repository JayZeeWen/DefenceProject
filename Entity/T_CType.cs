using System;
namespace EShop.Model
{
	/// <summary>
	/// T_CType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_CType
	{
		public T_CType()
		{}
		#region Model
		private long _ctid;
		private long? _tid;
		private string _ctname;
		/// <summary>
		/// 
		/// </summary>
		public long CTID
		{
			set{ _ctid=value;}
			get{return _ctid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CTName
		{
			set{ _ctname=value;}
			get{return _ctname;}
		}
		#endregion Model

	}
}

