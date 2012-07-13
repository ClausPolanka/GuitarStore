using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

// Copied this class from: http://stackoverflow.com/questions/160587/no-output-to-console-from-a-wpf-application
// because in WPF apps the Console Windows doesn't work and I wanted to test the SQLInterceptor for NHibernate.

[SuppressUnmanagedCodeSecurity]
public static class ConsoleManager
{
    private const string Kernel32_DllName = "kernel32.dll";

    public static bool HasConsole
    {
        get { return GetConsoleWindow() != IntPtr.Zero; }
    }

    [DllImport(Kernel32_DllName)]
    private static extern bool AllocConsole();

    [DllImport(Kernel32_DllName)]
    private static extern bool FreeConsole();

    [DllImport(Kernel32_DllName)]
    private static extern IntPtr GetConsoleWindow();

    [DllImport(Kernel32_DllName)]
    private static extern int GetConsoleOutputCP();

    /// <summary>
    /// Creates a new console instance if the process is not attached to a console already.
    /// </summary>
    public static void Show()
    {
        //#if DEBUG
        if (!HasConsole)
        {
            AllocConsole();
            InvalidateOutAndError();
        }
        //#endif
    }

    /// <summary>
    /// If the process has a console attached to it, it will be detached and no longer visible. Writing to the System.Console is still possible, but no output will be shown.
    /// </summary>
    public static void Hide()
    {
        //#if DEBUG
        if (HasConsole)
        {
            SetOutAndErrorNull();
            FreeConsole();
        }
        //#endif
    }

    public static void Toggle()
    {
        if (HasConsole)
            Hide();
        else
            Show();
    }

    private static void InvalidateOutAndError()
    {
        Type type = typeof (Console);

        FieldInfo _out = type.GetField("_out",
                                       BindingFlags.Static | BindingFlags.NonPublic);

        FieldInfo _error = type.GetField("_error",
                                         BindingFlags.Static | BindingFlags.NonPublic);

        MethodInfo _InitializeStdOutError = type.GetMethod("InitializeStdOutError",
                                                           BindingFlags.Static | BindingFlags.NonPublic);

        Debug.Assert(_out != null);
        Debug.Assert(_error != null);

        Debug.Assert(_InitializeStdOutError != null);

        _out.SetValue(null, null);
        _error.SetValue(null, null);

        _InitializeStdOutError.Invoke(null, new object[] {true});
    }

    private static void SetOutAndErrorNull()
    {
        Console.SetOut(TextWriter.Null);
        Console.SetError(TextWriter.Null);
    }
}