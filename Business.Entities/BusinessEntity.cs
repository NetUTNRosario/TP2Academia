using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            this.State = States.New;
        }



        private int _ID;
        public int ID { set { _ID = value; } get { return _ID; } }


        private States _State; 
        public States State { set { _State = value; } get { return _State; } }



        public enum States
        {
            Deleted, New, Modified, Unmodified
        }
    }
}
