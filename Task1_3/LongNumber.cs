using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1_3
{
    class LongNumber
    {
        public string value;

        public LongNumber(LongNumber other)
        {
            value = new string(other.value);
        }

        public LongNumber(string sequence)
        {
            value = new string(sequence);
        }

        public static bool operator >(LongNumber a, LongNumber b)
        {
            if (a.value.Length > b.value.Length) return true;
            else if (a.value.Length < b.value.Length) return false;

            for (int i = 0; i < a.value.Length; i++) 
            {
                if ((int)(a.value[i] - '0') > (int)(b.value[i] - '0')) return true;
                else if ((int)(a.value[i] - '0') < (int)(b.value[i] - '0')) return false;
            }

            return false;
        }

        public static bool operator <(LongNumber a, LongNumber b)
        {
            return !(a > b);
        }

        public static LongNumber operator +(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("");

            LongNumber a1, b1;

            if (a.value.Length > b.value.Length)
            { a1 = a; b1 = b; }
            else { a1 = b; b1 = a; }

            a1 = new LongNumber(a1);
            b1 = new LongNumber(b1);

            b1.value = new string('0', a1.value.Length - b1.value.Length) + b1.value;

            int mem = 0;

            for (int i = b1.value.Length - 1; i >= 0; i--)
            {
                int sub_result = (int)(a1.value[i] - '0') + (int)(b1.value[i] - '0') + mem;

                if (sub_result >= 10)
                { mem = 1; sub_result %= 10; } else mem = 0;

                result.value = (sub_result).ToString() + result.value;
            }

            if (mem == 1) result.value = (1).ToString() + result.value;

            return result;
        }

        public static LongNumber operator *(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("0");

            return result;
        }

        public static LongNumber operator -(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("");

            LongNumber a1, b1;

            if (a.value.Length > b.value.Length)
            { a1 = a; b1 = b; }
            else if (a > b)
            { a1 = a; b1 = b; }
            else 
            { a1 = b; b1 = a; }

            a1 = new LongNumber(a1);
            b1 = new LongNumber(b1);

            int stop_at = a1.value.Length - b1.value.Length;

            b1.value = new string('0', a1.value.Length - b1.value.Length) + b1.value;

            // b1 меньше

            for (int i = a1.value.Length - 1; i >= stop_at; i--)
            {
                int sub_result = (int)(a1.value[i] - '0') - (int)(b1.value[i] - '0');

                if (sub_result < 0)
                {
                    for (int j = i; j >= 0; j--)
                    {

                        int buff = (int)(a1.value[j] - '0');

                        if (buff == 0)
                        {
                            StringBuilder sb = new StringBuilder(a1.value);
                            sb[j] = '9';
                            a1.value = sb.ToString();
                        }
                        else
                        {
                            buff -= 1;
                            StringBuilder sb = new StringBuilder(a1.value);
                            sb[j] = Convert.ToChar(buff.ToString());
                            a1.value = sb.ToString();
                            sub_result += 10;
                            break;
                   
                        }
                    }
                }
                
                result.value = (sub_result).ToString() + result.value;
            }

            return result;
        }
    }
}
