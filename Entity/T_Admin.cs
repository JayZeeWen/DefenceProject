using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace EShop.Model
{
    //t_Admin
    public class t_Admin
    {

        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// account
        /// </summary>		
        private string _account;
        public string account
        {
            get { return _account; }
            set { _account = value; }
        }
        /// <summary>
        /// pwd
        /// </summary>		
        private string _pwd;
        public string pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
    }
		   
}
