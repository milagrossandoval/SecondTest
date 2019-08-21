using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Test.page.entidades
{
    public class GenerateRandom
    {
        private readonly Random r = new Random();

        public int RandomNumber(int min, int max) {
            return r.Next(min, max);
        }

        public String RandomString(int size, bool lowerCase) {
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

        public String RandomEmail()
        {
            int n = r.Next(100);
            return "msandoval" + n + "@gmail.com";
        }

        public String RandomPhone(int digits) {
            string s = string.Empty;
            for (int i = 0; i < digits - 1; i++)
            {
                s = String.Concat(s,r.Next(10).ToString());
            }
            return s;
        }

        public String RandomPassword() {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4,true));
            builder.Append(RandomNumber(100, 999));
            builder.Append(RandomString(2,false));
            return builder.ToString();
        }

        public String RandomName() {
            var names = new List<string> { "Luisa", "Fernanda", "Juana", "Martha", "Josefa" };
            int index = r.Next(names.Count);

            return names[index];
        }


        public String RandomState() {
            var states =  new List<string>{ "Arizona", "Connecticut", "California", "Georgia", "Idaho" };
            int index = r.Next(states.Count);

            return states[index];
        }
    }
}
