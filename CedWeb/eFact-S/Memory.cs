using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;

namespace eFact_S
{
    public class Memory
    {
        [DllImport("kernel32.dll")]
        private static extern Boolean SetProcessWorkingSetSize(IntPtr procHandle, Int32 min, Int32 max);

        public static void ClearMemory()
        {
            try
            {
                Process Mem;
                Mem = Process.GetCurrentProcess(); 
                SetProcessWorkingSetSize(Mem.Handle, -1, -1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
