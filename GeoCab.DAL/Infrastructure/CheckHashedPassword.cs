using System;
using System.Security.Cryptography;

namespace GeoCab.DAL.Infrastructure
{
	public static class CheckHashedPassword
	{
		public static bool VerifyHashedPassword(string hashedPassword, string password)
		{
			byte[] buffer4;
			if (hashedPassword == null)
			{
				return false;
			}
			if (password == null)
			{
				throw new ArgumentNullException("password");
			}
    			
			var src = Convert.FromBase64String(hashedPassword);
    			
			if ((src.Length != 0x31) || (src[0] != 0))
			{
				return false;
			}
    			
			byte[] dst = new byte[0x10];
			Buffer.BlockCopy(src, 1, dst, 0, 0x10);
			byte[] buffer3 = new byte[0x20];
			Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
    			
			using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
			{
				buffer4 = bytes.GetBytes(0x20);
			}
    			
			return ByteArrayEqual(buffer3, buffer4);
		}
    		
		static bool ByteArrayEqual(byte[] a1, byte[] a2)
		{
			if (a1.Length != a2.Length)
				return false;
    
			for (int i=0; i<a1.Length; i++)
				if (a1[i] != a2[i])
					return false;
    
			return true;
		}
	}
}