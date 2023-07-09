using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SteamVerConverter.Service
{
    internal class DialogService
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class OpenFileName
        {
            public int structSize = 0;
            public IntPtr dlgOwner = IntPtr.Zero;
            public IntPtr instance = IntPtr.Zero;

            public String filter = string.Empty;
            public String customFilter = string.Empty;
            public int maxCustFilter = 0;
            public int filterIndex = 0;

            public String file = string.Empty;
            public int maxFile = 0;

            public String fileTitle = string.Empty;
            public int maxFileTitle = 0;

            public String initialDir = string.Empty;

            public String title = string.Empty;

            public int flags = 0;
            public short fileOffset = 0;
            public short fileExtension = 0;

            public String defExt = string.Empty;

            public IntPtr custData = IntPtr.Zero;
            public IntPtr hook = IntPtr.Zero;

            public String templateName = string.Empty;

            public IntPtr reservedPtr = IntPtr.Zero;
            public int reservedInt = 0;
            public int flagsEx = 0;
        }

        public class LibWrap
        {
            //BOOL GetOpenFileName(LPOPENFILENAME lpofn);

            [DllImport("Comdlg32.dll", CharSet = CharSet.Auto)]
            public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
        }

        public static string OpenChooseFileDlg()
        {
            OpenFileName ofn = new OpenFileName();

            ofn.structSize = Marshal.SizeOf(ofn);

            ofn.filter = "选择steam.exe\0*.exe";

            ofn.file = new String(new char[256]);
            ofn.maxFile = ofn.file.Length;

            ofn.fileTitle = new String(new char[64]);
            ofn.maxFileTitle = ofn.fileTitle.Length;

            ofn.initialDir = "";
            ofn.title = "选择Steam.exe";
            ofn.defExt = "txt";

            if (LibWrap.GetOpenFileName(ofn))
            {
                //Console.WriteLine("Selected file with full path: {0}", ofn.file);
                //Console.WriteLine("Selected file name: {0}", ofn.fileTitle);
                //Console.WriteLine("Offset from file name: {0}", ofn.fileOffset);
                //Console.WriteLine("Offset from file extension: {0}", ofn.fileExtension);
                return ofn.file;
            }
            return string.Empty;
        }

        public class NonClickableMessageBox : Form
        {
            private static NonClickableMessageBox messageBox;
            private static System.Threading.Timer timer;

            private NonClickableMessageBox(string message, string caption, int timeout)
            {
                Size = new Size(600, 600);
                StartPosition = FormStartPosition.CenterScreen;
                ShowInTaskbar = false;
                ControlBox = false;
                MinimizeBox = false;
                MaximizeBox = false;
                FormBorderStyle = FormBorderStyle.FixedSingle;

                var label = new Label
                {
                    Text = message,
                    AutoSize = false, // 禁用自动调整大小
                    TextAlign = ContentAlignment.TopLeft,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 30, FontStyle.Bold), // 设置字体为 Arial，大小为 12，加粗
                    MaximumSize = new Size(600, 0), // 设置最大宽度，以便自动换行
                    AutoEllipsis = true, // 超过最大宽度时显示省略号
                };

                var panel = new Panel
                {
                    Dock = DockStyle.Fill
                };
                panel.Controls.Add(label);
                Controls.Add(panel);

                timer = new System.Threading.Timer(state =>
                {
                    Close();
                    timer.Dispose();
                }, null, timeout, Timeout.Infinite);
            }

            public static void Show(string message, string caption, int timeout)
            {
                messageBox = new NonClickableMessageBox(message, caption, timeout);
                messageBox.ShowDialog();
            }
        }
    }
}
