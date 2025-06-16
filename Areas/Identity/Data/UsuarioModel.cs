using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace Arrecadar3.Areas.Identity.Data
{
    public class UsuarioModel:IdentityUser
    {
        [RegularExpression(@"^[a-zA-ZÀ-ú\s'-]+$")]
        public string Nome { get; set; }

    }
}
