using System;
using System.Collections.Generic;

namespace Inventory.Core.Entities
{
    public class Stuff : BaseEntity
    {
        /// <summary>
        /// It isn't required to have foreign key property defined,
        /// shadow foreign key property will be introduced.
        /// StuffTypeId is defined since we need to configure composite primary key.
        /// </summary>
        public int StuffTypeId { get; init; }
        public string Brand { get; init; } = default!;
        public int Count { get; init; }
        public DateTime PurchaseDate { get; init; }
        public decimal Price { get; init; }
        public string? Description { get; init; }

        /// <summary>
        /// Private modifier protects collection from external changes directly to it
        /// </summary>
        private readonly List<History> _histories = new();

        /// <summary>
        /// Read only wrapper protects against external changes/updates
        /// AsReadOnly doesn't copy items to a new collection, so its better than ToList()
        /// </summary>
        public IReadOnlyCollection<History> Histories => _histories.AsReadOnly();


        // It is enough to have a single navigation property without inverse navigation
        // and foreign key property to have a relationship defined by convention.
        // It is also possible to have single navigation property and a foreign key property.
        //public StuffType StuffType { get; set; }
    }
}
