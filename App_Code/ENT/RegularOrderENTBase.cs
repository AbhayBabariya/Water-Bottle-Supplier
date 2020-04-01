using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RegularOrderENTBase
/// </summary>
namespace WaterBottleSupplier.ENT
{
    public abstract class RegularOrderENTBase
    {
        protected SqlInt32 _RegularOrderID;
        public SqlInt32 RegularOrderID
        {
            get
            {
                return _RegularOrderID;
            }
            set
            {
                _RegularOrderID = value;
            }
        }

        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        protected SqlInt32 _CustomerID;
        public SqlInt32 CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        protected SqlInt32 _BranchID;
        public SqlInt32 BranchID
        {
            get
            {
                return _BranchID;
            }
            set
            {
                _BranchID = value;
            }
        }

        protected SqlInt32 _DistributorID;
        public SqlInt32 DistributorID
        {
            get
            {
                return _DistributorID;
            }
            set
            {
                _DistributorID = value;
            }
        }

        protected SqlInt32 _ProductID;
        public SqlInt32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }

        protected SqlInt32 _Quantity;
        public SqlInt32 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }

        protected SqlDecimal _TotalAmount;
        public SqlDecimal TotalAmount
        {
            get
            {
                return _TotalAmount;
            }
            set
            {
                _TotalAmount = value;
            }
        }

        protected SqlInt32 _BottleIn;
        public SqlInt32 BottleIn
        {
            get
            {
                return _BottleIn;
            }
            set
            {
                _BottleIn = value;
            }
        }

        protected SqlDateTime _OrderDate;
        public SqlDateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
            }
        }
    }
}