using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL_YY
{
    public class TBL_GeneratedID
    {
        DataClasses1DataContext id = new DataClasses1DataContext();
        public String registergeneratedid()
        {
            String studid = Convert.ToString(id.registerGeneratedID(_StudID, _department, _StudentImg));
            return studid;
        }
    }
}