using System;
namespace EShop.Model
{
	/// <summary>
	/// T_Type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Type
	{
		public T_Type()
		{}
		#region Model
		private long _tid;
		private string _tname;
		/// <summary>
		/// 
		/// </summary>
		public long TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		#endregion Model

	}
}

