﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Xml;
using System.Xml.Linq;
using KartRider;
using KartRider.IO.Packet;

namespace ExcData
{
	public static class KartExcData
	{
		public static List<List<short>> TuneList = new List<List<short>>();
		public static List<List<short>> PlantList = new List<List<short>>();
		public static List<List<short>> LevelList = new List<List<short>>();
		public static List<List<short>> PartsList = new List<List<short>>();

		public static Dictionary<int, string> KartName = new Dictionary<int, string>();
		public static Dictionary<string, XmlDocument> KartSpec = new Dictionary<string, XmlDocument>();
		public static Dictionary<int, string> flyingName = new Dictionary<int, string>();
		public static Dictionary<string, XmlDocument> flyingSpec = new Dictionary<string, XmlDocument>();

		public static XDocument randomTrack = new XDocument();
		public static List<short> emblem = new List<short>();
		public static List<short> dictionary = new List<short>();
		public static Dictionary<uint, string> track = new Dictionary<uint, string>();

		public static List<short> character = new List<short>();
		public static List<short> color = new List<short>();
		public static List<short> kart = new List<short>();
		public static List<short> plate = new List<short>();
		public static List<short> slotChanger = new List<short>();
		public static List<short> goggle = new List<short>();
		public static List<short> balloon = new List<short>();
		public static List<short> headBand = new List<short>();
		public static List<short> headPhone = new List<short>();
		public static List<short> ticket = new List<short>();
		public static List<short> upgradeKit = new List<short>();
		public static List<short> handGearL = new List<short>();
		public static List<short> uniform = new List<short>();
		public static List<short> decal = new List<short>();
		public static List<short> pet = new List<short>();
		public static List<short> initialCard = new List<short>();
		public static List<short> card = new List<short>();
		public static List<short> aura = new List<short>();
		public static List<short> skidMark = new List<short>();
		public static List<short> roomCard = new List<short>();
		public static List<short> ridColor = new List<short>();
		public static List<short> rpLucciBonus = new List<short>();
		public static List<short> socket = new List<short>();
		public static List<short> tune = new List<short>();
		public static List<short> resetSocket = new List<short>();
		public static List<short> tuneEnginePatch = new List<short>();
		public static List<short> tuneHandle = new List<short>();
		public static List<short> tuneWheel = new List<short>();
		public static List<short> tuneSupportKit = new List<short>();
		public static List<short> enchantProtect = new List<short>();
		public static List<short> flyingPet = new List<short>();
		public static List<short> enchantProtect2 = new List<short>();
		public static List<short> tachometer = new List<short>();
		public static List<short> partsCoating = new List<short>();
		public static List<short> partsTailLamp = new List<short>();
		public static List<short> dye = new List<short>();
		public static List<short> slotBg = new List<short>();

		public static void Tune_ExcData()
		{
			int All_Kart = TuneList.Count;
			using (OutPacket oPacket = new OutPacket("LoRpGetRiderExcDataPacket"))
			{
				oPacket.WriteByte(1);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteInt(All_Kart);
				for (var i = 0; i < All_Kart; i++)
				{
					oPacket.WriteShort(3);
					oPacket.WriteShort(TuneList[i][0]);
					oPacket.WriteShort(TuneList[i][1]);
					oPacket.WriteShort(0);
					oPacket.WriteShort(0);
					oPacket.WriteShort(TuneList[i][2]);
					oPacket.WriteShort(TuneList[i][3]);
					oPacket.WriteShort(TuneList[i][4]);
					oPacket.WriteShort(0);
					oPacket.WriteShort(0);
					oPacket.WriteShort(0);
					oPacket.WriteShort(0);
				}
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				RouterListener.MySession.Client.Send(oPacket);
			}
		}

		public static void Plant_ExcData()
		{
			int PlantCount = PlantList.Count;
			using (OutPacket oPacket = new OutPacket("LoRpGetRiderExcDataPacket"))
			{
				oPacket.WriteByte(0);
				oPacket.WriteByte(1);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(PlantCount);
				for (var i = 0; i < PlantCount; i++)
				{
					oPacket.WriteShort(PlantList[i][0]);
					oPacket.WriteShort(PlantList[i][1]);
					oPacket.WriteInt(4);
					oPacket.WriteShort(PlantList[i][2]);
					oPacket.WriteShort(PlantList[i][3]);
					oPacket.WriteShort(PlantList[i][4]);
					oPacket.WriteShort(PlantList[i][5]);
					oPacket.WriteShort(PlantList[i][6]);
					oPacket.WriteShort(PlantList[i][7]);
					oPacket.WriteShort(PlantList[i][8]);
					oPacket.WriteShort(PlantList[i][9]);
				}
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				RouterListener.MySession.Client.Send(oPacket);
			}
		}

		public static void Level_ExcData()
		{
			int LevelCount = LevelList.Count;
			using (OutPacket oPacket = new OutPacket("LoRpGetRiderExcDataPacket"))
			{
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteByte(1);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(LevelCount);
				for (var i = 0; i < LevelCount; i++)
				{
					oPacket.WriteShort(LevelList[i][0]);
					oPacket.WriteShort(LevelList[i][1]);
					oPacket.WriteShort(LevelList[i][2]);
					oPacket.WriteShort(LevelList[i][3]);
					oPacket.WriteShort(LevelList[i][4]);
					oPacket.WriteShort(LevelList[i][5]);
					oPacket.WriteShort(LevelList[i][6]);
					oPacket.WriteShort(LevelList[i][7]);
					oPacket.WriteShort(LevelList[i][8]); //코팅
				}
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				RouterListener.MySession.Client.Send(oPacket);
			}
		}

		public static void Parts_ExcData()
		{
			int Parts = PartsList.Count;
			using (OutPacket oPacket = new OutPacket("LoRpGetRiderExcDataPacket"))
			{
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteByte(4);
				oPacket.WriteByte(0);
				oPacket.WriteByte(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				oPacket.WriteInt(Parts);
				for (var i = 0; i < Parts; i++)
				{
					oPacket.WriteShort(PartsList[i][0]);
					oPacket.WriteShort(PartsList[i][1]);
					oPacket.WriteShort(0);
					for (byte l = 0; l < 4; l++)
					{
						oPacket.WriteByte(255);
					}
					oPacket.WriteShort(PartsList[i][2]);
					oPacket.WriteByte((byte)PartsList[i][3]);
					oPacket.WriteShort(PartsList[i][4]);
					oPacket.WriteShort(PartsList[i][5]);
					oPacket.WriteByte((byte)PartsList[i][6]);
					oPacket.WriteShort(PartsList[i][7]);
					oPacket.WriteShort(PartsList[i][8]);
					oPacket.WriteByte((byte)PartsList[i][9]);
					oPacket.WriteShort(PartsList[i][10]);
					oPacket.WriteShort(PartsList[i][11]);
					oPacket.WriteByte((byte)PartsList[i][12]);
					oPacket.WriteShort(PartsList[i][13]);
					oPacket.WriteShort(PartsList[i][14]);
					oPacket.WriteByte(0);
					oPacket.WriteShort(0);
					oPacket.WriteShort(PartsList[i][15]);
					oPacket.WriteByte(0);
					oPacket.WriteShort(0);
				}
				//oPacket.WriteHexString("00 00 FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
				oPacket.WriteInt(0);
				oPacket.WriteInt(0);
				RouterListener.MySession.Client.Send(oPacket);
			}
		}

		public static void AddTuneList(short id, short sn, short tune1, short tune2, short tune3)
		{
			var existingList = TuneList.FirstOrDefault(list => list[0] == id && list[1] == sn);
			if (existingList == null)
			{
				var newList = new List<short> { id, sn, tune1, tune2, tune3 };
				TuneList.Add(newList);
				SaveTuneList(TuneList);
			}
			else
			{
				existingList[2] = tune1;
				existingList[3] = tune2;
				existingList[4] = tune3;
				SaveTuneList(TuneList);
			}
		}

		public static void DelTuneList(short id, short sn)
		{
			var itemToRemove = TuneList.FirstOrDefault(list => list[0] == id && list[1] == sn);
			if (itemToRemove != null)
			{
				TuneList.Remove(itemToRemove);
				SaveTuneList(TuneList);
			}
		}

		public static void SaveTuneList(List<List<short>> List)
		{
			File.Delete(@"Profile\TuneData.xml");
			XmlTextWriter writer = new XmlTextWriter(@"Profile\TuneData.xml", System.Text.Encoding.UTF8);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartDocument();
			writer.WriteStartElement("TuneData");
			writer.WriteEndElement();
			writer.Close();
			for (var i = 0; i < List.Count; i++)
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(@"Profile\TuneData.xml");
				XmlNode root = xmlDoc.SelectSingleNode("TuneData");
				XmlElement xe1 = xmlDoc.CreateElement("Kart");
				xe1.SetAttribute("id", List[i][0].ToString());
				xe1.SetAttribute("sn", List[i][1].ToString());
				xe1.SetAttribute("tune1", List[i][2].ToString());
				xe1.SetAttribute("tune2", List[i][3].ToString());
				xe1.SetAttribute("tune3", List[i][4].ToString());
				root.AppendChild(xe1);
				xmlDoc.Save(@"Profile\TuneData.xml");
			}
		}

		public static void AddPlantList(short id, short sn, short item, short item_id)
		{
			var existingList = PlantList.FirstOrDefault(list => list[0] == id && list[1] == sn);
			if (existingList == null)
			{
				var newList = new List<short> { id, sn, 0, 0, 0, 0, 0, 0, 0, 0 };
				switch (item)
				{
					case 43:
						newList[2] = item;
						newList[3] = item_id;
						break;
					case 44:
						newList[4] = item;
						newList[5] = item_id;
						break;
					case 45:
						newList[6] = item;
						newList[7] = item_id;
						break;
					case 46:
						newList[8] = item;
						newList[9] = item_id;
						break;
				}
				PlantList.Add(newList);
				SavePlantList(PlantList);
			}
			else
			{
				switch (item)
				{
					case 43:
						existingList[2] = item;
						existingList[3] = item_id;
						break;
					case 44:
						existingList[4] = item;
						existingList[5] = item_id;
						break;
					case 45:
						existingList[6] = item;
						existingList[7] = item_id;
						break;
					case 46:
						existingList[8] = item;
						existingList[9] = item_id;
						break;
				}
				SavePlantList(PlantList);
			}
		}

		public static void SavePlantList(List<List<short>> List)
		{
			File.Delete(@"Profile\PlantData.xml");
			XmlTextWriter writer = new XmlTextWriter(@"Profile\PlantData.xml", System.Text.Encoding.UTF8);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartDocument();
			writer.WriteStartElement("PlantData");
			writer.WriteEndElement();
			writer.Close();
			for (var i = 0; i < List.Count; i++)
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(@"Profile\PlantData.xml");
				XmlNode root = xmlDoc.SelectSingleNode("PlantData");
				XmlElement xe1 = xmlDoc.CreateElement("Kart");
				xe1.SetAttribute("id", List[i][0].ToString());
				xe1.SetAttribute("sn", List[i][1].ToString());
				xe1.SetAttribute("item1", List[i][2].ToString());
				xe1.SetAttribute("item_id1", List[i][3].ToString());
				xe1.SetAttribute("item2", List[i][4].ToString());
				xe1.SetAttribute("item_id2", List[i][5].ToString());
				xe1.SetAttribute("item3", List[i][6].ToString());
				xe1.SetAttribute("item_id3", List[i][7].ToString());
				xe1.SetAttribute("item4", List[i][8].ToString());
				xe1.SetAttribute("item_id4", List[i][9].ToString());
				root.AppendChild(xe1);
				xmlDoc.Save(@"Profile\PlantData.xml");
			}
		}

		public static void AddLevelList(short id, short sn, short level, short pointleft, short v1, short v2, short v3, short v4, short Effect)
		{
			var existingList = LevelList.FirstOrDefault(list => list[0] == id && list[1] == sn);
			if (existingList == null)
			{
				var newList = new List<short> { id, sn, level, pointleft, v1, v2, v3, v4, Effect };
				LevelList.Add(newList);
				SaveLevelList(LevelList);
			}
			else
			{
				existingList[3] = pointleft;
				existingList[4] = v1;
				existingList[5] = v2;
				existingList[6] = v3;
				existingList[7] = v4;
				existingList[8] = Effect;
				SaveLevelList(LevelList);
			}
		}

		public static void SaveLevelList(List<List<short>> List)
		{
			File.Delete(@"Profile\LevelData.xml");
			XmlTextWriter writer = new XmlTextWriter(@"Profile\LevelData.xml", System.Text.Encoding.UTF8);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartDocument();
			writer.WriteStartElement("LevelData");
			writer.WriteEndElement();
			writer.Close();
			for (var i = 0; i < List.Count; i++)
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(@"Profile\LevelData.xml");
				XmlNode root = xmlDoc.SelectSingleNode("LevelData");
				XmlElement xe1 = xmlDoc.CreateElement("Kart");
				xe1.SetAttribute("id", List[i][0].ToString());
				xe1.SetAttribute("sn", List[i][1].ToString());
				xe1.SetAttribute("level", List[i][2].ToString());
				xe1.SetAttribute("pointleft", List[i][3].ToString());
				xe1.SetAttribute("v1", List[i][4].ToString());
				xe1.SetAttribute("v2", List[i][5].ToString());
				xe1.SetAttribute("v3", List[i][6].ToString());
				xe1.SetAttribute("v4", List[i][7].ToString());
				xe1.SetAttribute("Effect", List[i][8].ToString());
				root.AppendChild(xe1);
				xmlDoc.Save(@"Profile\LevelData.xml");
			}
		}

		public static void AddPartsList(short id, short sn, short Item_Cat_Id, short Item_Id, byte Grade, short PartsValue)
		{
			var existingList = PartsList.FirstOrDefault(list => list[0] == id && list[1] == sn);
			if (existingList == null)
			{
				var newList = new List<short> { id, sn, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
				switch (Item_Cat_Id)
				{
					case 63:
						newList[2] = Item_Id;
						newList[3] = Grade;
						newList[4] = PartsValue;
						break;
					case 64:
						newList[5] = Item_Id;
						newList[6] = Grade;
						newList[7] = PartsValue;
						break;
					case 65:
						newList[8] = Item_Id;
						newList[9] = Grade;
						newList[10] = PartsValue;
						break;
					case 66:
						newList[11] = Item_Id;
						newList[12] = Grade;
						newList[13] = PartsValue;
						break;
					case 68:
						newList[14] = Item_Id;
						break;
					case 69:
						newList[15] = Item_Id;
						break;
				}
				PartsList.Add(newList);
				SavePartsList(PartsList);
			}
			else
			{
				switch (Item_Cat_Id)
				{
					case 63:
						existingList[2] = Item_Id;
						existingList[3] = Grade;
						existingList[4] = PartsValue;
						break;
					case 64:
						existingList[5] = Item_Id;
						existingList[6] = Grade;
						existingList[7] = PartsValue;
						break;
					case 65:
						existingList[8] = Item_Id;
						existingList[9] = Grade;
						existingList[10] = PartsValue;
						break;
					case 66:
						existingList[11] = Item_Id;
						existingList[12] = Grade;
						existingList[13] = PartsValue;
						break;
					case 68:
						existingList[14] = Item_Id;
						break;
					case 69:
						existingList[15] = Item_Id;
						break;
				}
				SavePartsList(PartsList);
			}
		}

		public static void SavePartsList(List<List<short>> List)
		{
			File.Delete(@"Profile\PartsData.xml");
			XmlTextWriter writer = new XmlTextWriter(@"Profile\PartsData.xml", System.Text.Encoding.UTF8);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartDocument();
			writer.WriteStartElement("PartsData");
			writer.WriteEndElement();
			writer.Close();
			for (var i = 0; i < List.Count; i++)
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(@"Profile\PartsData.xml");
				XmlNode root = xmlDoc.SelectSingleNode("PartsData");
				XmlElement xe1 = xmlDoc.CreateElement("Kart");
				xe1.SetAttribute("id", List[i][0].ToString());
				xe1.SetAttribute("sn", List[i][1].ToString());
				xe1.SetAttribute("Item_Id1", List[i][2].ToString());
				xe1.SetAttribute("Grade1", List[i][3].ToString());
				xe1.SetAttribute("PartsValue1", List[i][4].ToString());
				xe1.SetAttribute("Item_Id2", List[i][5].ToString());
				xe1.SetAttribute("Grade2", List[i][6].ToString());
				xe1.SetAttribute("PartsValue2", List[i][7].ToString());
				xe1.SetAttribute("Item_Id3", List[i][8].ToString());
				xe1.SetAttribute("Grade3", List[i][9].ToString());
				xe1.SetAttribute("PartsValue3", List[i][10].ToString());
				xe1.SetAttribute("Item_Id4", List[i][11].ToString());
				xe1.SetAttribute("Grade4", List[i][12].ToString());
				xe1.SetAttribute("PartsValue4", List[i][13].ToString());
				xe1.SetAttribute("partsCoating", List[i][14].ToString());
				xe1.SetAttribute("partsTailLamp", List[i][15].ToString());
				root.AppendChild(xe1);
				xmlDoc.Save(@"Profile\PartsData.xml");
			}
		}
	}
}
