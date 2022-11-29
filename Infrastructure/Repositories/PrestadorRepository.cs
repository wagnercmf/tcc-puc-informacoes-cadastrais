﻿
using Domain.Entities;
using Domain.Services.Interfaces;
using Infrastructure.Mocks;

namespace Infrastructure.Repositories
{
    public class PrestadorRepository : IPrestadorRepository
    {
        private readonly PrestadorMock prestadoresMock = new PrestadorMock();

        public async Task<List<Prestador>> GetPrestadorPorEspecialidade(string especialidade)
        {
            var prestadores = prestadoresMock.GerarPrestadoresMock();
            return prestadores.Where(x => x.Especialidade == especialidade).ToList();
        }
    }
}