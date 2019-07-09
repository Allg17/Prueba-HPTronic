using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades_Albert
{
    public static class Extensores
    {
        public static int Toint(this object str)
        {

            return Convert.ToInt32(str);
        }

        public static DateTime Todatetime(this object str)
        {

            return Convert.ToDateTime(str);
        }

        public static string ToSql(this string str)
        {
            return str.Replace("'","");
        }

        public static string ToSqlComillasLike(this string str)
        {
            return "'%" + str.Replace("'", "") + "%'";
        }

        public static string ToSqlDate(this DateTime str)
        {
            return "'" + str.Date.Year + "-" + str.Date.Month + "-" + str.Date.Day + "'";
        }

        public static decimal Todecimal(this object str)
        {

            return Convert.ToDecimal(str);
        }

    }
}
