
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exigeances.Models;
using Taches.Models;
namespace Exigeance_Taches.Models
{

public class Exigeance_Tache {

   
    public int Exigeance_TacheID {get;set;}
    
    public int ExigeanceID {get;set;}

    public virtual Exigeance Exigeance {get;set;}

    public int TacheID { get;set;}

     public virtual Tache Tache {get;set;}
}



}

