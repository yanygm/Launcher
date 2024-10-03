using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.Xml;

namespace KartRider.Xml
{
	public static class BinaryWriterExt
	{
		public static void WriteString(this BinaryWriter br, Encoding encoding, string Text)
		{
			byte[] bytes = encoding.GetBytes(Text);
			br.Write(Text.Length);
			br.Write(bytes);
		}

		public static void Write(this BinaryWriter br, Encoding encoding, string Key, string Value)
		{
			br.WriteString(encoding, Key);
			br.WriteString(encoding, Value);
		}

		public static void WriteNullTerminatedText(this BinaryWriter br, string text, bool wideString)
		{
			if (!wideString)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(text);
				br.Write(bytes);
				br.Write((byte)0);
			}
			else
			{
				byte[] bytes2 = Encoding.Unicode.GetBytes(text);
				br.Write(bytes2);
				br.Write((short)0);
			}
		}
	}
}