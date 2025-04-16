using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace NasaPlaywrightUI.AutoData
{
    public static class TestData
    {
        public const string firstName = "Hasan";
        public const string lastName = "Testing";
        public const string email = "thisisnotreal@gmail.com";
    }
}
// I could have used this and then declared it in the test class but decided this looked smarter to me, more out of the way .
//
//    public class User
//    {
//    String firstName {  get; set; }
//    String lastName { get; set; }
//    string email { get; set; }
//    }


