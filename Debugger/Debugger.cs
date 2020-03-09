using UnityEngine;
using System;
using DebugTool;

public static class Debugger
{
    public static bool UseLog = true;
    private static string threadStack = string.Empty;
    private static CString sb = new CString(256);

    static Debugger()
    {
        for (int i = 24; i < 70; i++)
        {
            StringPool.PreAlloc(i, 2);
        }
    }


    //减少gc alloc
    static string GetLogFormat(string str)
    {
        var time = DateTime.Now;
        sb.Clear();
        sb.Append(ConstStringTable.GetTimeIntern(time.Year))
            .Append("-")
            .Append(ConstStringTable.GetTimeIntern(time.Month))
            .Append("-")
            .Append(ConstStringTable.GetTimeIntern(time.Day))
            .Append("-")
            .Append(ConstStringTable.GetTimeIntern(time.Hour))
            .Append(":")
            .Append(ConstStringTable.GetTimeIntern(time.Minute))
            .Append(":")
            .Append(ConstStringTable.GetTimeIntern(time.Second))
            .Append(".")
            .Append(time.Millisecond)
            .Append("-")
            .Append(Time.frameCount % 999)
            .Append(": ")
            .Append(str);

        var dest = StringPool.Alloc(sb.Length);
        sb.CopyToString(dest);
        return dest;
    }

    public static void Log(string str)
    {
        if (!UseLog)
            return;
        str = GetLogFormat(str);
        Debug.Log(str);
        StringPool.Collect(str);
    }


    public static void LogYellow(object message)
    {
        var str = string.Format("<color=Yellow>{0}</color>", message.ToString());
        Log(str);
    }

    public static void LogRed(object message)
    {
        var str = string.Format("<color=Red>{0}</color>", message.ToString());
        Log(str);
    }

    public static void LogBlue(object message)
    {
        var str = string.Format("<color=Blue>{0}</color>", message.ToString());
        Log(str);
    }


    public static void LogGreen(object message)
    {
        var str = string.Format("<color=Green>{0}</color>", message.ToString());
        Log(str);
    }

    public static void Log(object str)
    {
        Log(str);
    }

    public static void Log(string str, object arg0)
    {
        string s = string.Format(str, arg0);
        Log(s);
    }

    public static void Log(string str, object arg0, object arg1)
    {
        string s = string.Format(str, arg0, arg1);
        Log(s);
    }

    public static void Log(string str, object arg0, object arg1, object arg2)
    {
        string s = string.Format(str, arg0, arg1, arg2);
        Log(s);
    }

    public static void Log(string str, params object[] param)
    {
        string s = string.Format(str, param);
        Log(s);
    }

    public static void LogWarning(string str)
    {
        if (!UseLog)
            return;
        str = GetLogFormat(str);
        Debug.LogWarning(str);
        StringPool.Collect(str);
    }

    public static void LogWarning(object message)
    {
        LogWarning(message.ToString());
    }

    public static void LogWarning(string str, object arg0)
    {
        string s = string.Format(str, arg0);
        LogWarning(s);
    }

    public static void LogWarning(string str, object arg0, object arg1)
    {
        string s = string.Format(str, arg0, arg1);
        LogWarning(s);
    }

    public static void LogWarning(string str, object arg0, object arg1, object arg2)
    {
        string s = string.Format(str, arg0, arg1, arg2);
        LogWarning(s);
    }

    public static void LogWarning(string str, params object[] param)
    {
        string s = string.Format(str, param);
        LogWarning(s);
    }

    public static void LogError(string str)
    {
        if (!UseLog)
            return;
        str = GetLogFormat(str);
        Debug.LogError(str);
        StringPool.Collect(str);
    }

    public static void LogError(object str)
    {
        LogError(str.ToString());
    }

    public static void LogError(string str, object arg0)
    {
        string s = string.Format(str, arg0);
        LogError(s);
    }

    public static void LogError(string str, object arg0, object arg1)
    {
        string s = string.Format(str, arg0, arg1);
        LogError(s);
    }

    public static void LogError(string str, object arg0, object arg1, object arg2)
    {
        string s = string.Format(str, arg0, arg1, arg2);
        LogError(s);
    }

    public static void LogError(string str, params object[] param)
    {
        string s = string.Format(str, param);
        LogError(s);
    }


    public static void LogException(Exception e)
    {
        if (!UseLog)
            return;
        threadStack = e.StackTrace;
        string str = GetLogFormat(e.Message);
        Debug.LogError(str);
    }

    public static void LogException(string str, Exception e)
    {
        if (!UseLog)
            return;
        threadStack = e.StackTrace;
        str = GetLogFormat(str + e.Message);
        Debug.LogError(str);
        StringPool.Collect(str);
    }
}

