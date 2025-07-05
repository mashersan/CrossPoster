namespace CrossPoster
{
    /// <summary>
    /// アプリケーションのエントリーポイントを定義するクラス。
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}