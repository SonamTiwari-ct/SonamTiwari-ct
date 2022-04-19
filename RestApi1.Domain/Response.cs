using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.Domain
{
    public class Response
    {
       [DefaultValue(0)]
       public  int status { get; set; }
        [DefaultValue("Something went Wrong")]
        public string msg { get; set; }
        public int UserId { get; set; }
    }
}
