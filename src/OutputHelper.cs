namespace LeetCode;

public static class OutputHelper
{
    public static string Write(string message, int ms)
    {
        return $"[{message}] ({ms}ms)";
    }

    /*public static string WriteStringArray(string[] message, int ms)
    {
        return Write(string.Join(',', message), ms);
    }*/
}