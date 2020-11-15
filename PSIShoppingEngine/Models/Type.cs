using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Models
{
    public enum Type 
    {
        [Display(Name = "Mesos gaminiai")]
        Mesos_gaminiai = 1,
        [Display(Name = "Juros gerybes")]
        Juros_gerybes = 2,
        Kepiniai = 3,
        Darzoves = 4,
        Vaisiai = 5,
        [Display(Name = "Pieno produktai")]
        Pieno_produktai = 6,
        Gerimai = 7,
        Saldumynai = 8,
        Uzkandziai = 9
    }
   
}
