using GuardID.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuardID.Model
{
    public class Cadastro:IKeyObject
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Tel { get; set; }
        public string Key { get => Id.ToString(); set => Id.ToString(); }
    }
}
