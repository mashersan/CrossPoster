namespace CrossPoster
{
    /// <summary>
    /// �A�v���P�[�V�����̃G���g���[�|�C���g���`����N���X�B
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}