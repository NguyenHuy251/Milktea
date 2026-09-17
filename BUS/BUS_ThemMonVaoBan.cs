using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_ThemMonVaoBan
    {
        DAL_ThemMonVaoBan dal_ThemMonVaoBan = new DAL_ThemMonVaoBan();
        public bool ThemMonVaoBan(DTO_ThemMonVaoBan mon)
        {
            return dal_ThemMonVaoBan.ThemMonVaoBan(mon);
        }
    }
}
