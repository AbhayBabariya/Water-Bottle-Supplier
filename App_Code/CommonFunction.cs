using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonFunction
/// </summary>
namespace WaterBottleSupplier
{
    public class CommonFunction
    {
        #region Status IsComplete
        public static string GetStatusLabel(bool Status)
        {
            string Check = string.Empty;

            if (Convert.ToBoolean(Status))
                Check = "kt-badge  kt-badge--success kt-badge--inline kt-badge--pill";
            else
                Check = "kt-badge  kt-badge--danger kt-badge--inline kt-badge--pill";

            return Check;
        }

        public static string GetStatusLabelCompletePanding(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Complete";
            }
            else
            {
                txt = "Panding";
            }

            return txt;
        }
        #endregion StatusComplete
    }
}