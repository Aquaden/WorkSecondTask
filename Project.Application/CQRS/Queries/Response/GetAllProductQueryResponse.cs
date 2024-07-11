using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.CQRS.Queries.Response
{
    public class GetAllProductQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Updated_date { get; set; }
        public DateTime Deleted_date { get; set; }
        public bool IsDeleted { get; set; }

    }
}
