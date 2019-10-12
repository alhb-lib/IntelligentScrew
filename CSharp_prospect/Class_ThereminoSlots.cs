using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Theremino_HAL
{

    static class Theremino
    {
        //  --------------------------------------------------- 
        public static float NAN_Sleep;
        public static float NAN_Reset;
        public static float NAN_Run;
        public static float NAN_Stop;
        //  ---------------------------------------------------
        public static float NAN_Recognize;
        public static float NAN_ReconnectUSB;
        public static float NAN_Calibrate;
        //  ---------------------------------------------------
        public static float NAN_MasterError;
        public static float NAN_NoMasters;
        //  --------------------------------------------------- 
        public static Boolean OperatingSystemIsWindows;
        public static Boolean OperatingSystemIs_XP_or_Vista;
        //  --------------------------------------------------- 
        public static thereminoSlots Slots = new thereminoSlots();
        //  --------------------------------------------------- 
        public static void InitNanValues()
        {
            // ---------------------------------------------------- initializing QUIET NAN base values  
            byte[] b =  {0, 0, 0xC0, 0x7F};  //  LSB...MSB
            // ---------------------------------------------------- QNAN 1 = SLEEP (unpower Servo Motors)(unimplemented in HAL)
            b[0] = 1; NAN_Sleep = BitConverter.ToSingle(b, 0);
            // ---------------------------------------------------- QNAN 2 = ZERO  (reset Stepper destination to zero)(unimplemented in HAL)
            b[0] = 2; NAN_Reset = BitConverter.ToSingle(b, 0);
            // ---------------------------------------------------- QNAN 3 = RUN   (unimplemented in HAL)
            b[0] = 3; NAN_Run = BitConverter.ToSingle(b, 0);
            // ---------------------------------------------------- QNAN 4 = STOP  (unimplemented in HAL)
            b[0] = 4; NAN_Stop = BitConverter.ToSingle(b, 0);
            // ---------------------------------------------------- QNAN 5 = RECOGNIZE
            b[0] = 5; NAN_Recognize = BitConverter.ToSingle(b, 0);
            // ---------------------------------------------------- QNAN 6 = RECONNECT_USB
            b[0] = 6; NAN_ReconnectUSB = BitConverter.ToSingle(b, 0);
            // ---------------------------------------------------- QNAN 7 = CALIBRATE
            b[0] = 7; NAN_Calibrate = BitConverter.ToSingle(b, 0);
            // ------------------------------------------------------- QNAN 100 = MASTER ERROR (one or more master disconneected)
            b[0] = 100; NAN_MasterError = BitConverter.ToSingle(b, 0);
            // ------------------------------------------------------- QNAN 101 = NO MASTERS (no Master has been found by Recognize)
            b[0] = 101; NAN_NoMasters = BitConverter.ToSingle(b, 0);
        }

        public static bool IsNanSleep(float n)
        {
            if (!float.IsNaN(n)) return false;
            byte[] b = BitConverter.GetBytes(n);
            if (b[0] == 1) return true;
            return false;
        }

        public static bool IsNanReset(float n)
        {
            if (!float.IsNaN(n)) return false;
            byte[] b = BitConverter.GetBytes(n);
            if (b[0] == 2) return true;
            return false;
        }

        public static bool IsNanRecognize(float n)
        {
            if (!float.IsNaN(n)) return false;
            byte[] b = BitConverter.GetBytes(n);
            if (b[0] == 5) return true;
            return false;
        }

        public static bool IsNanReconnectUSB(float n)
        {
            if (!float.IsNaN(n)) return false;
            byte[] b = BitConverter.GetBytes(n);
            if (b[0] == 6) return true;
            return false;
        }

        public static bool IsNanCalibrate(float n)
        {
            if (!float.IsNaN(n)) return false;
            byte[] b = BitConverter.GetBytes(n);
            if (b[0] == 7) return true;
            return false;
        }


        public static bool NAN_Compare(float n1, float n2)
        {
            if (!float.IsNaN(n1)) return false;
            if (!float.IsNaN(n2)) return false;
            byte[] b1 = BitConverter.GetBytes(n1);
            byte[] b2 = BitConverter.GetBytes(n2);
            if (b1[0] == b2[0]) return true;
            return false;
        }

        public static string NAN_GetName(float n)
        {
            if (!float.IsNaN(n)) return "";
            byte[] b = BitConverter.GetBytes(n);
            switch (b[0])
            {
                case 1 : return "Sleep";
                case 2 : return "Reset";
                case 3 : return "Run";
                case 4 : return "Stop";
                case 5 : return "Recognize";
                case 6 : return "ReconnectUSB";
                case 7 : return "Calibrate";
                case 100: return "Master disconnected ERROR";
                case 101 : return "No Masters";
                default: return "Unknown NAN";
            }
        }

        public static void InitPlatformData()
        {
            OperatingSystemIsWindows = true;
            OperatingSystemIs_XP_or_Vista = false;

            switch (System.Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    break;
                default:
                    OperatingSystemIsWindows = false;
                    break;
            }
            if (OperatingSystemIsWindows && System.Environment.OSVersion.Version.Major <= 6)
            {
                OperatingSystemIs_XP_or_Vista = true;
            }
        }


       public static string PlatformAdjustedFileName(string FileName, string DefaultName)
        {
            if (Theremino.OperatingSystemIsWindows)
            {
                FileName = FileName.Replace("/", "\\");
                return FileName;
            }
            else
            {
                if (FileName.Contains(":")) FileName = DefaultName;
                FileName = FileName.Replace("\\", "/");
                return FileName;
            }
        }

    }


    // ======================================================================================
    //  Class ThereminoSlots - Single Class unified for Windows and Unix
    // ======================================================================================
	public class thereminoSlots
	{

		private static MemoryMappedFile MMF1;
        private static MemoryMappedFile_Unix MMF1_Unix;

        public thereminoSlots()
        {
            Theremino.InitNanValues();
            Theremino.InitPlatformData();
            if (Theremino.OperatingSystemIsWindows)
                MMF1 = new MemoryMappedFile("Theremino1", 4080);
            else
                MMF1_Unix = new MemoryMappedFile_Unix();
        }

        public thereminoSlots(string SlotFileName, Int32 SizeBytes)
        {
            Theremino.InitNanValues();
            if (SizeBytes == 0) SizeBytes = 4080;
            Theremino.InitPlatformData();
            if (Theremino.OperatingSystemIsWindows)
                MMF1 = new MemoryMappedFile(SlotFileName, SizeBytes);
            else
                MMF1_Unix = new MemoryMappedFile_Unix();
        }

		public static float ReadSlot(Int32 Slot)
		{
            if (Theremino.OperatingSystemIsWindows)
			    return MMF1.ReadSingle(Slot * 4);
			else
                return MMF1_Unix.ReadSlot(Slot);
		}

        public static float ReadSlot_NoNan(Int32 Slot)
		{
            float n;
            if (Theremino.OperatingSystemIsWindows)
                n = MMF1.ReadSingle(Slot * 4);
            else
                n = MMF1_Unix.ReadSlot(Slot);
			if (float.IsNaN(n)) n = 0; 
			return n;
		}

        public static float ReadSlot_NoNan_0_1000(Int32 Slot)
        {
            float n;
            if (Theremino.OperatingSystemIsWindows)
                n = MMF1.ReadSingle(Slot * 4);
            else
                n = MMF1_Unix.ReadSlot(Slot);
            if (float.IsNaN(n)) n = 0;
            if (n < 0) n = 0;
            if (n > 1000) n = 1000;
            return n;
        }

        public static void WriteSlot(Int32 Slot, float Value)
		{
            if (Theremino.OperatingSystemIsWindows)
                MMF1.WriteSingle(Slot * 4, Value);
            else
                MMF1_Unix.WriteSlot(Slot, Value);
		}

        public static void MemoryMappedFile_FillWithNanSleep()
		{
            if (Theremino.OperatingSystemIsWindows)
			    for (Int32 i = 0; i <= (4080 / 4) - 1; i++) 
                {
                    MMF1.WriteSingle(i * 4, Theremino.NAN_Sleep);
			    }
            else
                for (Int32 i = 0; i <= 999; i++)
                {
                    MMF1_Unix.WriteSlot(i, Theremino.NAN_Sleep);
                }
		}



		// ======================================================================================
		//   CLASS MemoryMappedFile
		// ======================================================================================
		public class MemoryMappedFile
		{

			private struct SECURITY_ATTRIBUTES
			{
				public const Int32 nLength = 12;
				public Int32 lpSecurityDescriptor;
				public Int32 bInheritHandle;
			}

			// ---------------------------------------------------------------- private declararations
			[DllImport("Kernel32")]
			private static extern bool CloseHandle(Int32 intPtrFileHandle);

			[DllImport("Kernel32", EntryPoint = "CreateFileMappingA")]
			private static extern Int32 CreateFileMapping(Int32 hFile, ref SECURITY_ATTRIBUTES lpFileMappigAttributes, Int32 flProtect, Int32 dwMaximumSizeHigh, Int32 dwMaximumSizeLow, string lpname);

			[DllImport("Kernel32")]
			private static extern IntPtr MapViewOfFile(Int32 hFileMappingObject, Int32 dwDesiredAccess, Int32 dwFileOffsetHigh, Int32 dwFileOffsetLow, Int32 dwNumberOfBytesToMap);

			[DllImport("Kernel32")]
			private static extern Int32 UnmapViewOfFile(IntPtr lpBaseAddress);

			private const Int32 PAGE_READWRITE = 4;

			private const Int32 FILE_MAP_ALL_ACCESS = 0x1 | 0x2 | 0x4 | 0x8 | 0x10 | 0xf0000;

			private const Int32 INVALID_HANDLE_VALUE = -1;
			// ---------------------------------------------------------------- private members

			private Int32 FileHandle = 0;
			private IntPtr MappingAddress = IntPtr.Zero;

			private Int32 FileLength = 0;
			// ---------------------------------------------------------------- construction / destruction


			internal MemoryMappedFile(string Filename, 
                                      [System.Runtime.InteropServices.OptionalAttribute, 
                                       System.Runtime.InteropServices.DefaultParameterValueAttribute(1024)] 
                                       Int32 Length)
			{
                SECURITY_ATTRIBUTES secDummy = new SECURITY_ATTRIBUTES();
                FileHandle = CreateFileMapping(INVALID_HANDLE_VALUE, ref secDummy, PAGE_READWRITE, 0, Length, Filename);

				if (FileHandle == 0) {
					MessageBox.Show("Unable to create the MemoryMappedFile: " + Filename, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Destroy();
					return;
				}

				MappingAddress = MapViewOfFile(FileHandle, FILE_MAP_ALL_ACCESS, 0, 0, 0);

				if (MappingAddress == IntPtr.Zero) {
					MessageBox.Show("Unable to map the MemoryMappedFile: " + Filename, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Destroy();
					return;
				}

				FileLength = Length;
			}

            ~MemoryMappedFile()
			{
				Destroy();
				//base.Finalize();
			}

			internal void Destroy()
			{
				if (MappingAddress != IntPtr.Zero) {
					UnmapViewOfFile(MappingAddress);
				}
				if (FileHandle != 0) {
					CloseHandle(FileHandle);
					FileHandle = 0;
				}
			}


            // ---------------------------------------------------------------------------- read write
			internal void WriteSingle(Int32 Offset, float Value)
			{
				if (MappingAddress == IntPtr.Zero) return; 
				if (Offset < 0 || Offset >= FileLength) return; 
				Int32 i = BitConverter.ToInt32(BitConverter.GetBytes(Value), 0);
				Marshal.WriteInt32(MappingAddress, Offset, i);
			}

			internal float ReadSingle(Int32 Offset)
			{
				if (MappingAddress == IntPtr.Zero) return 0; 
				if (Offset < 0 || Offset >= FileLength) return 0; 
				Int32 i = Marshal.ReadInt32(MappingAddress, Offset);
				return BitConverter.ToSingle(BitConverter.GetBytes(i), 0);
			}
		}
	}



    //static class MemoryMappedFiles_Unix
    //{

        //public static void MemoryMappedFile_Init_Unix()
        //{
        //    MMF1_Unix = new MemoryMappedFile_Unix();
        //}

        //public static float ReadSlot_Unix(Int32 Slot)
        //{
        //    return MMF1_Unix.ReadSlot(Slot);
        //}

        //public static float ReadSlot_NoNan_Unix(Int32 Slot)
        //{
        //    float n = MMF1_Unix.ReadSlot(Slot);
        //    if (float.IsNaN(n)) n = 0;
        //    return n;
        //}

        //public static void WriteSlot_Unix(Int32 Slot, float Value)
        //{
        //    MMF1_Unix.WriteSlot(Slot, Value);
        //}

        //public static void MemoryMappedFile_FillWithNanSleep_Unix()
        //{
        //    for (Int32 i = 0; i <= 999; i++)
        //    {
        //        MMF1_Unix.WriteSlot(i, ThereminoSlots.NAN_Sleep);
        //    }
        //}


    // ======================================================================================
    //   CLASS MemoryMappedFile_Unix
    // ======================================================================================
    public class MemoryMappedFile_Unix
    {

        [DllImport("ThereminoSlots")]
        private static extern int the_slot_init();

        [DllImport("ThereminoSlots")]
        private static extern int the_slot_exit();

        [DllImport("ThereminoSlots")]
        private static extern void the_slot_write(int slot, float value);

        [DllImport("ThereminoSlots")]
        private static extern float the_slot_read(int slot);

        // ---------------------------------------------------------------- construction / destruction
        internal MemoryMappedFile_Unix()
        {
            the_slot_init();
        }

        internal void Destroy()
        {
            the_slot_exit();
        }

        ~MemoryMappedFile_Unix()
        {
            Destroy();
            //base.Finalize();
        }


        // ---------------------------------------------------------------- read write
        public void WriteSlot(Int32 Slot, float Value)
        {
            the_slot_write(Slot, Value);
        }

        public float ReadSlot(Int32 Slot)
        {
            return the_slot_read(Slot);
        }

    }

}

