using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {

        public enum States { Deleted, New, Modified, Unmodified }
        int _ID;
        States _State;

        public BusinessEntity()
        {
            
        }

        public int ID 
            {
            get { return (_ID); }
            set { _ID = value; }
            }

        public States State
        {
            get { return (_State); }
            set { _State = value; }
        }

        

    }
}
