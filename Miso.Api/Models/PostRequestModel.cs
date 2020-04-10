using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miso.Api.Models
{
    public class PostRequestModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Coordinates Location { get; set; }
    }
}
