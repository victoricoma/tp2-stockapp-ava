using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Interfaces
{
    public interface IPromotionRepository
    {
        void Add(Promotion promotion);
        Promotion Get(int id);
        IEnumerable<Promotion> GetAll();
        void Delete(int id);
        void Update(Promotion promotion);
    }
}
