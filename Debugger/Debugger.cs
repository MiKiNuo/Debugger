using UnityEngine;
using System;
using System.Globalization;
using DebugTool;

public static class Debugger
{
    public static bool useLog = true;
    public static string threadStack = string.Empty;

    static Debugger()
    {
    }

    //减少gc alloc
    static string GetLogFormat(string str)
    {
        using (zstring.Block()) {
            DateTime time = DateTime.Now;
            var str1 = zstring.Concat(ConstStringTable.GetTimeIntern(time.Hour), ":", ConstStringTable.GetTimeIntern(time.Minute), ":", ConstStringTable.GetTimeIntern(time.Second), ".");
            var str2 = zstring.Concat(time.Millisecond, "-", Time.frameCount % 999, ":", str);
            var str3 = zstring.Concat(str1, str2);
            return str3;
        }
    }

    public static void Log(string str)
    {
        str = GetLogFormat(str);

        if (useLog) {
            Debug.Log(str);
        }
    }


    public static void LogYellow<TA>(TA message) where TA : IConvertible
    {
        using (zstring.Block()) {
            var str = zstring.Concat("<color=Yellow>", message.ToString(CultureInfo.InvariantCulture), "</color>");
            Log(str.ToString());
        }
    }

    public static void LogRed<TA>(TA message) where TA : IConvertible
    {
        using (zstring.Block()) {
            var str = zstring.Concat("<color=Red>", message.ToString(CultureInfo.InvariantCulture), "</color>");
            Log(str.ToString());
        }
    }

    public static void LogBlue<TA>(TA message) where TA : IConvertible
    {
        using (zstring.Block()) {
            var str = zstring.Concat("<color=Blue>", message.ToString(CultureInfo.InvariantCulture), "</color>");
            Log(str.ToString());
        }
    }


    public static void LogGreen<TA>(TA message) where TA : IConvertible
    {
        using (zstring.Block()) {
            var str = zstring.Concat("<color=Green>", message.ToString(CultureInfo.InvariantCulture), "</color>");
            Log(str.ToString());
        }
    }

    public static void Log<TA>(TA message) where TA : IConvertible
    {
        Log(message.ToString(CultureInfo.InvariantCulture));
    }

    public static void Log<TA>(string str, TA arg0) where TA : IConvertible
    {
        using (zstring.Block()) {
            var s = zstring.Format(str, arg0.ToString(CultureInfo.InvariantCulture));
            Log(s.ToString());
        }
    }

    public static void Log<TA>(string str, TA arg0, TA arg1) where TA : IConvertible
    {
        using (zstring.Block())
        {
            var s = zstring.Format(str, arg0.ToString(CultureInfo.InvariantCulture), arg1.ToString(CultureInfo.InvariantCulture));
            Log(s.ToString());
        }
    }

    public static void Log<TA>(string str, TA arg0, TA arg1, TA arg2) where TA : IConvertible
    {
        using (zstring.Block()) {
            var s = zstring.Format(str, arg0.ToString(CultureInfo.InvariantCulture), arg1.ToString(CultureInfo.InvariantCulture), arg2.ToString(CultureInfo.InvariantCulture));
            Log(s.ToString());
        }
    }

    public static void Log(string str, params object[] param)
    {
        string s = string.Format(str, param);
        Log(s);
    }

    public static void LogWarning(string str)
    {
        str = GetLogFormat(str);

        if (useLog) {
            Debug.LogWarning(str);
        }
    }

    public static void LogWarning<TA>(TA message) where TA : IConvertible
    {
        LogWarning(message.ToString(CultureInfo.InvariantCulture));
    }

    public static void LogWarning<TA>(string str, TA arg0) where TA : IConvertible
    {
        using (zstring.Block()) {
            var s = zstring.Format(str, arg0.ToString(CultureInfo.InvariantCulture));
            LogWarning(s.ToString());
        }
    }

    public static void LogWarning<TA>(string str, TA arg0, TA arg1) where TA : IConvertible
    {
        using (zstring.Block()) {
            var s = zstring.Format(str, arg0.ToString(CultureInfo.InvariantCulture), arg1.ToString(CultureInfo.InvariantCulture));
            LogWarning(s.ToString());
        }
    }

    public static void LogWarning<TA>(string str, TA arg0, TA arg1, TA arg2) where TA : IConvertible
    {
        using (zstring.Block()) {
            var s = zstring.Format(str, arg0.ToString(CultureInfo.InvariantCulture), arg1.ToString(CultureInfo.InvariantCulture), arg2.ToString(CultureInfo.InvariantCulture));
            LogWarning(s.ToString());
        }
    }

    public static void LogWarning(string str, params object[] param)
    {
        string s = string.Format(str, param);
        LogWarning(s);
    }

    public static void LogError(string str)
    {
        str = GetLogFormat(str);

        if (useLog) {
            Debug.LogError(str);
        }
    }

    public static void LogError<TA>(TA message) where TA : IConvertible
    {
        LogError(message.ToString(CultureInfo.InvariantCulture));
    }

    public static void LogError<TA>(string str, TA arg0) where TA : IConvertible
    {
        using (zstring.Block()) {
            var s = zstring.Format(str, arg0.ToString(CultureInfo.InvariantCulture));
            LogError(s.ToString());
        }
    }

    public static void LogError<TA>(string str, TA arg0, TA arg1) where TA : IConvertible
    {
        using (zstring.Block()) {
            var s = zstring.Format(str, arg0.ToString(CultureInfo.InvariantCulture), arg1.ToString(CultureInfo.InvariantCulture));
            LogError(s.ToString());
        }
    }

    public static void LogError<TA>(string str, TA arg0, TA arg1, TA arg2) where TA : IConvertible
    {
        using (zstring.Block()) {
            var s = zstring.Format(str, arg0.ToString(CultureInfo.InvariantCulture), arg1.ToString(CultureInfo.InvariantCulture), arg2.ToString(CultureInfo.InvariantCulture));
            LogError(s.ToString());
        }
    }

    public static void LogError(string str, params object[] param)
    {
        string s = string.Format(str, param);
        LogError(s);
    }


    public static void LogException(Exception e)
    {
        threadStack = e.StackTrace;
        string str = GetLogFormat(e.Message);

        if (useLog) {
            Debug.LogError(str);
        }
    }

    public static void LogException(string str, Exception e)
    {
        threadStack = e.StackTrace;
        using (zstring.Block()) {
            var exceptionStr = zstring.Concat(str, e.Message);
            str = GetLogFormat(exceptionStr);
        }
        if (useLog) {
            Debug.LogError(str);
        }
    }
}

