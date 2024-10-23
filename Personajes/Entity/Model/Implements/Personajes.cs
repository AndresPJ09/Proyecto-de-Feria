
using System;

namespace Entity.Model.Implements
{
    public class Personajes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clase { get; set; }
        public int Nivel { get; set; }
        public string Habilidades { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
