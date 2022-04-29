﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Genericos
{
    public interface IGenericos<T> where T : class
    {
        public Task Adicionar(T Objeto);

        public Task<T> BuscarPorId(Guid Id);

        public Task<List<T>> ListarTodos();
    }
}
