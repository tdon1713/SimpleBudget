using Realms;
using System;

namespace SimpleBudget.Models
{
    public class Budget : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string Description { get; set; }
    }
}