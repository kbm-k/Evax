using System;
using Action = Inventory.Core.Entities.Enums.Action;

namespace Inventory.Core.Entities
{
    public class History : BaseEntity
    {
        public int StuffId { get; init; }
        public Action Action { get; init; }
        public DateTime Date { get; init; }
        public int Count { get; init; }
        public string? Reason { get; init; }

        // It is enough to have a single navigation property without inverse navigation
        // and foreign key property to have a relationship defined by convention.
        // It is also possible to have single navigation property and a foreign key property.
        //public Stuff Stuff { get; set; }
    }
}
