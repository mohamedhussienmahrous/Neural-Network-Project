using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Project
{
    class SVM_handler
    {
        public SVM_handler()
        {
            Support_Vector_Machine S_V_M = new Support_Vector_Machine(new ReadImages());
        }

    }
}
