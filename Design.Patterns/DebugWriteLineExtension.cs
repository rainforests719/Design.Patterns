namespace Design.Patterns
{
    /// <summary>
    /// VS 输出窗口
    /// </summary>
    public static class DebugWriteLineExtension
    {
        /// <summary>
        /// VS 输出窗口
        /// </summary>
        /// <param name="value"> value </param>
        public static void WriteLine(this object value) => System.Diagnostics.Debug.WriteLine(value);
    }
}