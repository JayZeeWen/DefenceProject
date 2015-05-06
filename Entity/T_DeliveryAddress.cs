using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EShop.Model{
	 	//T_DeliveryAddress
		public class T_DeliveryAddress
	{
   		     
      	/// <summary>
		/// id
        /// </summary>		
		private long _id;
        public long id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// UserID
        /// </summary>		
		private long _userid;
        public long UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// Name
        /// </summary>		
		private string _name;
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		/// <summary>
		/// Phone
        /// </summary>		
		private string _phone;
        public string Phone
        {
            get{ return _phone; }
            set{ _phone = value; }
        }        
		/// <summary>
		/// PostCode
        /// </summary>		
		private int _postcode;
        public int PostCode
        {
            get{ return _postcode; }
            set{ _postcode = value; }
        }        
		/// <summary>
		/// Address
        /// </summary>		
		private string _address;
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
        }        
		   
	}
}

