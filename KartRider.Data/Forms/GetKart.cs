using System;
using KartRider.IO.Packet;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ExcData;
using System.Linq;

namespace KartRider
{
	public partial class GetKart : Form
	{
		public static short Item_Type = 0;
		public static short Item_Code = 0;

		public GetKart()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			GetKart.Item_Type = short.Parse(this.tx_ItemType.Text);
			GetKart.Item_Code = short.Parse(this.tx_ItemCode.Text);
			if (Launcher.OpenGetItem)
			{
				(new Thread(() =>
				{
					button1.Enabled = false;
					Thread.Sleep(300);
					short sn = 0, previous_sn;
					if (GetKart.Item_Type == 3)
					{
						sn = 1;
						var itemCode = GetKart.Item_Code;
						var matchingCount = KartExcData.kart.Count(k => k == itemCode);
						sn += (short)matchingCount;
						KartExcData.kart.Add(itemCode);
						Console.WriteLine("kart: " + GetKart.Item_Code + " sn: " + sn);
						using (OutPacket outPacket = new OutPacket("PrRequestKartInfoPacket"))
						{
							outPacket.WriteByte(1);
							outPacket.WriteInt(1);
							outPacket.WriteShort(GetKart.Item_Type);
							outPacket.WriteShort(GetKart.Item_Code);
							outPacket.WriteShort(sn);
							outPacket.WriteShort(1);//수량
							outPacket.WriteShort(0);
							outPacket.WriteShort(-1);
							outPacket.WriteShort(0);
							outPacket.WriteShort(0);
							outPacket.WriteShort(0);
							RouterListener.MySession.Client.Send(outPacket);
						}
					}
					else
					{
						using (OutPacket outPacket = new OutPacket("PrRequestKartInfoPacket"))
						{
							outPacket.WriteByte(1);
							outPacket.WriteInt(1);
							outPacket.WriteShort(GetKart.Item_Type);
							outPacket.WriteShort(GetKart.Item_Code);
							outPacket.WriteUShort(0);
							outPacket.WriteShort(1);//수량
							outPacket.WriteShort(0);
							outPacket.WriteShort(-1);
							outPacket.WriteShort(0);
							outPacket.WriteShort(0);
							outPacket.WriteShort(0);
							RouterListener.MySession.Client.Send(outPacket);
						}
					}
					Thread.Sleep(300);
					button1.Enabled = true;
				})).Start();
			}
		}

		private void FormItem_Load(object sender, EventArgs e)
		{
			this.tx_ItemType.Text = string.Concat(GetKart.Item_Type);
			this.tx_ItemCode.Text = string.Concat(GetKart.Item_Code);
		}

		private void tx_ItemType_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))          
			{
				e.Handled = true;
			}
		}

		private void tx_ItemCode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))         
			{
				e.Handled = true;
			}
		}
	}
}
