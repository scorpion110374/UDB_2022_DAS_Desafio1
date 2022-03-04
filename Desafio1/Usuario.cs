using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    public class Usuario
    {
        public string User { get; set; }
        public string Clave { get; set; }
        public string Categoria { get; set; }
        public Usuario() { }
        public Usuario(string usuario, string clave, string categoria)
        {
            User = usuario;
            Clave = clave;
            Categoria = categoria;
        }

        public bool validarUsuario(string usuario, string clave) {

            if (usuario == null || clave == null)
            {
                return false;
            }

            if (this.User == usuario && this.Clave == clave)
            {
                return true;
            }

            return false;
        }
    }
}
