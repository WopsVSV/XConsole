using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XConsole
{
    /// <summary>
    /// A console class for extra functionality.
    /// </summary>
    public static class XConsole
    {
        #region System.Console functionality

        public static int LargestWindowWidth => Console.LargestWindowWidth;
        public static int LargestWindowHeight => Console.LargestWindowHeight;
        public static TextReader In => Console.In;
        public static TextWriter Out => Console.Out;
        public static Encoding InputEncoding => Console.InputEncoding;
        public static Encoding OutputEncoding => Console.OutputEncoding;
        public static ConsoleColor BackgroundColor => Console.BackgroundColor;
        public static ConsoleColor ForegroundColor => Console.ForegroundColor;
        public static int BufferHeight => Console.BufferHeight;
        public static int BufferWidth => Console.BufferHeight;
        public static int WindowHeight => Console.WindowHeight;
        public static int WindowWidth => Console.WindowWidth;
        public static TextWriter Error => Console.Error;
        public static bool TreatControlCAsInput => Console.TreatControlCAsInput;
        public static int WindowLeft => Console.WindowLeft;
        public static int WindowTop => Console.WindowTop;
        public static int CursorLeft => Console.CursorLeft;
        public static int CursorTop => Console.CursorTop;
        public static int CursorSize => Console.CursorSize;
        public static bool CursorVisible => Console.CursorVisible;
        public static string Title => Console.Title;
        public static bool KeyAvailable => Console.KeyAvailable;
        public static bool NumberLock => Console.NumberLock;
        public static bool CapsLock => Console.CapsLock;

        public static void Beep() => Console.Beep();
        public static void Beep(int frequency, int duration) => Console.Beep(frequency, duration);
        public static void Clear() => Console.Clear();
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop) => Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor) => Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
        public static Stream OpenStandardError(int bufferSize) => Console.OpenStandardError(bufferSize);
        public static Stream OpenStandardError() => Console.OpenStandardError();
        public static Stream OpenStandardInput(int bufferSize) => Console.OpenStandardInput(bufferSize);
        public static Stream OpenStandardInput() => Console.OpenStandardInput();
        public static Stream OpenStandardOutput(int bufferSize) => Console.OpenStandardOutput(bufferSize);
        public static Stream OpenStandardOutput() => Console.OpenStandardOutput();
        public static int Read() => Console.Read();
        public static ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);
        public static ConsoleKeyInfo ReadKey() => Console.ReadKey();
        public static string ReadLine() => Console.ReadLine();
        public static void ResetColor() => Console.ResetColor();
        public static void SetBufferSize(int width, int height) => Console.SetBufferSize(width, height);
        public static void SetCursorPosition(int left, int top) => Console.SetCursorPosition(left, top);
        public static void SetError(TextWriter newError) => Console.SetError(newError);
        public static void SetIn(TextReader newIn) => Console.SetIn(newIn);
        public static void SetOut(TextWriter newOut) => Console.SetOut(newOut);
        public static void SetWindowPosition(int left, int top) => Console.SetWindowPosition(left, top);
        public static void SetWindowSize(int width, int height) => Console.SetWindowSize(width, height);
        public static void Write(ulong value) => Console.Write(value);
        public static void Write(object value) => Console.Write(value);
        public static void Write(uint value) => Console.Write(value);
        public static void Write(long value) => Console.Write(value);
        public static void Write(string value) => Console.Write(value);
        public static void Write(int value) => Console.Write(value);
        public static void Write(string format, object arg0) => Console.Write(format, arg0);
        public static void Write(string format, object arg0, object arg1, object arg2, object arg3) => Console.Write(format, arg0, arg1, arg2, arg3);
        public static void Write(decimal value) => Console.Write(value);
        public static void Write(double value) => Console.Write(value);
        public static void Write(char value) => Console.Write(value);
        public static void Write(bool value) => Console.Write(value);
        public static void Write(string format, object arg0, object arg1, object arg2) => Console.Write(format, arg0, arg1, arg2);
        public static void Write(string format, object arg0, object arg1) => Console.Write(format, arg0, arg1);
        public static void Write(float value) => Console.Write(value);
        public static void WriteLine(uint value) => Console.WriteLine(value);
        public static void WriteLine(int value) => Console.WriteLine(value);
        public static void WriteLine(float value) => Console.WriteLine(value);
        public static void WriteLine(char value) => Console.WriteLine(value);
        public static void WriteLine(decimal value) => Console.WriteLine(value);
        public static void WriteLine(long value) => Console.WriteLine(value);
        public static void WriteLine(double value) => Console.WriteLine(value);
        public static void WriteLine(ulong value) => Console.WriteLine(value);
        public static void WriteLine(string format, object arg0, object arg1, object arg2, object arg3) => Console.WriteLine(format, arg0, arg1, arg2, arg3);
        public static void WriteLine(string value) => Console.WriteLine(value);
        public static void WriteLine(string format, object arg0) => Console.WriteLine(format, arg0);
        public static void WriteLine(string format, object arg0, object arg1) => Console.WriteLine(format, arg0, arg1);
        public static void WriteLine(string format, object arg0, object arg1, object arg2) => Console.WriteLine(format, arg0, arg1, arg2);
        public static void WriteLine(bool value) => Console.WriteLine(value);
        public static void WriteLine() => Console.WriteLine();
        public static void WriteLine(object value) => Console.WriteLine(value);

        #endregion

        /// <summary>
        /// Writes a formatted text that can include colours.
        /// Example: The [:Blue] brown fox jumps over the [:Red] lazy dog.
        /// If the colour change happens between two spaces, remove one.
        /// </summary>
        public static void WriteFormat(string text)
        {
            // Splits the data by the general format
            string[] dataSplit = text.Split(new string[] { "[:" }, StringSplitOptions.None);

            // If there is no colour change, just print the line
            if (dataSplit.Length == 1)
            {
                Console.Write(text);
                return;
            }

            // Print first line normally
            Console.Write(dataSplit[0]);

            // Handle each part separately
            for (var index = 1; index < dataSplit.Length; index++)
            {

                // Get the index of the ']' occurence
                int colourIndexEnd = dataSplit[index].IndexOf("]", StringComparison.InvariantCultureIgnoreCase);

                // Change the colour
                Console.ForegroundColor = GetColour(dataSplit[index].Substring(0, colourIndexEnd));

                // Remove the colour and the separator ']'
                dataSplit[index] = dataSplit[index].Remove(0, colourIndexEnd + 1);

                // Write the text
                Console.Write(dataSplit[index]);
            }
        }

        /// <summary>
        /// Writes a formatted text line that can include colours.
        /// Example: The [:Blue] brown fox jumps over the [:Red] lazy dog.
        /// If the colour change happens between two spaces, remove one.
        /// </summary>
        public static void WriteLineFormat(string text)
        {
            Write(text);
            Console.WriteLine();
        }

        /// <summary>
        /// Gets a console colour from the name of the specific colour.
        /// </summary>
        private static ConsoleColor GetColour(string colourName)
        {
            foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
            {
                if (string.Equals(color.ToString(), colourName, StringComparison.InvariantCultureIgnoreCase))
                    return color;
            }

            return Console.ForegroundColor;
        }
    }
}
