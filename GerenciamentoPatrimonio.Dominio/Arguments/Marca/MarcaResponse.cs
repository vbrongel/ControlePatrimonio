﻿using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Marca
{
    public class MarcaResponse : ArgumentsBase
    {
        public Guid MarcaId { get;  set; }
        public string Nome { get;  set; }
    }
}
