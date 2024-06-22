using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace StockApp.Application.Interfaces
{
    public class MeuServico
    {
        private readonly IDistributedCache _cache;

        public MeuServico(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> ObterOuConfigurarCache()
        {
            var chave = "MinhaChave";
            var valorCache = await _cache.GetStringAsync(chave);

            if (valorCache == null)
            {
                valorCache = "Valor do cache inicial";
                var opcoesCache = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Expira em 10 minutos
                };

                await _cache.SetStringAsync(chave, valorCache, opcoesCache);
            }

            return valorCache;
        }
    }
}
