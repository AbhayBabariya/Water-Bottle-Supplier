using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerENTBase
/// </summary>
namespace WaterBottleSupplier.ENT
{
    public abstract class CustomerENTBase
    {
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

        protected SqlString _CustomerName;
        public SqlString CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }

        protected SqlString _MobileNo;
        public SqlString MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }
        }

        protected SqlString _Address;
        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
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

        protected SqlDecimal _BottlePrice;
        public SqlDecimal BottlePrice
        {
            get
            {
                return _BottlePrice;
            }
            set
            {
                _BottlePrice = value;
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
    }
}