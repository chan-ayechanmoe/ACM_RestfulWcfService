using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ACM_RestfulWcfService
{
    
    [DataContract]
    public class customer
    {
        string CustCode = "";
        string CustName = "";
        string Phone = "";
        string Address = "";
        string Email = "";
        string Currency = "";
        string GroupCode = "";


        [DataMember]
        public string custcode
        { get { return CustCode; } set { CustCode = value; } }

        [DataMember]
        public string custname
        { get { return CustName; } set { CustName = value; } }

        [DataMember]
        public string phone
        { get { return Phone; } set { Phone = value; } }

        [DataMember]
        public string address
        { get { return Address; } set { Address = value; } }

        [DataMember]
        public string email
        { get { return Email; } set { Email = value; } }

        [DataMember]
        public string currency
        { get { return Currency; } set { Currency = value; } }

        [DataMember]
        public string groupcode
        { get { return GroupCode; } set { GroupCode = value; } }



    }
}