using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices
{
    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3
    }

    class EnumsTest
    {
        public void enumTester()
        {
            ShippingMethod method = ShippingMethod.Express;
            Console.WriteLine((int)method);

            var methodId = 3;
            Console.WriteLine("\n" + (ShippingMethod)methodId);

            Console.WriteLine("\n" + method.ToString());

            string methodName = "Express";
            ShippingMethod shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);
            Console.WriteLine("\n" + shippingMethod);
        }
    }
}
