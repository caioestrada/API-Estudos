using CopaFilmes.Domain.Interfaces.CacheServices;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Infra.Cache.CacheServices
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        protected static readonly ConcurrentDictionary<string, bool> _listaDeChaves = new ConcurrentDictionary<string, bool>();

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<string> ObterTodos() => _listaDeChaves.Keys.ToList();

        public bool ObterPelaChave(string chave, out object valor)
        {
            if (_memoryCache.TryGetValue(chave.ToUpper(), out valor))
                return true;

            return false;
        }

        public bool Adicionar(string chave, object valor)
        {
            if (valor == null)
                return false;

            _listaDeChaves.TryAdd(chave.ToUpper(), true);
            _memoryCache.Set(chave.ToUpper(), valor, new MemoryCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddHours(3) });

            return true;
        }

        public void Remover(string chave)
        {
            if (!_listaDeChaves.TryRemove(chave.ToUpper(), out _))
                _listaDeChaves.TryUpdate(chave.ToUpper(), false, true);

            _memoryCache.Remove(chave.ToUpper());
        }
    }
}
