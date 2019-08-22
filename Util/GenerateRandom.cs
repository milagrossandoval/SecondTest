using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Test.Util
{
    public class GenerateRandom
    {
        private readonly static Random r = new Random();
        public static List<string> Domains { get; set; }
        public static List<string> Extensions { get; set; }
        public static List<string> Names { get; set; }
        public static List<string> States { get; set; }
        public static List<string> LastNames { get; set; }


        public GenerateRandom() {
            Domains = new List<string> { "hotmail", "gmail", "outlook", "yahoo", "live" };
            Extensions = new List<string> { "com", "com.pe", "pe" };
            Names = new List<string> { "Luisa", "Fernanda", "Juana", "Martha", "Josefa", "Zoila" };
            States = new List<string> { "Arizona", "Connecticut", "California", "Georgia", "Idaho" };
            LastNames = new List<string> { "Rodriguez", "Sandoval", "Cáceda", "Torres", "Grey" };

        }

        public static string GetRandomFromList(List<String> lista) {
            int len = r.Next(lista.Count-1);
            return lista[len];
        }


        public static int RandomNumber(int min, int max)
        {
            return r.Next(min, max);
        }

        public static string RandomString(int size, bool lowerCase) {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++) {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*r.NextDouble()+65)));
                builder.Append(ch);
            }

            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }

        public static string RandomEmail()
        {
            int n = RandomNumber(0, 9);
            string text = RandomString(8, false);
            string domain = GetRandomFromList(Domains);
            string ext = GetRandomFromList(Extensions);
            return text + n + "@" + domain + "." + ext; 
                
        }

        public static string RandomPhone(int digits) {
            string s = string.Empty;
            for (int i = 0; i < digits - 1; i++)
            {
                s = string.Concat(s,r.Next(10).ToString());
            }
            return s;
        }

        public static string RandomPassword() {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4,true));
            builder.Append(RandomNumber(100, 999));
            builder.Append(RandomString(2,false));
            return builder.ToString();
        }

        public static string RandomName() {
            return GetRandomFromList(Names);
        }

        public static string RandomLastName()
        {
            return GetRandomFromList(LastNames);
        }

        public static string RandomState() {
            return GetRandomFromList(States);
        }
    }
}
