﻿namespace Web.API.Models.Inventory
{
    public class StuffTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}