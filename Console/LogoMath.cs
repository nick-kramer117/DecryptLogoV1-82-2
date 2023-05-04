using System;
using System.Text;

namespace Console_nt117
{
    public class LogoMath
    {
        public static byte[] keyForBinFile = "1329268C0ADE7241".ToBytes();

        private static byte[] _st_PCTable1 = new byte[] { 56, 48, 40, 32, 24, 16, 8, 0, 57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18, 10, 2, 59, 51, 43, 35, 62, 54, 46, 38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 60, 52, 44, 36, 28, 20, 12, 4, 27, 19, 11, 3 };
        private static byte[] _st_LeftShiftTable = new byte[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
        private static byte[] _st_PCTable2 = new byte[] { 13, 16, 10, 23, 0, 4, 2, 27, 14, 5, 20, 9, 22, 18, 11, 3, 25, 7, 15, 6, 26, 19, 12, 1, 40, 51, 30, 36, 46, 54, 29, 39, 50, 44, 32, 47, 43, 48, 38, 55, 33, 52, 45, 41, 49, 35, 28, 31 };

        private static byte[] _st_IPTable = new byte[] { 57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3, 61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7, 56, 48, 40, 32, 24, 16, 8, 0, 58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4, 62, 54, 46, 38, 30, 22, 14, 6 };
        private static byte[] _st_IIPTable = new byte[] { 39, 7, 47, 15, 55, 23, 63, 31, 38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29, 36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27, 34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25, 32, 0, 40, 8, 48, 16, 56, 24 };

        private static byte[] _st_EPTable = new byte[] { 31, 0, 1, 2, 3, 4, 3, 4, 5, 6, 7, 8, 7, 8, 9, 10, 11, 12, 11, 12, 13, 14, 15, 16, 15, 16, 17, 18, 19, 20, 19, 20, 21, 22, 23, 24, 23, 24, 25, 26, 27, 28, 27, 28, 29, 30, 31, 0 };

        private static byte[] _st_SandBox1 = new byte[] { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7, 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8, 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0, 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 };
        private static byte[] _st_SandBox2 = new byte[] { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10, 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5, 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15, 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 };
        private static byte[] _st_SandBox3 = new byte[] { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8, 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1, 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7, 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 };
        private static byte[] _st_SandBox4 = new byte[] { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15, 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9, 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4, 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 };
        private static byte[] _st_SandBox5 = new byte[] { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9, 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6, 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14, 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 };
        private static byte[] _st_SandBox6 = new byte[] { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11, 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8, 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6, 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 };
        private static byte[] _st_SandBox7 = new byte[] { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1, 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6, 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2, 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 };
        private static byte[] _st_SandBox8 = new byte[] { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7, 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2, 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8, 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 };

        private static byte[] _st_PPTable = new byte[] { 15, 6, 19, 20, 28, 11, 27, 16, 0, 14, 22, 25, 4, 17, 30, 9, 1, 7, 23, 13, 31, 26, 2, 8, 18, 12, 29, 5, 21, 10, 3, 24 };

        public static String getSdAndPsw(byte[] byArray)
        {
            if (byArray.Length != 48)
            {
                return "";
            }

            StringBuilder stringBuffer = new StringBuilder();

            for (int i = 32; i < 48 && byArray[i] != 0; ++i)
            {
                stringBuffer.Append((char)byArray[i]);
            }

            return stringBuffer.ToString();
        }

        public static String getSdAndPsw(byte[] byArray, bool s)
        {
            if (byArray.Length != 48)
            {
                return "";
            }

            StringBuilder stringBuffer = new StringBuilder();
           
            for (int i = 0; i < 48 && byArray[i] != 0; ++i)
            {
                stringBuffer.Append((char)byArray[i]);
            }
            return stringBuffer.ToString();
        }

        /// <summary>
        /// Алгоритм дешифровки.
        /// </summary>
        /// <param name="msg">msg</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static byte[] symDecrypt(byte[] msg, byte[] key)
        {
            if (msg.Length % 8 != 0)
            {
                return msg;
            }

            int size = 48;
            byte[][] table =
            {
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size],
                new byte[size]
            };
            
            desInitializeKey(key, table);
            
            byte[] buffer = new byte[8];
            byte[] result = new byte[msg.Length];
            
            for (int i = 0; i < msg.Length / 8; ++i)
            {
                int n;
                for (n = 0; n < 8; ++n)
                {
                    buffer[n] = msg[i * 8 + n];
                }

                desCalc(buffer, table, false);
                
                for (n = 0; n < 8; ++n)
                {
                    result[i * 8 + n] = buffer[n];
                }
            }
            
            return result;
        }

        /// <summary>
        /// Иницелизация ключа
        /// </summary>
        /// <param name="key"></param>
        /// <param name="table"></param>
        private static void desInitializeKey(byte[] key, byte[][] table)
        {
            byte[] bufferKey = new byte[64];
            
            bytesToBits(bufferKey, key);
            
            byte[] bufferTable = new byte[56];
            
            for (int i = 0; i < 56; i++)
            {
                bufferTable[i] = bufferKey[_st_PCTable1[i]];
            }
            
            for (int i = 0; i < 16; i++)
            {
                if (1 == _st_LeftShiftTable[i])
                {
                    desKey56LeftShift1(bufferTable);
                }
                else
                {
                    desKey56LeftShift2(bufferTable);
                }

                for (int j = 0; j < 48; j++)
                {
                    table[i][j] = bufferTable[_st_PCTable2[j]];
                }
            }
        }

        private static void bytesToBits(byte[] outArr, byte[] inArr)
        {
            int n = 128;

            for (int i = 0; i < outArr.Length && i / 8 != inArr.Length; ++i)
            {
                byte n2 = (byte)(inArr[i / 8] & n >> i % 8);
                outArr[i] = (byte)(n2 >> 7 - i % 8);
            }
        }

        private static void desKey56LeftShift1(byte[] bufferTabley)
        {
            byte value = bufferTabley[0];

            for (int i = 0; i < 55; ++i)
            {
                bufferTabley[i] = bufferTabley[i + 1];
            }

            bufferTabley[55] = bufferTabley[27];
            bufferTabley[27] = value;
        }

        private static void desKey56LeftShift2(byte[] bufferTable)
        {
            byte vakue = bufferTable[0];
            byte value2 = bufferTable[1];

            for (int i = 0; i < 54; ++i)
            {
                bufferTable[i] = bufferTable[i + 2];
            }

            bufferTable[54] = bufferTable[26];
            bufferTable[55] = bufferTable[27];
            bufferTable[26] = vakue;
            bufferTable[27] = value2;
        }

        private static void desCalc(byte[] buffer, byte[][] table, bool flag)
        {
            byte[] byteArry = new byte[64];
            
            bytesToBits(byteArry, buffer);
            
            byte[] bufferTable = new byte[64];
            
            for (int i = 0; i < bufferTable.Length; i++)
            {
                bufferTable[i] = byteArry[_st_IPTable[i]];
            }
            
            byte[] buffer1 = new byte[32];
            byte[] buffer2 = new byte[32];
            
            for (int i = 0; i < buffer1.Length; i++)
            {
                buffer1[i] = bufferTable[i];
                buffer2[i] = bufferTable[i + 32];
            }
            
            if (flag)
            {
                for (int i = 0; i < 16; i++)
                {
                    desCalcRound(buffer1, buffer2, table[i]);
                }
            }
            else
            {
                for (int i = 15; i >= 0; i--)
                {
                    desCalcRound(buffer1, buffer2, table[i]);
                }
            }
            
            for (int i = 0; i < buffer1.Length; i++)
            {
                bufferTable[i] = buffer2[i];
                bufferTable[i + 32] = buffer1[i];
            }
            
            for (int i = 0; i < bufferTable.Length; i++)
            {
                byteArry[i] = bufferTable[_st_IIPTable[i]];
            }
            
            bitsToBytes(buffer, byteArry);
        }

        private static void desCalcRound(byte[] buffer1, byte[] buffer2, byte[] byArray3)
        {
            byte[] _buffer1 = new byte[32];
            
            for (int i = 0; i < _buffer1.Length; i++)
            {
                _buffer1[i] = buffer1[i];
                buffer1[i] = buffer2[i];
            }
            
            byte[] _buffer2 = new byte[48];
            
            for (int i = 0; i < _buffer2.Length; i++)
            {
                _buffer2[i] = buffer2[_st_EPTable[i]];
            }
            
            for (int i = 0; i < _buffer2.Length; i++)
            {
                _buffer2[i] = (byte)(_buffer2[i] ^ byArray3[i]);
            }
            
            byte[] _buffer3 = new byte[32];
            
            DESSandBoxFiltHelper(_buffer3, 0, 4, DESSandBoxSearchHelper(_st_SandBox1, 0, _buffer2));
            DESSandBoxFiltHelper(_buffer3, 4, 4, DESSandBoxSearchHelper(_st_SandBox2, 6, _buffer2));
            DESSandBoxFiltHelper(_buffer3, 8, 4, DESSandBoxSearchHelper(_st_SandBox3, 12, _buffer2));
            DESSandBoxFiltHelper(_buffer3, 12, 4, DESSandBoxSearchHelper(_st_SandBox4, 18, _buffer2));
            DESSandBoxFiltHelper(_buffer3, 16, 4, DESSandBoxSearchHelper(_st_SandBox5, 24, _buffer2));
            DESSandBoxFiltHelper(_buffer3, 20, 4, DESSandBoxSearchHelper(_st_SandBox6, 30, _buffer2));
            DESSandBoxFiltHelper(_buffer3, 24, 4, DESSandBoxSearchHelper(_st_SandBox7, 36, _buffer2));
            DESSandBoxFiltHelper(_buffer3, 28, 4, DESSandBoxSearchHelper(_st_SandBox8, 42, _buffer2));
            
            for (int i = 0; i < _buffer3.Length; i++)
            {
                buffer2[i] = _buffer3[_st_PPTable[i]];
            }
            
            for (int i = 0; i < _buffer3.Length; i++)
            {
                buffer2[i] = (byte)(buffer2[i] ^ _buffer1[i]);
            }
        }

        private static void DESSandBoxFiltHelper(byte[] byArray, int n, int n2, byte by)
        {
            for (int i = n2 - 1; i >= 0; --i)
            {
                byArray[n + i] = (byte)(by & 1);
                by = (byte)(by >> 1);
            }
        }

        private static byte DESSandBoxSearchHelper(byte[] byArray, int n, byte[] byArray2)
        {
            int n2 = byArray2[n] << 5 | byArray2[n + 5] << 4 | byArray2[n + 1] << 3 | byArray2[n + 2] << 2 | byArray2[n + 3] << 1 | byArray2[n + 4];
            return byArray[n2];
        }

        private static void bitsToBytes(byte[] byArray, byte[] byArray2)
        {
            for (int i = 0; i < byArray2.Length && i / 8 != byArray.Length; ++i)
            {
                if (i % 8 == 0)
                {
                    byArray[i / 8] = 0;
                }
                byte by = (byte)(byArray2[i] << 7 - i % 8);
                byArray[i / 8] = (byte)(byArray[i / 8] | by);
            }
        }
    }
}