using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class CV
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ocupacion { get; set; }
        public string Contacto { get; set; }
        public string Correo { get; set; }
        public string Idiomas { get; set; }
        public string Aptitudes { get; set; }
        public string Habilidades { get; set; }
        public string Experiencia { get; set; }
        //public string Formacion { get; set; }

    }
}
