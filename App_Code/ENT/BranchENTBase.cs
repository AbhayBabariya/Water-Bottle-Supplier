using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BranchENTBase
/// </summary>
namespace WaterBottleSupplier.ENT
{
    public abstract class BranchENTBase
    {
        protected SqlInt32 _BranhID;
        public SqlInt32 BranchID
        { 
            get
            {
                return _BranhID;
            }
            set
            {
                _BranhID = value;
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

        protected SqlString _BranchName;
        public SqlString BranchName
        {
            get
            {
                return _BranchName;
            }
            set
            {
                _BranchName = value;
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

        protected SqlString _ManagerName;
        public SqlString ManagerName
        {
            get
            {
                return _ManagerName;
            }
            set
            {
                _ManagerName = value;
            }
        }

        protected SqlString _ManagerMobileNo;
        public SqlString ManagerMobileNo
        {
            get
            {
                return _ManagerMobileNo;
            }
            set
            {
                _ManagerMobileNo = value;
            }
        }
    }
}