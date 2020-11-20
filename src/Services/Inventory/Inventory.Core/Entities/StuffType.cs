using System.Collections.Generic;

namespace Inventory.Core.Entities
{
    public class StuffType : BaseEntity
    {
        public string Name { get; set; } = default!;
        
        public string? Description { get; set; }

        /// <summary>
        /// Private modifier protects collection from external changes directly to it
        /// </summary>
        private readonly List<Stuff> _stuff = new List<Stuff>();

        /// <summary>
        /// Read only wrapper protects against external changes/updates
        /// AsReadOnly doesn't copy items to a new collection, so its better than ToList()
        /// </summary>
        public IReadOnlyCollection<Stuff> Stuff => _stuff.AsReadOnly();
    }
}
