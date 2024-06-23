using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
    internal interface IAvaliacaoService
    {
        IEnumerable<Avaliacao> GetAll();
        Avaliacao GetById(int id);
        Avaliacao Create(Avaliacao avaliacao);
    }
}
