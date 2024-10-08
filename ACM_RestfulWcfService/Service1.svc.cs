using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace ACM_RestfulWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static CommonFunction func = new CommonFunction();
        public string CreateCustomer(customer apram)
        {
            try
            {
                
                string CustCode = apram.custcode;
                string CustName = apram.custname ;
                string Phone = apram.phone;
                string Address = apram.address;
                string Email = apram.email;
                string Currency = apram.currency;
                string GroupCode = apram.groupcode;

        
                string ErrMsg = null;

                string query;
                query = "INSERT INTO dbo.Customer(CusCode,CusName,GroupCode,Email,Address1,Phone1,Currency) VALUES ('"+CustCode.Trim()+"', '"+CustName.Trim()+"', '"+GroupCode.Trim()+"', '"+Email.Trim()+"', '"+Address.Trim()+"', '"+Phone.Trim()+"', '"+Currency.Trim()+"')";
                ErrMsg=func.RunQuery_NoResult(query);
                if (ErrMsg!="")
                {
                    return "Fail to create customer!"+ErrMsg;
                }
                else
                {
                    return "Customer created successful!";

                }

            }
            catch (Exception ex)
            {
                if (ex.Message.ToString() == "-000256")
                {
                    //WriteServiceLog(" ODBC- connection to failed", "Y", "CreateCustomer");
                }
                else
                {
                    //WriteServiceLog(apram.custcode + ":" + ex.Message.ToString(), "Y", "CreateCustomer");
                }
                return "Error : " + ex.Message.ToString();
            }
        }
    }
}
