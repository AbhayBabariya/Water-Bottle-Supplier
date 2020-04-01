using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RegularOrderENT
/// </summary>
namespace WaterBottleSupplier.ENT
{
    public class RegularOrderENT : RegularOrderENTBase
    {
        public RegularOrderENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        protected SqlDateTime _FromDate;
        public SqlDateTime FromDate
        {
            get
            {
                return _FromDate;
            }
            set
            {
                _FromDate = value;
            }
        }
        protected SqlDateTime _ToDate;
        public SqlDateTime ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                _ToDate = value;
            }
        }
    }
}