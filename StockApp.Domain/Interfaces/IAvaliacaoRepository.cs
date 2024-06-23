using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Interfaces
{
    public interface IAvaliacaoRepository
    {
        IEnumerable<Avaliacao> GetAll();
        Avaliacao GetById(int id);
        Avaliacao Create(Avaliacao avaliacao);
    }
}
