using System.Runtime.InteropServices;
using System.Text;

namespace Task1_3
{
    class LongNumber
    {
        private bool _last_set_was_sucessful;
        private string _value;
        public string value { get { return _value; } 
            set {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!("1234567890".Contains(value[i])))
                    {
                        _value = "0";
                        _last_set_was_sucessful = false;
                        return;
                    }
   
                }

                value = value.TrimStart('0');
                _last_set_was_sucessful = true;
                _value = value;
            } 
        }

        public LongNumber(LongNumber other)
        {
            _value = new string(other._value);
        }

        public LongNumber(string sequence)
        {
            value = new string(sequence);
        }

        public static bool operator >(LongNumber a, LongNumber b)
        {
            if (a._value.Length > b._value.Length) return true;
            else if (a._value.Length < b._value.Length) return false;

            for (int i = 0; i < a._value.Length; i++)
            {
                if ((int)(a._value[i] - '0') > (int)(b._value[i] - '0')) return true;
                else if ((int)(a._value[i] - '0') < (int)(b._value[i] - '0')) return false;
            }

            return false;
        }

        public static bool operator <(LongNumber a, LongNumber b)
        {
            return !(a > b) && a != b;
        }

        public static bool operator ==(LongNumber a, LongNumber b)
        {
            if (a._value.Length != b._value.Length) return false;
            else if (!a._value.Equals(b._value)) return false;

            return true;
        }

        public static bool operator !=(LongNumber a, LongNumber b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public static implicit operator int(LongNumber n)
        {
            int a;
            if (int.TryParse(n.value, out a))
                return a;

            return -1;
        }

        public static implicit operator long(LongNumber n)
        {
            long a;
            if (long.TryParse(n.value, out a))
                return a;

            return -1;
        }

        public static implicit operator short(LongNumber n)
        {
            short a;
            if (short.TryParse(n.value, out a))
                return a;

            return -1;
        }

        public static implicit operator bool(LongNumber n)
        {
            return n._value == "1";
        }

        public static explicit operator LongNumber(int a)
        {
            if (a >= 0) return new LongNumber(a.ToString());
            return new LongNumber("0");
        }

        public static explicit operator LongNumber(long a)
        {
            if (a >= 0) return new LongNumber(a.ToString());
            return new LongNumber("0");
        }

        public static explicit operator LongNumber(short a)
        {
            if (a >= 0) return new LongNumber(a.ToString());
            return new LongNumber("0");
        }

        public static explicit operator LongNumber(bool a)
        {
            if (a) return new LongNumber("1");
            return new LongNumber("0");
        }

        public static bool TryParse(string s, out LongNumber n)
        { 
            n = new LongNumber(s);
            return n._last_set_was_sucessful;
        }

        public static LongNumber operator +(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("");

            LongNumber a1, b1;

            if (a._value.Length > b._value.Length)
            { a1 = a; b1 = b; }
            else { a1 = b; b1 = a; }

            a1 = new LongNumber(a1);
            b1 = new LongNumber(b1);

            b1._value = new string('0', a1._value.Length - b1._value.Length) + b1._value;

            int mem = 0;

            for (int i = b1._value.Length - 1; i >= 0; i--)
            {
                int sub_result = (int)(a1._value[i] - '0') + (int)(b1._value[i] - '0') + mem;

                if (sub_result >= 10)
                { mem = 1; sub_result %= 10; }
                else mem = 0;

                result._value = (sub_result).ToString() + result._value;
            }

            if (mem == 1) result._value = (1).ToString() + result._value;

            return result;
        }

        public static LongNumber operator *(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("0");

            LongNumber a1, b1;

            if (a._value.Length > b._value.Length)
            { a1 = a; b1 = b; }
            else { a1 = b; b1 = a; }

            LongNumber[] sum = new LongNumber[b1._value.Length];

            //b1._value = new string('0', a1._value.Length - b1._value.Length) + b1._value;

            

            for (int j = b1._value.Length - 1; j >= 0; j--)
            {
                string curNum = "";
                int mem = 0;
                for (int i = a1._value.Length - 1; i >= 0; i--)
                {
                    int sub_result = (int)(a1._value[i] - '0') * (int)(b1._value[j] - '0') + mem;

                    if (sub_result >= 10 && i != 0)
                    {
                        mem = sub_result / 10;
                        sub_result = sub_result % 10;
                    }
                    else
                    {
                        mem = 0;
                    }

                    curNum = Convert.ToString(sub_result) + curNum;
                }
                sum[b1._value.Length - j - 1] = new LongNumber(curNum);
            }

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i]._value = sum[i]._value + new string('0', i);
                result = result + sum[i];
            }

            return result;
        }

        //TODO
        public static LongNumber operator /(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("0");

            return result;
        }

        public static LongNumber operator -(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("");

            LongNumber a1, b1;

            if (a > b)
            { a1 = new LongNumber(a); b1 = new LongNumber(b); }
            else if (a < b)
            { a1 = new LongNumber(b); b1 = new LongNumber(a); }
            else
            {
                result._value = "0";
                return result;
            }


            b1._value = new string('0', a1._value.Length - b1._value.Length) + b1._value;

            // b1 меньше

            for (int i = a1._value.Length - 1; i >= 0; i--)
            {
                int sub_result = (int)(a1._value[i] - '0') - (int)(b1._value[i] - '0');

                if (sub_result < 0)
                {
                    for (int j = i; j >= 0; j--)
                    {

                        int buff = (int)(a1._value[j] - '0');

                        if (buff == 0)
                        {
                            StringBuilder sb = new StringBuilder(a1._value);
                            sb[j] = '9';
                            a1._value = sb.ToString();
                        }
                        else
                        {
                            buff -= 1;
                            StringBuilder sb = new StringBuilder(a1._value);
                            sb[j] = Convert.ToChar(buff.ToString());
                            a1._value = sb.ToString();
                            sub_result += 10;
                            break;

                        }
                    }
                }

                result._value = (sub_result).ToString() + result._value;
            }

            result._value = result._value.TrimStart('0');
            return result;
        }
    }

    static class LongNumberExtentions
    {
        public static LongNumber ToLongNumber(this string s)
        {
            return new LongNumber(s);
        }

        public static LongNumber ToLongNumber(this StringBuilder s)
        {
            return new LongNumber(s.ToString());
        }
    }
}
