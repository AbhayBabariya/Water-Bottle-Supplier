using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DistributorENTBase
/// </summary>
namespace WaterBottleSuppplier.ENT
{
    public abstract class DistributorENTBase
    {
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

        protected SqlString _DistributorName;
        public SqlString DistributorName
        {
            get
            {
                return _DistributorName;
            }
            set
            {
                _DistributorName = value;
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

        protected SqlString _VehicleType;
        public SqlString VehicleType
        {
            get
            {
                return _VehicleType;
            }
            set
            {
                _VehicleType = value;
            }
        }

        protected SqlString _VehicleNo;
        public SqlString VehicleNo
        {
            get
            {
                return _VehicleNo;
            }
            set
            {
                _VehicleNo = value;
            }
        }
    }
}