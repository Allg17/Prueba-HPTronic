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

        public static float Tofloat(this object str)
        {

            return Convert.ToSingle(str);
        }

        public static double Todouble(this object str)
        {

            return Convert.ToDouble(str);
        }

        public static DateTime Todatetime(this object str)
        {

            return Convert.ToDateTime(str);
        }

        public static bool Tobool(this object str)
        {

            return Convert.ToBoolean(str);
        }

        public static bool IsNotNull(this object str)
        {

            return str != null;
        }

        public static string ToSql(this string str)
        {
            return str.Replace("'","");
        }

        public static string ToSqlComillas(this string str)
        {
            return "'"+str.Replace("'", "")+"'";
        }

        public static string ToSqlComillasLike(this string str)
        {
            return "'%" + str.Replace("'", "") + "%'";
        }

        public static string ToSqlDate(this DateTime str)
        {
            return "'" + str.Date.Year + "-" + str.Date.Month + "-" + str.Date.Day + "'";
        }

        public static string Clear(this string str)
        {
            
            return str = "" ;
        }

        public static decimal Todecimal(this object str)
        {

            return Convert.ToDecimal(str);
        }


    }
}
