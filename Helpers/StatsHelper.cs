using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BROWSit.Helpers
{
    public class StatsHelper
    {
        public enum Direction
        {
            Up,
            Down
        }

        public class HelperStatistics
        {
            public int rowCount;
            public string entityType;

            public HelperStatistics()
            {
                rowCount = 0;
                entityType = "";
            }
        }
    }
}
