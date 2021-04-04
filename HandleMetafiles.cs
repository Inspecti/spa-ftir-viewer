using System;
using System.Runtime.InteropServices;

namespace spa_ftir_viewer
{
    class HandleMetafiles
    {
        [DllImport("Gdi32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetEnhMetaFileW", ExactSpelling = true)]
        public extern static IntPtr GetEnhMetaFileW(string path);

        [DllImport("Gdi32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "DeleteEnhMetaFile", ExactSpelling = true)]
        public extern static int DeleteEnhMetaFile(IntPtr handle);

        [DllImport("Gdi32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetEnhMetaFileBits", ExactSpelling = true)]
        public extern static IntPtr SetEnhMetaFileBits(uint size, byte[] bytes);

        public static bool CopyEmfToClipboard(IntPtr winHandle, System.IO.MemoryStream stream)
        {
            if (ClipboardFunctions.OpenClipboard(winHandle))
            {
                int CF_ENHMETAFILE = 14;

                IntPtr ptr = SetEnhMetaFileBits((uint)stream.Length, stream.ToArray());

                ClipboardFunctions.EmptyClipboard();
                ClipboardFunctions.SetClipboardData(CF_ENHMETAFILE, ptr);
                ClipboardFunctions.CloseClipboard();

                DeleteEnhMetaFile(ptr);
                return true;
            }
            return false;
        }
    }
}
