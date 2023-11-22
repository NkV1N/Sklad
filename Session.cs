using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse
{
    public class Session
    {
        private Session()
        {
            context = new  WarehousebdContext();
        }

        private static Session? instance;
        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }
        private WarehousebdContext context;
        public WarehousebdContext Context => context;
    }
}
