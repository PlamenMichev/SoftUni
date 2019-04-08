using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public class InsideTable : Table
    {
        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, 2.50m)
        {
        }

        public override string GetFreeTableInfo()
        {
            return string.Format(base.GetFreeTableInfo(), nameof(InsideTable));
        }

        public override string GetOccupiedTableInfo()
        {
            return string.Format(base.GetOccupiedTableInfo(), nameof(InsideTable));
        }
    }
}
