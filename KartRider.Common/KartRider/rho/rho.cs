using KartRider.IO.Packet;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;
using KartRider.Xml;
using ExcData;
using Set_Data;
using System.Xml;
using Ionic.Zlib;
using Microsoft.VisualBasic.ApplicationServices;
using KartRider;
using KartRider.Common.Utilities;

namespace RHOParser
{
	public static class KartRhoFile
	{
		private static Dictionary<int, List<string>> map_extension = new Dictionary<int, List<string>>();

		public static byte[] DecryptKRCrypto(byte[] data, uint key)
		{
			uint[] numArray = new uint[17];
			byte[] dst = new byte[68];
			numArray[0] = key ^ 2222193601U;
			for (int index = 1; index < 16; ++index)
				numArray[index] = numArray[index - 1] - 2072773695U;
			for (int index = 0; index <= 16; ++index)
				Buffer.BlockCopy((Array)BitConverter.GetBytes(numArray[index]), 0, (Array)dst, index * 4, 4);
			int num;
			for (num = 0; num + 64 <= data.Length; num += 64)
			{
				for (int index = 0; index < 16; ++index)
					Buffer.BlockCopy((Array)BitConverter.GetBytes(numArray[index] ^ BitConverter.ToUInt32(data, num + 4 * index)), 0, (Array)data, num + 4 * index, 4);
			}
			for (int index = num; index < data.Length; ++index)
				data[index] = (byte)((uint)data[index] ^ (uint)dst[index - num]);
			return data;
		}

		public static byte[] DecryptKR2Crypto(byte[] data, uint key)
		{
			uint[] numArray = new uint[33];
			byte[] dst = new byte[132];
			numArray[0] = key ^ 927386255U;
			int index1;
			for (index1 = 1; index1 < 16; ++index1)
				numArray[index1] = numArray[index1 - 1] + 666576812U;
			for (; index1 < 32; ++index1)
				numArray[index1] = 701442637U * numArray[index1 - 1];
			for (int index2 = 0; index2 < 33; ++index2)
				Buffer.BlockCopy((Array)BitConverter.GetBytes(numArray[index2]), 0, (Array)dst, index2 * 4, 4);
			int num;
			for (num = 0; num + 128 <= data.Length; num += 128)
			{
				for (int index3 = 0; index3 < 32; ++index3)
					Buffer.BlockCopy((Array)BitConverter.GetBytes(numArray[index3] ^ BitConverter.ToUInt32(data, num + 4 * index3)), 0, (Array)data, num + 4 * index3, 4);
			}
			for (int index4 = num; index4 < data.Length; ++index4)
				data[index4] = (byte)((uint)data[index4] ^ (uint)dst[index4 - num]);
			return data;
		}

		public static uint GetKey(uint counter)
		{
			byte[] bytes = BitConverter.GetBytes(counter);
			return Constants.ThirdByte_Keys[(int)bytes[3]] ^ Constants.SecondByte_Keys[(int)bytes[2]] ^ Constants.FirstByte_Keys[(int)bytes[1]] ^ Constants.ZeroByte_Keys[(int)bytes[0]];
		}

		public static uint DecryptRHOCrypto(byte[] data, uint key)
		{
			uint num1 = 0;
			uint counter = key;
			int index1;
			for (index1 = 0; index1 < 4 * (data.Length >> 2); index1 += 4)
			{
				uint uint32 = BitConverter.ToUInt32(data, index1);
				uint num2 = num1 ^ uint32;
				uint key1 = GetKey(counter);
				++counter;
				Buffer.BlockCopy((Array)BitConverter.GetBytes(key1 ^ num2), 0, (Array)data, index1, 4);
				num1 += BitConverter.ToUInt32(data, index1);
			}
			byte[] bytes1 = BitConverter.GetBytes(GetKey(counter));
			byte[] bytes2 = BitConverter.GetBytes(num1);
			uint index2 = 0;
			uint num3 = 0;
			while (index1 < data.Length)
			{
				data[index1] = (byte)((uint)bytes1[(int)index2] ^ (uint)bytes2[(int)index2] ^ (uint)data[index1]);
				++index1;
				num3 = index2++ + 1U;
			}
			return num3;
		}

		public static byte[] DecryptRHOBlock(
		  BinaryReader br,
		  RHOBlockInfo blockInfo,
		  uint key,
		  int flag,
		  bool isFile = false)
		{
			br.BaseStream.Position = (long)(blockInfo.Offset * 256);
			byte[] decompressedData = br.ReadBytes(blockInfo.PackedSize);
			bool flag1 = false;
			if ((flag & 2) != 0)
			{
				DecompressZlib(decompressedData, 0, decompressedData.Length, out decompressedData);
				flag1 = true;
			}
			if (isFile || !flag1)
			{
				if ((flag & 4) != 0)
					decompressedData = DecryptKRCrypto(decompressedData, key);
				if ((flag & 8) != 0)
					decompressedData = DecryptKR2Crypto(decompressedData, key);
				if ((flag & 1) != 0 && (int)RTTIHelper.GenerateRTTIHash(decompressedData) != (int)blockInfo.Checksum)
					Console.WriteLine("CHECKSUM FAILED. DAFUCK");
			}
			return decompressedData;
		}

		private static void Dump(PackageData data, string currentPath, string args)
		{
			if (data.PackageType == "PackFolder")
			{
				if (data.PackageDataProp["name"] == "KartRider")
				{
					var zetaPackage = data.SubPackages.FirstOrDefault(sub => sub.PackageDataProp["name"] == "zeta");
					if (config.region != zetaPackage.SubPackages[0].PackageDataProp["name"])
					{
						config.region = zetaPackage.SubPackages[0].PackageDataProp["name"];
						Console.WriteLine(zetaPackage.SubPackages[0].PackageDataProp["name"]);
						KartRho5File.Rho5File();
						Dump(data, currentPath, args);
						return;
					}
					foreach (PackageData subPackage in data.SubPackages)
					{
						if (subPackage.PackageDataProp["name"] == "flyingPet")
						{
							foreach (PackageData flyingPet in subPackage.SubPackages)
							{
								Dump(flyingPet, currentPath + Path.DirectorySeparatorChar.ToString() + flyingPet.PackageDataProp["name"], args);
							}
						}
						if (subPackage.PackageDataProp["name"] == "track")
						{
							foreach (PackageData track in subPackage.SubPackages)
							{
								if (track.PackageDataProp["name"] == "common")
								{
									Dump(track, currentPath + Path.DirectorySeparatorChar.ToString() + track.PackageDataProp["name"], args);
								}
							}
						}
					}
				}
			}
			else
			{
				if (!(data.PackageType == "RhoFolder"))
					return;
				string path = data.PackageDataProp["fileName"];
				string str1 = data.PackageDataProp["name"];
				uint key = uint.Parse(data.PackageDataProp["key"]);
				List<byte[]> numArrayList = new List<byte[]>();
				using (FileStream input = new FileStream(args + path, FileMode.Open, FileAccess.Read))
				{
					using (BinaryReader binaryReader = new BinaryReader((Stream)input))
					{
						if (Encoding.Unicode.GetString(binaryReader.ReadBytes(64)).Replace("\0", "").Trim() != "Rh layer spec 1.1")
							Console.WriteLine("header1 != Rh layer spec 1.1 (fileName:{0})", (object)path);
						Encoding.Unicode.GetString(binaryReader.ReadBytes(64)).Replace("\0", "").Trim();
						byte[] numArray1 = binaryReader.ReadBytes(128);
						DecryptRHOCrypto(numArray1, key);
						InPacket inPacket1 = new InPacket(numArray1);
						inPacket1.ReadUInt();
						byte[] numArray2 = new byte[124];
						Buffer.BlockCopy((Array)numArray1, 4, (Array)numArray2, 0, 124);
						if (RTTIHelper.GenerateRTTIHash(numArray2) == 0U)
							;
						byte[] packet = (byte[])null;
						if (inPacket1.ReadUInt() == 65537U)
						{
							uint num1 = inPacket1.ReadUInt();
							uint num2 = inPacket1.ReadUInt() ^ key;
							using (OutPacket outPacket = new OutPacket((int)num1 * 32))
							{
								for (int index = 0; (long)index < (long)num1; ++index)
								{
									byte[] data1 = binaryReader.ReadBytes(32);
									if (num2 > 0U)
									{
										int num3 = (int)DecryptRHOCrypto(data1, num2++);
									}
									outPacket.WriteBytes(data1);
								}
								packet = outPacket.ToArray();
							}
						}
						if (packet == null)
							Console.WriteLine("ERR {0}", (object)path);
						Dictionary<uint, RHOBlockInfo> rhoBlocks = new Dictionary<uint, RHOBlockInfo>();
						InPacket inPacket2 = new InPacket(packet);
						int num = packet.Length / 32;
						for (int index = 0; index < num; ++index)
						{
							RHOBlockInfo rhoBlockInfo = new RHOBlockInfo();
							rhoBlockInfo.FileKey = inPacket2.ReadUInt();
							rhoBlockInfo.Offset = inPacket2.ReadInt();
							rhoBlockInfo.PackedSize = inPacket2.ReadInt();
							rhoBlockInfo.OriginalSize = inPacket2.ReadInt();
							rhoBlockInfo.Flag = inPacket2.ReadInt();
							rhoBlockInfo.Checksum = inPacket2.ReadUInt();
							inPacket2.Skip(8);
							rhoBlocks.Add(rhoBlockInfo.FileKey, rhoBlockInfo);
						}
						string str2 = currentPath;
						//Directory.CreateDirectory(str2);
						RHOBlockInfo blockInfo = rhoBlocks[uint.MaxValue];
						ParseRHODirectory(DecryptRHOBlock(binaryReader, blockInfo, key + 630434289U, blockInfo.Flag), rhoBlocks, binaryReader, key, str2);
					}
				}
			}
		}

		private static void ParseRHODirectory(
		  byte[] directoryContent,
		  Dictionary<uint, RHOBlockInfo> rhoBlocks,
		  BinaryReader rhoFileReader,
		  uint key,
		  string dirname)
		{
			//Directory.CreateDirectory(dirname);
			InPacket inPacket = new InPacket(directoryContent);
			int num1 = inPacket.ReadInt();
			for (int index = 0; index < num1; ++index)
			{
				string path2 = inPacket.ReadNullTerminatedString();
				uint key1 = inPacket.ReadUInt();
				RHOBlockInfo rhoBlock = rhoBlocks[key1];
				ParseRHODirectory(DecryptRHOBlock(rhoFileReader, rhoBlock, key + 630434289U, rhoBlock.Flag), rhoBlocks, rhoFileReader, key, Path.Combine(dirname, path2));
			}
			int num2 = inPacket.ReadInt();
			Dictionary<string, Tuple<int, uint, uint, uint>> dictionary = new Dictionary<string, Tuple<int, uint, uint, uint>>();
			for (int index = 0; index < num2; ++index)
			{
				string str1 = inPacket.ReadNullTerminatedString();
				byte[] bytes = inPacket.ReadBytes(4);
				uint uint32 = BitConverter.ToUInt32(bytes, 0);
				string str2 = Encoding.ASCII.GetString(bytes).Replace("\0", "");
				int num3 = inPacket.ReadInt();
				uint num4 = inPacket.ReadUInt();
				uint num5 = inPacket.ReadUInt();
				dictionary.Add(str1 + "." + str2, new Tuple<int, uint, uint, uint>(num3, num4, num5, uint32));
			}
			foreach (KeyValuePair<string, Tuple<int, uint, uint, uint>> keyValuePair in dictionary)
			{
				uint key2 = keyValuePair.Value.Item2;
				byte[] numArray = new byte[(int)keyValuePair.Value.Item3];
				string[] strArray = keyValuePair.Key.Split('.');
				string str = keyValuePair.Key.Substring(0, keyValuePair.Key.LastIndexOf('.'));
				//Console.WriteLine("--- File {0}", (object)Path.Combine(dirname, keyValuePair.Key));
				if (!map_extension.ContainsKey(keyValuePair.Value.Item1))
					map_extension[keyValuePair.Value.Item1] = new List<string>();
				if (!map_extension[keyValuePair.Value.Item1].Contains(strArray[strArray.Length - 1]))
					map_extension[keyValuePair.Value.Item1].Add(strArray[strArray.Length - 1]);
				int destinationIndex = 0;
				while ((long)destinationIndex < (long)keyValuePair.Value.Item3)
				{
					uint key3 = 0;
					if (keyValuePair.Value.Item1 == 3 || keyValuePair.Value.Item1 == 4 || keyValuePair.Value.Item1 == 5 || keyValuePair.Value.Item1 == 6)
						key3 = (uint)((int)RTTIHelper.GenerateRTTIHash(str) + (int)keyValuePair.Value.Item4 + (int)key - 1970136660);
					RHOBlockInfo rhoBlock = rhoBlocks[key2];
					byte[] sourceArray = DecryptRHOBlock(rhoFileReader, rhoBlock, key3, rhoBlock.Flag, true);
					Array.Copy((Array)sourceArray, 0, (Array)numArray, destinationIndex, sourceArray.Length);
					destinationIndex += rhoBlock.OriginalSize;
					++key2;
				}
				if (keyValuePair.Key == "randomTrack@" + config.region + ".bml")
				{
					BinaryXmlDocument bxd = new BinaryXmlDocument();
					bxd.Read(Encoding.GetEncoding("UTF-16"), numArray);
					string output = bxd.RootTag.ToString();
					byte[] output_data = Encoding.GetEncoding("UTF-16").GetBytes(output);
					string[] parts = dirname.Split(@"\");
					string lastPart = parts[parts.Length - 1];
					Console.WriteLine(Path.Combine(dirname.Replace("DataRaw\\", ""), keyValuePair.Key));
					using (MemoryStream stream = new MemoryStream(output_data))
					{
						KartExcData.randomTrack = XDocument.Load(stream);
					}
				}
				if (keyValuePair.Key == "trackLocale@" + config.region + ".xml")
				{
					string[] parts = dirname.Split(@"\");
					string lastPart = parts[parts.Length - 1];
					Console.WriteLine(Path.Combine(dirname.Replace("DataRaw\\", ""), keyValuePair.Key));
					using (MemoryStream stream = new MemoryStream(numArray))
					{
						XmlDocument trackLocale = new XmlDocument();
						trackLocale.Load(stream);
						XmlNodeList trackParams = trackLocale.GetElementsByTagName("track");
						KartExcData.track = new Dictionary<uint, string>();
						if (trackParams.Count > 0)
						{
							foreach (XmlNode xn in trackParams)
							{
								XmlElement xe = (XmlElement)xn;
								string track = xe.GetAttribute("id");
								uint id = Adler32Helper.GenerateAdler32_UNICODE(track, 0);
								KartExcData.track.Add(id, track);
							}
						}
					}
				}
				else if (keyValuePair.Key == "trackLocale@" + config.region + ".bml")
				{
					BinaryXmlDocument bxd = new BinaryXmlDocument();
					bxd.Read(Encoding.GetEncoding("UTF-16"), numArray);
					string output = bxd.RootTag.ToString();
					byte[] output_data = Encoding.GetEncoding("UTF-16").GetBytes(output);
					string[] parts = dirname.Split(@"\");
					string lastPart = parts[parts.Length - 1];
					Console.WriteLine(Path.Combine(dirname.Replace("DataRaw\\", ""), keyValuePair.Key));
					using (MemoryStream stream = new MemoryStream(output_data))
					{
						XmlDocument trackLocale = new XmlDocument();
						trackLocale.Load(stream);
						XmlNodeList trackParams = trackLocale.GetElementsByTagName("track");
						KartExcData.track = new Dictionary<uint, string>();
						if (trackParams.Count > 0)
						{
							foreach (XmlNode xn in trackParams)
							{
								XmlElement xe = (XmlElement)xn;
								string track = xe.GetAttribute("id");
								uint id = Adler32Helper.GenerateAdler32_UNICODE(track, 0);
								KartExcData.track.Add(id, track);
							}
						}
					}
				}
				if (keyValuePair.Key == "param@" + config.region + ".bml")
				{
					BinaryXmlDocument bxd = new BinaryXmlDocument();
					bxd.Read(Encoding.GetEncoding("UTF-16"), numArray);
					string output = bxd.RootTag.ToString();
					byte[] output_data = Encoding.GetEncoding("UTF-16").GetBytes(output);
					string[] parts = dirname.Split(@"\");
					string lastPart = parts[parts.Length - 1];
					Console.WriteLine(Path.Combine(dirname.Replace("DataRaw\\", ""), keyValuePair.Key));
					using (MemoryStream stream = new MemoryStream(output_data))
					{
						XmlDocument flying = new XmlDocument();
						flying.Load(stream);
						KartExcData.flyingSpec.Add(lastPart, flying);
					}
				}
				//File.WriteAllBytes(Path.Combine(dirname, keyValuePair.Key), numArray);
			}
		}

		private static void DecompressZlib(
		  byte[] compressedData,
		  int offset,
		  int size,
		  out byte[] decompressedData)
		{
			byte[] numArray1 = new byte[size - 2];
			Buffer.BlockCopy((Array)compressedData, offset + 2, (Array)numArray1, 0, numArray1.Length);
			byte[] numArray2 = new byte[2048];
			List<byte[]> numArrayList = new List<byte[]>();
			int length1 = 0;
			System.IO.Compression.DeflateStream deflateStream = new System.IO.Compression.DeflateStream((Stream)new MemoryStream(numArray1), System.IO.Compression.CompressionMode.Decompress);
			int length2;
			while ((length2 = deflateStream.Read(numArray2, 0, 2048)) > 0)
			{
				if (length2 == 2048)
				{
					numArrayList.Add(numArray2);
					numArray2 = new byte[2048];
				}
				else
				{
					byte[] destinationArray = new byte[length2];
					Array.Copy((Array)numArray2, 0, (Array)destinationArray, 0, length2);
					numArrayList.Add(destinationArray);
				}
				length1 += length2;
			}
			byte[] destinationArray1 = new byte[length1];
			int destinationIndex = 0;
			foreach (byte[] sourceArray in numArrayList)
			{
				Array.Copy((Array)sourceArray, 0, (Array)destinationArray1, destinationIndex, sourceArray.Length);
				destinationIndex += sourceArray.Length;
			}
			decompressedData = destinationArray1;
		}

		public static void RhoFile()
		{
			string args = @"Data\";
			FileStream fileStream = new FileStream(args + "aaa.pk", FileMode.Open, FileAccess.Read);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			int totalLength = binaryReader.ReadInt32();
			byte[] array = binaryReader.ReadKRData(totalLength);
			fileStream.Close();
			RTTIHelper.GenerateRTTIHash(array);
			InPacket iPacket = new InPacket(array);
			if (iPacket != null)
			{
				PackageData data = new PackageData();
				data.Init(iPacket);
				Dump(data, "DataRaw", args);
			}
			//Console.WriteLine("Press any key to continue");
			//Console.ReadLine();
		}

		private class PackageData
		{
			public string PackageType { get; set; }

			public string Unknown { get; set; }

			public Dictionary<string, string> PackageDataProp { get; set; }

			public List<PackageData> SubPackages { get; set; }

			public PackageData()
			{
				this.PackageDataProp = new Dictionary<string, string>();
				this.SubPackages = new List<PackageData>();
			}

			public void Init(InPacket iPacket)
			{
				this.PackageType = iPacket.ReadString();
				this.Unknown = iPacket.ReadString();
				int num1 = iPacket.ReadInt();
				for (int index = 0; index < num1; ++index)
					this.PackageDataProp.Add(iPacket.ReadString(), iPacket.ReadString());
				int num2 = iPacket.ReadInt();
				for (int index = 0; index < num2; ++index)
				{
					PackageData packageData = new PackageData();
					packageData.Init(iPacket);
					this.SubPackages.Add(packageData);
				}
			}
		}

		public struct RHOBlockInfo
		{
			public int Offset;
			public int PackedSize;
			public int OriginalSize;
			public int Flag;
			public uint Checksum;
			public uint FileKey;
			public uint Unk2;
			public uint Unk3;
		}
	}
}
