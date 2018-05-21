using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Reader4096
    {
        public const int NUMBER_4K = 4096;

        public static void RunTestCases()
        {
            char[] buf = new char[NUMBER_4K];

            var reader = new Reader(NUMBER_4K);
            TestHelper.IsEquals(NUMBER_4K, reader.Read(ref buf, NUMBER_4K));

            reader = new Reader(100);
            TestHelper.IsEquals(100, reader.Read(ref buf, 200));

            reader = new Reader(200);
            TestHelper.IsEquals(100, reader.Read(ref buf, 100));

            reader = new Reader(12000);
            TestHelper.IsEquals(2000, reader.Read(ref buf, 2000));
            TestHelper.IsEquals(3000, reader.Read(ref buf, 3000));
            TestHelper.IsEquals(4000, reader.Read(ref buf, 4000));
            TestHelper.IsEquals(3000, reader.Read(ref buf, 4000));

        }

        class Reader
        {
            private int remainInFile;

            private char[] intBuf = new char[NUMBER_4K];
            private int intBufBytes = 0;
            private int intBufPos = 0;

            public Reader(int numberBytesReamingInStream)
            {
                remainInFile = numberBytesReamingInStream;
            }

            public int Read(ref char[] buffer, int n)
            {
                int totalRead = 0;

                // coping rest of bytes from previous read;
                if(intBufBytes > 0)
                {
                    if (intBufBytes < n)
                    {
                        Array.Copy(intBuf, intBufPos, buffer, totalRead, intBufBytes);
                        totalRead += intBufBytes;
                        intBufBytes = 0;
                        intBufPos = 0;
                    }
                    else
                    {
                        Array.Copy(intBuf, intBufPos, buffer, totalRead, n);
                        intBufBytes -= n;
                        intBufPos += n;
                        return n;
                    }
                }

                while(totalRead < n)
                {
                    intBufBytes = Read4K(ref intBuf);

                    if (intBufBytes == 0) // no more content to read
                    {
                        break;
                    }

                    if(n - totalRead >= intBufBytes)
                    {
                        Array.Copy(intBuf, intBufPos, buffer, totalRead, intBufBytes);
                        totalRead += intBufBytes;
                        intBufPos = 0;
                        intBufBytes = 0;
                    }
                    else
                    {
                        Array.Copy(intBuf, intBufPos, buffer, totalRead, n - totalRead);
                        intBufPos = intBufBytes - (n - totalRead);
                        intBufBytes = intBufBytes - intBufPos;
                        totalRead += n - totalRead;
                    }
                }

                return totalRead;
            }

            // fake read 4K
            private int Read4K(ref char[] buffer)
            {
                if (remainInFile >= NUMBER_4K)
                {
                    remainInFile -= NUMBER_4K;
                    return NUMBER_4K;
                }
                else
                {
                    int t = remainInFile;
                    remainInFile = 0;
                    return t;
                }
            }
        }
    }
}
