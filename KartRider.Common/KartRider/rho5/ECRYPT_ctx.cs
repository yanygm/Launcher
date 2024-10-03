namespace RHOParser
{
	public class ECRYPT_ctx
	{
		public uint keysize;
		public sbyte[] key = new sbyte[128];
		public uint s15;
		public uint s14;
		public uint s13;
		public uint s12;
		public uint s11;
		public uint s10;
		public uint s9;
		public uint s8;
		public uint s7;
		public uint s6;
		public uint s5;
		public uint s4;
		public uint s3;
		public uint s2;
		public uint s1;
		public uint s0;
		public uint r1;
		public uint r2;
		public uint dword40;
		public uint dword44;
		public uint[] keystream = new uint[16];
		public byte[] tempReadBuffer = new byte[4096];
		public int bufferPos = 0;
		public int readBufferLeft = 0;
		public byte[] readBuffer = new byte[0];
		public int temp_Len = 1024;
		public int temp_readLen = 0;

		public uint getKey()
		{
			if (this.keysize == 16U)
			{
				SnowCipher.snow_keystream_fast(this, this.keystream);
				this.keysize = 0U;
			}
			return this.keystream[(int)this.keysize++];
		}
	}
}
