using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FGCore.Dominio

{
    public class Time
    {
        public int Id { get; set; }
        [MinLength(3)]
        public String Nome { get; set; }
        
    }
}
