using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exigeances.Models;
using Taches.Models;
using Projets.Models;

namespace Resps.Models
{
public class Resp {

   
    public int RespID {get;set;}

    public string nom {get;set;}
    
    public virtual ICollection<Projet> Projet { get; set; }

    public virtual ICollection<Tache> Tache { get; set; }

}


}

