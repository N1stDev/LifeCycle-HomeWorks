using System.Text;

namespace Task1_3
{
    class LongNumber
    {
        public string _value;

        public string value { get { return _value; } 
            set {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!("1234567890".Contains(value[i])))
                    {
                        _value = "0";
                        return;
                    }
   
                }

                value = value.TrimStart('0');
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
            else
            {
                for (int i = 0; i < a._value.Length; i++)
                    if (a._value[i] != b._value[i])
                        return false;
            }

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

        //TODO
        public static LongNumber operator *(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("0");

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
}
