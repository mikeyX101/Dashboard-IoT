namespace DashboardIoT.Extensions
{
	public static class StringExtensions
	{
		public static byte[] ToUTF8Bytes(this string s)
		{
			return System.Text.Encoding.UTF8.GetBytes(s);
		}
	}
}
