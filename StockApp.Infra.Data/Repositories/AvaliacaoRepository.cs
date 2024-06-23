using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Data.Repositories
{
    internal class AvaliacaoRepository
    {
        private readonly List<Avaliacao> _avaliacoes;

        public AvaliacaoRepository()
        {
            _avaliacoes = new List<Avaliacao>();
        }

        public IEnumerable<Avaliacao> GetAll()
        {
            return _avaliacoes;
        }

        public Avaliacao GetById(int id)
        {
            return _avaliacoes.FirstOrDefault(a => a.Id == id);
        }

        public Avaliacao Create(Avaliacao avaliacao)
        {
            avaliacao.Id = _avaliacoes.Any() ? _avaliacoes.Max(a => a.Id) + 1 : 1;
            _avaliacoes.Add(avaliacao);
            return avaliacao;
        }
    }
}
