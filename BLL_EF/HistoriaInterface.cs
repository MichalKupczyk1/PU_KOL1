using BLL;
using BLL.DTO;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<HistoriaDTO>? PobierzHistorieZeStronnicowaniemProcedura(int strona, int iloscNaStrone)
        {
            var paramStrona = new SqlParameter("@strona", strona);
            var paramIloscNaStrone = new SqlParameter("@iloscnastrone", iloscNaStrone);

            var historia = _context.Historia?
                .FromSqlRaw("EXEC [PobierzHistorieZeStronnicowaniem] @strona, @iloscnastrone", paramStrona, paramIloscNaStrone)
                .ToList();

            return historia?.Select(x => new HistoriaDTO(x)).ToList();
        }
    }
}
