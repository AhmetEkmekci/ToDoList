using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public abstract class BaseTable
    {
        public int Id { get; set; }

        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime LastActivityUserId { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public BaseTable()
        {
            Active = true;
            CreatedOnUtc = DateTime.UtcNow;
        }
    }
}
