using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming
{
    public class Programming
    {
        public int Test1(int[] A)
        {
            if (A.Where(x => x > 0).Count() > 0)
            {
                int[] orderedArray = A.OrderBy(x => x).ToArray();
                for (int i = 0; i < orderedArray.Count() - 1; i++)
                {
                    if (orderedArray[i] <= 0)
                    {
                        continue;
                    }
                    if (orderedArray[i + 1] - orderedArray[i] == 1 ||
                        orderedArray[i + 1] - orderedArray[i] == 0)
                    {
                        continue;
                    }

                    return orderedArray[i] + 1;
                }

                return orderedArray[orderedArray.Count() - 1] + 1;
            }

            return 1;
        }

        public string Test2(int T)
        {
            if (T < 0 || T > 86399)
            {
                return string.Empty;
            }
            int hourParam = 3600;
            int saat = T / hourParam;

            int kalan = T % hourParam;

            int dakika = kalan / 60;
            int saniye = kalan % 60;

            return saat + "h" + dakika + "m" + saniye + "s";
        }

        public string Test3(int A, int B, int C, int D)
        {
            if (!validateParam(A) ||
                !validateParam(B) ||
                !validateParam(C) ||
                !validateParam(D))
            {
                return string.Empty;
            }

            int[] hours = { joinParams(A, B, C, D),
                            joinParams(A, B, D, C),
                            joinParams(A, C, B, D),
                            joinParams(A, C, D, B),
                            joinParams(A, D, C, B),
                            joinParams(A, D, B, C),

                            joinParams(B, A, C, D),
                            joinParams(B, A, D, B),
                            joinParams(B, C, A, D),
                            joinParams(B, C, D, A),
                            joinParams(B, D, C, A),
                            joinParams(B, D, A, C),

                            joinParams(C, A, B, D),
                            joinParams(C, A, D, B),
                            joinParams(C, B, A, D),
                            joinParams(C, B, D, A),
                            joinParams(C, D, B, A),
                            joinParams(C, D, A, B),

                            joinParams(D, A, C, B),
                            joinParams(D, A, B, C),
                            joinParams(D, B, A, C),
                            joinParams(D, B, C, A),
                            joinParams(D, C, A, B),
                            joinParams(D, C, B, A),

            };
            if (hours.Where(x => x > 0).Count() < 1)
            {
                return "NOT POSSIBLE";
            }
            int[] orderedArray = hours.OrderBy(x => x).ToArray();

            string maxTime = orderedArray.Max(x => x).ToString();
            return findTime(maxTime.PadLeft(4, '0'));
        }

        private bool validateParam(int A)
        {
            if (A < 0 || A > 9)
            {
                return false;
            }

            return true;
        }

        private int joinParams(int a, int b, int c, int d)
        {
            if (Convert.ToInt32(a.ToString() + b.ToString()) > 23 ||
                Convert.ToInt32(c.ToString() + d.ToString()) > 59)
            {
                return -1;
            }

            return Convert.ToInt32(a.ToString() + b.ToString() + c.ToString() + d.ToString());
        }

        private string findTime(string t)
        {
            string value = t[0].ToString() + t[1].ToString() + ":" + t[2].ToString() + t[3].ToString();
            return value;
        }

        public int Test4(int[] A, int X)
        {
            int N = A.Length;
            if (N == 0 || N > 100000 || X < -2000000 || X > 2000000)
            {
                return -1;
            }
            int l = 0;
            int r = N - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (A[m] > X)
                {
                    r = m - 1;
                }
                else
                {
                    l = m;
                    break;
                }
            }
            if (A[l] == X)
            {
                return l;
            }
            return -1;
        }

    }
}
