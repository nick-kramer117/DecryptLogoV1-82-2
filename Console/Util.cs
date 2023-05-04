using System;
using System.Collections.Generic;

namespace Console_nt117
{
	public static class Util
	{
		private readonly static Dictionary<char, byte> hexmap = new Dictionary<char, byte>()
		{
			{ 'a', 0xA },{ 'b', 0xB },{ 'c', 0xC },{ 'd', 0xD },
			{ 'e', 0xE },{ 'f', 0xF },{ 'A', 0xA },{ 'B', 0xB },
			{ 'C', 0xC },{ 'D', 0xD },{ 'E', 0xE },{ 'F', 0xF },
			{ '0', 0x0 },{ '1', 0x1 },{ '2', 0x2 },{ '3', 0x3 },
			{ '4', 0x4 },{ '5', 0x5 },{ '6', 0x6 },{ '7', 0x7 },
			{ '8', 0x8 },{ '9', 0x9 }
		};

		public static byte[] ToBytes(this string hex)
		{
			if (string.IsNullOrWhiteSpace(hex))
				throw new ArgumentException("Hex cannot be null/empty/whitespace");

			if (hex.Length % 2 != 0)
				throw new FormatException("Hex must have an even number of characters");

			bool startsWithHexStart = hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase);

			if (startsWithHexStart && hex.Length == 2)
				throw new ArgumentException("There are no characters in the hex string");


			int startIndex = startsWithHexStart ? 2 : 0;

			byte[] bytesArr = new byte[(hex.Length - startIndex) / 2];

			char left;
			char right;

			try
			{
				int x = 0;
				for (int i = startIndex; i < hex.Length; i += 2, x++)
				{
					left = hex[i];
					right = hex[i + 1];
					bytesArr[x] = (byte)((hexmap[left] << 4) | hexmap[right]);
				}
				return bytesArr;
			}
			catch (KeyNotFoundException)
			{
				throw new FormatException("Hex string has non-hex character");
			}
		}

		public static byte[] GetPassword(this byte[] arr)
        {
			byte[] bytes = new byte [48];

			int j = 16;

			for(int i = 0; i < bytes.Length; i++)
            {
				bytes[i] = arr[j];
				j++;
            }

			return bytes;
        }

		public static bool IncorrentFormatIP(this string ip)
		{
			try
			{
				string[] arr = ip.Split('.');
				int lenth = 4;
				
				if (lenth == arr.Length)
                {
					for (int i = 0; i < arr.Length; i++)
                    {
						int value = Convert.ToInt32(arr[i]);
						
						if (value < 0 || value > 255)
                        {
							return true;
                        }
                    }

					return false;
                }

				return true;
				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return true;
			}
		}
	}
}