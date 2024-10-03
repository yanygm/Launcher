using System;
using System.Text;

namespace RHOParser
{
	public class RTTIHelper
	{
		public static uint GenerateRTTIHash(string str, uint a1 = 0)
		{
			return RTTIHelper.GenerateRTTIHash(Encoding.Unicode.GetBytes(str), a1);
		}

		public static uint GenerateRTTIHash(byte[] str, uint a1 = 0)
		{
			int index = 0;
			uint length = (uint)str.Length;
			uint num1 = a1 >> 16;
			uint num2 = (uint)(ushort)a1;
			uint rttiHash;
			if (str.Length == 1)
			{
				int num3 = (int)str[0] + (int)num2;
				if ((uint)num3 >= 65521U)
					num3 -= 65521;
				int num4 = (int)((long)num3 + (long)num1);
				if ((uint)num4 >= 65521U)
					num4 -= 65521;
				rttiHash = (uint)(num3 | num4 << 16);
			}
			else if (str != null)
			{
				if (str.Length >= 16)
				{
					if (str.Length >= 5552)
					{
						uint num5 = (uint)str.Length / 5552U;
						do
						{
							length -= 5552U;
							int num6 = 347;
							do
							{
								int num7 = (int)str[index] + (int)num2;
								int num8 = num7 + (int)num1;
								int num9 = (int)str[index + 1] + num7;
								int num10 = num9 + num8;
								int num11 = (int)str[index + 2] + num9;
								int num12 = num11 + num10;
								int num13 = (int)str[index + 3] + num11;
								int num14 = num13 + num12;
								int num15 = (int)str[index + 4] + num13;
								int num16 = num15 + num14;
								int num17 = (int)str[index + 5] + num15;
								int num18 = num17 + num16;
								int num19 = (int)str[index + 6] + num17;
								int num20 = num19 + num18;
								int num21 = (int)str[index + 7] + num19;
								int num22 = num21 + num20;
								int num23 = (int)str[index + 8] + num21;
								int num24 = num23 + num22;
								int num25 = (int)str[index + 9] + num23;
								int num26 = num25 + num24;
								int num27 = (int)str[index + 10] + num25;
								int num28 = num27 + num26;
								int num29 = (int)str[index + 11] + num27;
								int num30 = num29 + num28;
								int num31 = (int)str[index + 12] + num29;
								int num32 = num31 + num30;
								int num33 = (int)str[index + 13] + num31;
								int num34 = num33 + num32;
								int num35 = (int)str[index + 14] + num33;
								int num36 = num35 + num34;
								num2 = (uint)str[index + 15] + (uint)num35;
								num1 = num2 + (uint)num36;
								index += 16;
								--num6;
							}
							while (num6 != 0);
							num2 %= 65521U;
							--num5;
							num1 %= 65521U;
						}
						while (num5 > 0U);
					}
					if (length > 0U)
					{
						if (length >= 16U)
						{
							uint num37 = length >> 4;
							do
							{
								int num38 = (int)str[index] + (int)num2;
								int num39 = num38 + (int)num1;
								int num40 = (int)str[index + 1] + num38;
								int num41 = num40 + num39;
								int num42 = (int)str[index + 2] + num40;
								int num43 = num42 + num41;
								int num44 = (int)str[index + 3] + num42;
								int num45 = num44 + num43;
								int num46 = (int)str[index + 4] + num44;
								int num47 = num46 + num45;
								int num48 = (int)str[index + 5] + num46;
								int num49 = num48 + num47;
								int num50 = (int)str[index + 6] + num48;
								int num51 = num50 + num49;
								int num52 = (int)str[index + 7] + num50;
								int num53 = num52 + num51;
								int num54 = (int)str[index + 8] + num52;
								int num55 = num54 + num53;
								int num56 = (int)str[index + 9] + num54;
								int num57 = num56 + num55;
								int num58 = (int)str[index + 10] + num56;
								int num59 = num58 + num57;
								int num60 = (int)str[index + 11] + num58;
								int num61 = num60 + num59;
								int num62 = (int)str[index + 12] + num60;
								int num63 = num62 + num61;
								int num64 = (int)str[index + 13] + num62;
								int num65 = num64 + num63;
								int num66 = (int)str[index + 14] + num64;
								int num67 = num66 + num65;
								num2 = (uint)str[index + 15] + (uint)num66;
								length -= 16U;
								num1 = num2 + (uint)num67;
								index += 16;
								--num37;
							}
							while (num37 > 0U);
						}
						for (; length > 0U; --length)
						{
							num2 += (uint)str[index++];
							num1 += num2;
						}
						num2 %= 65521U;
						num1 %= 65521U;
					}
					rttiHash = num2 | num1 << 16;
				}
				else
				{
					if (str.Length != 0)
					{
						do
						{
							num2 += (uint)str[index++];
							num1 += num2;
							--length;
						}
						while (length > 0U);
					}
					if (num2 >= 65521U)
						num2 -= 65521U;
					rttiHash = num2 | num1 % 65521U << 16;
				}
			}
			else
				rttiHash = 1U;
			return rttiHash;
		}
	}
}
