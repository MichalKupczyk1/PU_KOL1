using BLL;
using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class HistoriaInterface : IHistoriaInterface
    {
        private readonly UczelniaContext _context;
        public HistoriaInterface(UczelniaContext context)
        {
            this._context = context;
        }
        public List<HistoriaDTO>? PobierzHistorieZeStronnicowaniem(int strona, int iloscNaStrone)
        {
            return _context.Historia?.Skip(strona * iloscNaStrone)
                .Take(iloscNaStrone)
                .Select(x => new HistoriaDTO(x))
                .ToList();
        }
    }
}
