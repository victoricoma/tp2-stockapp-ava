using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public IEnumerable<Avaliacao> GetAll()
        {
            return _avaliacaoRepository.GetAll();
        }

        public Avaliacao GetById(int id)
        {
            return _avaliacaoRepository.GetById(id);
        }

        public Avaliacao Create(Avaliacao avaliacao)
        {
            _avaliacaoRepository.Create(avaliacao);
            return avaliacao;
        }
    }
}
