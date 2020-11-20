using System;
using Action = Inventory.Core.Entities.Enums.Action;

namespace Inventory.Core.Entities
{
    public class History : BaseEntity
    {
        public int StuffId { get; set; }
        public Action Action { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public string? Reason { get; set; }

        // It is enough to have a single navigation property without inverse navigation
        // and foreign key property to have a relationship defined by convention.
        // It is also possible to have single navigation property and a foreign key property.
        //public Stuff Stuff { get; set; }
    }
}
