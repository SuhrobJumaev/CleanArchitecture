namespace Utils;

public static class StringExtensions
{
	public static bool IsEmpty(this string value)
	{
		return string.IsNullOrEmpty(value);
	}
}