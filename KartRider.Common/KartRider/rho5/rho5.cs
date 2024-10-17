using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;
using ExcData;
using RiderData;
using Set_Data;
using System.Xml.Linq;
using System.Data.SqlTypes;
using System.Linq;
using System.Collections;
using System.Drawing;

namespace RHOParser
{
	internal class KartRho5File
	{
		public static string GetKey(string extName)
		{
			switch (extName)
			{
				case "rho":
					return "flqjtm@2017";
				case "rho2":
				case "rho3":
					return "AFLKJQOIG@9u0";
				case "rho4":
				case "rho5":
					if (config.region == "cn")
					{
						return "d$Bjgfc8@dH4TQ?k";
					}
					else if (config.region == "kr")
					{
						return "y&errfV6GRS!e8JL";
					}
					else if (config.region == "tw")
					{
						return "t5rHKg-g9BA7%=qD";
					}
					else
					{
						return null;
					}
				case "pkn":
					return "";
				default:
					return "";
			}
		}

		public static bool UseFnv1a(string extName)
		{
			switch (extName)
			{
				case "rho":
				case "rho2":
				case "rho3":
					return false;
				case "rho4":
				case "rho5":
					return true;
				default:
					return false;
			}
		}

		public static byte[] decrypt(ECRYPT_ctx ctx, BinaryReader br, int size)
		{
			int num1 = 4;
			if (ctx.readBufferLeft <= 0)
			{
				int num2 = num1 * ((num1 + size - 1) / num1);
				if (num2 > ctx.readBuffer.Length)
				{
					int newSize = 2 * ctx.readBuffer.Length;
					if (2 * ctx.readBuffer.Length < 16)
						newSize = 16;
					if (newSize - ctx.readBuffer.Length > 65536)
						newSize = ctx.readBuffer.Length + 65536;
					if (num2 > newSize)
						newSize = num2;
					Array.Resize<byte>(ref ctx.readBuffer, newSize);
				}
				ctx.readBufferLeft = num2;
				byte[] src = br.ReadBytes(num2);
				Buffer.BlockCopy((Array)src, 0, (Array)ctx.readBuffer, 0, src.Length);
				SnowCipher.ECRYPT_process_bytes(0, ctx, ctx.readBuffer, ctx.readBuffer, (uint)num2);
			}
			byte[] dst = new byte[size];
			if (ctx.readBufferLeft < size)
			{
				Buffer.BlockCopy((Array)ctx.readBuffer, 0, (Array)dst, 0, ctx.readBufferLeft);
				int readBufferLeft = ctx.readBufferLeft;
				int num3 = size - ctx.readBufferLeft;
				ctx.readBufferLeft = 0;
				Buffer.BlockCopy((Array)decrypt(ctx, br, num3), 0, (Array)dst, readBufferLeft, num3);
			}
			else
			{
				Buffer.BlockCopy((Array)ctx.readBuffer, 0, (Array)dst, 0, size);
				byte[] numArray = new byte[ctx.readBufferLeft - size];
				Buffer.BlockCopy((Array)ctx.readBuffer, size, (Array)numArray, 0, numArray.Length);
				Buffer.BlockCopy((Array)numArray, 0, (Array)ctx.readBuffer, 0, numArray.Length);
				ctx.readBufferLeft -= size;
			}
			return dst;
		}

		public static uint decryptUInt(ECRYPT_ctx ctx, BinaryReader bs)
		{
			return BitConverter.ToUInt32(decrypt(ctx, bs, 4), 0);
		}

		public static int decryptInt(ECRYPT_ctx ctx, BinaryReader bs)
		{
			return (int)decryptUInt(ctx, bs);
		}

		public static byte decryptByte(ECRYPT_ctx ctx, BinaryReader bs)
		{
			return decrypt(ctx, bs, 1)[0];
		}

		public static string decryptString(ECRYPT_ctx ctx, BinaryReader bs)
		{
			int num = decryptInt(ctx, bs);
			return Encoding.Unicode.GetString(decrypt(ctx, bs, 2 * num));
		}

		private static void Dump(string fileName, string dirName, string resName, string extName, string file)
		{
			using (FileStream input = new FileStream(file, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader binaryReader = new BinaryReader((Stream)input))
				{
					sbyte[] key1 = new sbyte[128];
					bool flag = UseFnv1a(extName);
					string str1 = fileName.ToLower() + GetKey(extName);
					for (byte index = 0; index < (byte)128; ++index)
						key1[(int)index] = (sbyte)((int)index + (int)(byte)str1[(int)index % str1.Length]);
					int num1 = 0;
					foreach (char ch in Encoding.Unicode.GetBytes(fileName.ToLower()))
						num1 += (int)ch;
					int num2 = 0;
					foreach (char ch in Encoding.Unicode.GetBytes(fileName.ToLower()))
						num2 += (int)ch + 2 * (int)ch;
					int num3 = num1 % 312 + 30;
					int num4 = num2 % 212 + 33;
					binaryReader.BaseStream.Position = (long)num3;
					ECRYPT_ctx ctx1 = new ECRYPT_ctx();
					SnowCipher.ECRYPT_keysetup(ctx1, key1, 128U, 0U);
					SnowCipher.ECRYPT_ivsetup(ctx1, new byte[16]);
					uint num5 = decryptUInt(ctx1, binaryReader);
					byte num6 = decryptByte(ctx1, binaryReader);
					int num7 = decryptInt(ctx1, binaryReader);
					if ((long)num5 != (long)((int)num6 + num7))
						Console.WriteLine("Invalid header checksum! (fileName:{0})", (object)fileName);
					if (num6 != (byte)2)
						Console.WriteLine("Unsupported package version (fileName:{0})", (object)fileName);
					binaryReader.BaseStream.Position = (long)(num3 + num4 + 9);
					sbyte[] key2 = new sbyte[128];
					for (byte index = 0; index < (byte)128; ++index)
						key2[(int)index] = (sbyte)((int)index + ((int)index % 3 + 2) * (int)str1[str1.Length - 1 - (int)index % str1.Length]);
					ECRYPT_ctx ctx2 = new ECRYPT_ctx();
					SnowCipher.ECRYPT_keysetup(ctx2, key2, 128U, 0U);
					SnowCipher.ECRYPT_ivsetup(ctx2, new byte[16]);
					List<Tuple<string, uint, uint, uint, uint, byte[]>> tupleList = new List<Tuple<string, uint, uint, uint, uint, byte[]>>();
					for (int index = 0; index < num7; ++index)
					{
						string str2 = decryptString(ctx2, binaryReader);
						uint num8 = decryptUInt(ctx2, binaryReader);
						uint num9 = decryptUInt(ctx2, binaryReader);
						uint num10 = decryptUInt(ctx2, binaryReader);
						uint num11 = decryptUInt(ctx2, binaryReader);
						uint num12 = decryptUInt(ctx2, binaryReader);
						byte[] array = decrypt(ctx2, binaryReader, 16);
						uint num13 = 0;
						foreach (byte num14 in array)
							num13 += (uint)num14;
						Array.Resize<byte>(ref array, array.Length + 16);
						if ((int)num8 != (int)num9 + (int)num10 + (int)num11 + (int)num12 + (int)num13)
							Console.WriteLine("ElementIndex crc mismatch (fileName:{0})", (object)str2);
						tupleList.Add(new Tuple<string, uint, uint, uint, uint, byte[]>(str2, num9, num10, num11, num12, array));
					}
					long num15 = binaryReader.BaseStream.Position;
					if (((ulong)num15 & 1023UL) > 0UL)
						num15 = num15 - (num15 & 1023L) + 1024L;
					uint d = 2166136261;
					if (flag)
					{
						foreach (int num16 in GetKey(extName))
							d = (uint)(16777619 * (num16 ^ (int)d));
					}
					foreach (Tuple<string, uint, uint, uint, uint, byte[]> tuple in tupleList)
					{
						try
						{
							binaryReader.BaseStream.Position = num15 + (long)(tuple.Item3 << 10);
							//Console.WriteLine(" - {0}", (object) tuple.Item1);
							ECRYPT_ctx ctx3 = new ECRYPT_ctx();
							byte[] decompressedData = null;
							if (tuple.Item1 == "etc_/itemTable.kml" || tuple.Item1 == "etc_/emblem/emblem@" + config.region + ".xml" || (tuple.Item1.Contains("kart_") && tuple.Item1.Contains("/param@" + config.region + ".xml")) || (tuple.Item1.Contains("kart_") && tuple.Item1.Contains("/param.xml")) || tuple.Item1 == "zeta_/" + config.region + "/content/itemDictionary.xml" || tuple.Item1 == "zeta_/" + config.region + "/shop/data/item.kml")
							{
								decompressedData = binaryReader.ReadBytes((int)tuple.Item5);
							}
							if (((ulong)tuple.Item2 & 18446744073709551608UL) > 0UL)
								Debugger.Break();
							uint num17 = (uint)Math.Log10((double)d);
							if ((tuple.Item2 & 4U) > 0U)
							{
								sbyte[] key3 = new sbyte[128];
								if (flag)
								{
									sbyte[] numArray = new sbyte[(int)num17 + 1];
									uint num18 = d;
									uint num19 = num17;
									do
									{
										numArray[(int)num19--] = (sbyte)(num18 % 10U);
										num18 /= 10U;
									}
									while (num18 > 0U);
									for (byte index = 0; index < (byte)128; ++index)
										key3[(int)index] = (sbyte)((int)index + (int)(byte)tuple.Item1[(int)index % tuple.Item1.Length] * ((int)numArray[(int)index % numArray.Length] % 2 + (int)tuple.Item6[((int)index + (int)numArray[((int)index + 2) % numArray.Length]) % 16] + ((int)index + (int)numArray[((int)index + 1) % numArray.Length]) % 5));
								}
								else
								{
									for (byte index = 0; index < (byte)128; ++index)
										key3[(int)index] = (sbyte)((int)index + (int)tuple.Item1[(int)index % tuple.Item1.Length] * ((int)index + (int)tuple.Item6[(int)index % 16] - 5 * ((int)(sbyte)index / 5) + 2));
								}
								SnowCipher.ECRYPT_keysetup(ctx3, key3, 128U, 0U);
								SnowCipher.ECRYPT_ivsetup(ctx3, new byte[16]);
								SnowCipher.ECRYPT_process_bytes(0, ctx3, decompressedData, decompressedData, Math.Min(1024U, tuple.Item5));
							}
							if ((tuple.Item2 & 2U) > 0U)
							{
								sbyte[] key4 = new sbyte[128];
								if (flag)
								{
									sbyte[] numArray = new sbyte[(int)num17 + 1];
									uint num20 = d;
									uint num21 = num17;
									do
									{
										numArray[(int)num21--] = (sbyte)(num20 % 10U);
										num20 /= 10U;
									}
									while (num20 > 0U);
									for (byte index = 0; index < (byte)128; ++index)
										key4[(int)index] = (sbyte)((int)index + (int)(byte)tuple.Item1[(int)index % tuple.Item1.Length] * ((int)numArray[(int)index % numArray.Length] % 2 + (int)tuple.Item6[((int)index + (int)numArray[((int)index + 2) % numArray.Length]) % 16] + ((int)index + (int)numArray[((int)index + 1) % numArray.Length]) % 5));
								}
								else
								{
									for (byte index = 0; index < (byte)128; ++index)
										key4[(int)index] = (sbyte)((int)index + (int)tuple.Item1[(int)index % tuple.Item1.Length] * ((int)index + (int)tuple.Item6[(int)index % 16] - 5 * ((int)(sbyte)index / 5) + 2));
								}
								SnowCipher.ECRYPT_keysetup(ctx3, key4, 128U, 0U);
								SnowCipher.ECRYPT_ivsetup(ctx3, new byte[16]);
								SnowCipher.ECRYPT_process_bytes(0, ctx3, decompressedData, decompressedData, tuple.Item5);
							}
							if ((tuple.Item2 & 1U) > 0U)
								DecompressZlib(decompressedData, 0, decompressedData.Length, out decompressedData);
							if ((long)decompressedData.Length != (long)tuple.Item4)
							{
								if ((long)(decompressedData.Length - 1) != (long)tuple.Item4 && (long)(decompressedData.Length - 2) != (long)tuple.Item4 && (long)(decompressedData.Length - 3) != (long)tuple.Item4)
									throw new Exception();
								if (decompressedData[decompressedData.Length - 1] > (byte)0)
									Debugger.Break();
								Array.Resize<byte>(ref decompressedData, (int)tuple.Item4);
							}
							if (tuple.Item1 != null && tuple.Item1 == "etc_/itemTable.kml")
							{
								Console.WriteLine(tuple.Item1);
								using (MemoryStream stream = new MemoryStream(decompressedData))
								{
									XmlDocument doc = new XmlDocument();
									doc.Load(stream);
									XmlNodeList kart = doc.GetElementsByTagName("kart");
									if (kart.Count > 0)
									{
										foreach (XmlNode xn in kart)
										{
											XmlElement xe = (XmlElement)xn;
											int id = int.Parse(xe.GetAttribute("id"));
											string name = xe.GetAttribute("name");
											KartExcData.KartName.Add(id, name);
										}
									}
									XmlNodeList flying = doc.GetElementsByTagName("flyingPet");
									if (flying.Count > 0)
									{
										foreach (XmlNode xn in flying)
										{
											XmlElement xe = (XmlElement)xn;
											int id = int.Parse(xe.GetAttribute("id"));
											string name = xe.GetAttribute("name");
											KartExcData.flyingName.Add(id, name);
										}
									}
								}
							}
							else if (tuple.Item1 != null && tuple.Item1 == "etc_/emblem/emblem@" + config.region + ".xml")
							{
								Console.WriteLine(tuple.Item1);
								using (MemoryStream stream = new MemoryStream(decompressedData))
								{
									XmlDocument doc = new XmlDocument();
									doc.Load(stream);
									XmlNodeList bodyParams = doc.GetElementsByTagName("emblem");
									KartExcData.emblem = new List<short>();
									if (bodyParams.Count > 0)
									{
										foreach (XmlNode xn in bodyParams)
										{
											XmlElement xe = (XmlElement)xn;
											short id = short.Parse(xe.GetAttribute("id"));
											KartExcData.emblem.Add(id);
										}
									}
								}
							}
							else if (tuple.Item1 != null && tuple.Item1.Contains("kart_") && tuple.Item1.Contains("/param@" + config.region + ".xml"))
							{
								Console.WriteLine(tuple.Item1);
								string name = tuple.Item1.Substring(6, tuple.Item1.Length - 19);
								//Console.WriteLine(name);
								if (decompressedData[2] == 13 && decompressedData[3] == 0 && decompressedData[4] == 10 && decompressedData[5] == 0)
								{
									byte[] newBytes = new byte[decompressedData.Length - 4];
									newBytes[0] = 255;
									newBytes[1] = 254;
									Array.Copy(decompressedData, 6, newBytes, 2, decompressedData.Length - 6);
									//File.WriteAllBytes(@"KartSpec\" + name + ".xml", newBytes);
									using (MemoryStream stream = new MemoryStream(newBytes))
									{
										XmlDocument kart1 = new XmlDocument();
										kart1.Load(stream);
										KartExcData.KartSpec.Add(name, kart1);
									}
								}
								else
								{
									//File.WriteAllBytes(@"KartSpec\" + name + ".xml", decompressedData);
									using (MemoryStream stream = new MemoryStream(decompressedData))
									{
										XmlDocument kart2 = new XmlDocument();
										kart2.Load(stream);
										KartExcData.KartSpec.Add(name, kart2);
									}
								}
							}
							else if (tuple.Item1 != null && tuple.Item1.Contains("kart_") && tuple.Item1.Contains("/param.xml"))
							{
								string name = tuple.Item1.Substring(6, tuple.Item1.Length - 19);
								if (!KartExcData.KartSpec.ContainsKey(name))
								{
									Console.WriteLine(tuple.Item1);
									if (decompressedData[2] == 13 && decompressedData[3] == 0 && decompressedData[4] == 10 && decompressedData[5] == 0)
									{
										byte[] newBytes = new byte[decompressedData.Length - 4];
										newBytes[0] = 255;
										newBytes[1] = 254;
										Array.Copy(decompressedData, 6, newBytes, 2, decompressedData.Length - 6);
										//File.WriteAllBytes(@"KartSpec\" + name + ".xml", newBytes);
										using (MemoryStream stream = new MemoryStream(newBytes))
										{
											XmlDocument kart1 = new XmlDocument();
											kart1.Load(stream);
											KartExcData.KartSpec.Add(name, kart1);
										}
									}
									else
									{
										//File.WriteAllBytes(@"KartSpec\" + name + ".xml", decompressedData);
										using (MemoryStream stream = new MemoryStream(decompressedData))
										{
											XmlDocument kart2 = new XmlDocument();
											kart2.Load(stream);
											KartExcData.KartSpec.Add(name, kart2);
										}
									}
								}
							}
							else if (tuple.Item1 != null && tuple.Item1 == "zeta_/" + config.region + "/content/itemDictionary.xml")
							{
								Console.WriteLine(tuple.Item1);
								using (MemoryStream stream = new MemoryStream(decompressedData))
								{
									XmlDocument doc = new XmlDocument();
									doc.Load(stream);
									XmlNodeList bodyParams = doc.GetElementsByTagName("kartBody");
									KartExcData.dictionary = new List<short>();
									if (bodyParams.Count > 0)
									{
										foreach (XmlNode xn in bodyParams)
										{
											XmlElement xe = (XmlElement)xn;
											short id = short.Parse(xe.GetAttribute("id"));
											short body = short.Parse(xe.GetAttribute("kartBodyGrade"));
											if (body > 10)
											{
												KartExcData.dictionary.Add(id);
											}
										}
									}
								}
							}
							else if (tuple.Item1 != null && tuple.Item1 == "zeta_/" + config.region + "/shop/data/item.kml")
							{
								Console.WriteLine(tuple.Item1);
								using (MemoryStream stream = new MemoryStream(decompressedData))
								{
									XmlDocument doc = new XmlDocument();
									doc.Load(stream);
									XmlNodeList bodyParams = doc.GetElementsByTagName("item");
									if (bodyParams.Count > 0)
									{
										foreach (XmlNode xn in bodyParams)
										{
											XmlElement xe = (XmlElement)xn;
											short itemCatId = short.Parse(xe.GetAttribute("itemCatId"));
											short itemId = short.Parse(xe.GetAttribute("itemId"));
											if (itemCatId == 1)
											{
												KartExcData.character.Add(itemId);
											}
											else if (itemCatId == 2)
											{
												KartExcData.color.Add(itemId);
											}
											else if (itemCatId == 3)
											{
												KartExcData.kart.Add(itemId);
											}
											else if (itemCatId == 4)
											{
												KartExcData.plate.Add(itemId);
											}
											else if (itemCatId == 7)
											{
												KartExcData.slotChanger.Add(itemId);
											}
											else if (itemCatId == 8)
											{
												KartExcData.goggle.Add(itemId);
											}
											else if (itemCatId == 9)
											{
												KartExcData.balloon.Add(itemId);
											}
											else if (itemCatId == 11)
											{
												KartExcData.headBand.Add(itemId);
											}
											else if (itemCatId == 12)
											{
												KartExcData.headPhone.Add(itemId);
											}
											else if (itemCatId == 13)
											{
												KartExcData.ticket.Add(itemId);
											}
											else if (itemCatId == 14)
											{
												KartExcData.upgradeKit.Add(itemId);
											}
											else if (itemCatId == 16)
											{
												KartExcData.handGearL.Add(itemId);
											}
											else if (itemCatId == 18)
											{
												KartExcData.uniform.Add(itemId);
											}
											else if (itemCatId == 20)
											{
												KartExcData.decal.Add(itemId);
											}
											else if (itemCatId == 21)
											{
												KartExcData.pet.Add(itemId);
											}
											else if (itemCatId == 22)
											{
												KartExcData.initialCard.Add(itemId);
											}
											else if (itemCatId == 23)
											{
												KartExcData.card.Add(itemId);
											}
											else if (itemCatId == 26)
											{
												KartExcData.aura.Add(itemId);
											}
											else if (itemCatId == 27)
											{
												KartExcData.skidMark.Add(itemId);
											}
											else if (itemCatId == 28)
											{
												KartExcData.roomCard.Add(itemId);
											}
											else if (itemCatId == 31)
											{
												KartExcData.ridColor.Add(itemId);
											}
											else if (itemCatId == 32)
											{
												KartExcData.rpLucciBonus.Add(itemId);
											}
											else if (itemCatId == 37)
											{
												KartExcData.socket.Add(itemId);
											}
											else if (itemCatId == 38)
											{
												KartExcData.tune.Add(itemId);
											}
											else if (itemCatId == 39)
											{
												KartExcData.resetSocket.Add(itemId);
											}
											else if (itemCatId == 43)
											{
												KartExcData.tuneEnginePatch.Add(itemId);
											}
											else if (itemCatId == 44)
											{
												KartExcData.tuneHandle.Add(itemId);
											}
											else if (itemCatId == 45)
											{
												KartExcData.tuneWheel.Add(itemId);
											}
											else if (itemCatId == 46)
											{
												KartExcData.tuneSupportKit.Add(itemId);
											}
											else if (itemCatId == 49)
											{
												KartExcData.enchantProtect.Add(itemId);
											}
											else if (itemCatId == 52)
											{
												KartExcData.flyingPet.Add(itemId);
											}
											else if (itemCatId == 53)
											{
												KartExcData.enchantProtect2.Add(itemId);
											}
											else if (itemCatId == 61)
											{
												KartExcData.tachometer.Add(itemId);
											}
											else if (itemCatId == 68)
											{
												KartExcData.partsCoating.Add(itemId);
											}
											else if (itemCatId == 69)
											{
												KartExcData.partsTailLamp.Add(itemId);
											}
											else if (itemCatId == 70)
											{
												KartExcData.dye.Add(itemId);
											}
											else if (itemCatId == 71)
											{
												KartExcData.slotBg.Add(itemId);
											}
										}
									}
								}
							}
							else
							{
								break;
							}
							//File.WriteAllBytes(tuple.Item1, decompressedData);
						}
						catch (Exception ex)
						{
							//Console.WriteLine("Error while parsing {0}", (object) tuple.Item1);
						}
					}
				}
			}
		}

		private static void DecompressZlib(
		  byte[] compressedData,
		  int offset,
		  int size,
		  out byte[] decompressedData)
		{
			decompressedData = ZlibStream.UncompressBuffer(compressedData);
		}

		public static void Rho5File()
		{
			string args = @"Data\";
			foreach (string file in Directory.GetFiles(args))
			{
				if (file.EndsWith(".rho5"))
				{
					FileInfo fileInfo = new FileInfo(file);
					try
					{
						Dump(file.Replace(args, ""), file.Replace(args, "").Replace(fileInfo.Extension, ""), file.Replace(args, "").Replace("_", "\\").Replace(fileInfo.Extension, ""), fileInfo.Extension.Replace(".", ""), file.Replace(".\\", ""));
					}
					catch
					{
					}
				}
			}
			//Console.WriteLine("Press any key to continue");
			//Console.ReadLine();
		}
	}
}
