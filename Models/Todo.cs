using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTeste.Models
{
    public class Todo : BaseModel
    {
        //public Todo()
        //{
        //    // Id = new Guid();
        //    CreatedOn = DateTime.Now;
        //    IsCompleted = false;

        //}

       // public Guid Id { get; private set; }
        public DateTime CreatedOn { get;  set; }
        public string Title { get;  set; }
        public string Body { get;  set; }
        public bool IsCompleted { get;  set; }

    }
}
