using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public class OutsideTable : Table
    {
        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, 3.50m)
        {
        }

        public override string GetFreeTableInfo()
        {
            return string.Format(base.GetFreeTableInfo(), nameof(OutsideTable));
        }

        public override string GetOccupiedTableInfo()
        {
            return string.Format(base.GetOccupiedTableInfo(), nameof(OutsideTable));
        }
    }
}
