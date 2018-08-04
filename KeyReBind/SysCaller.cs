/*
*
* SysCaller.cs
*
* Copyright 2018 Yuichi Yoshii
*     吉井雄一 @ 吉井産業  you.65535.kir@gmail.com
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyReBind {

    public static class SysCaller {

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, HOOKPROC lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, uint msg, ref KBDLLHOOKSTRUCT kbdllhookstruct);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA")]
        private extern static int MapVirtualKey(int wCode, int wMapType);

        [DllImport("user32.dll")]
        private extern static void SendInput(int nInputs, Input[] pInputs, int cbsize);

        private delegate IntPtr HOOKPROC(int nCode, uint msg, ref KBDLLHOOKSTRUCT kbdllhookstruct);

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct Input {

            [FieldOffset(0)]
            public int Type;

            [FieldOffset(4)]
            public MouseInput Mouse;

            [FieldOffset(4)]
            public KeyboardInput Keyboard;

            [FieldOffset(4)]
            public HardwareInput Hardware;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MouseInput {
            public int X;
            public int Y;
            public int Data;
            public int Flags;
            public int Time;
            public int ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KeyboardInput {
            public short VirtualKey;
            public short ScanCode;
            public int Flags;
            public int Time;
            public int ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HardwareInput {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        private const int SYS_WH_KEYBORD_LL = 13;

        private static IntPtr handle;

        private static HOOKPROC hookProc;

        private static bool hooking;

        public static bool IsHooking() {
            return hooking;
        }

        public static void Init() {
            hooking = false;
        }

        public static void Hook() {
            if (hooking) {
                return;
            }
            hooking = true;

            hookProc = HookProc;
            handle = SetWindowsHookEx(SYS_WH_KEYBORD_LL, hookProc, Marshal.GetHINSTANCE(typeof(SysCaller).Assembly.GetModules()[0]), 0);
            if (IntPtr.Zero == handle) {
                hooking = false;
                throw new System.ComponentModel.Win32Exception();
            }
        }

        public static void UnHook() {
            if (!hooking) {
                return;
            }
            hooking = false;

            UnhookWindowsHookEx(handle);
            handle = IntPtr.Zero;
            hookProc -= HookProc;
        }

        private const int SYS_KEYBOARD = 1;

        private const int KEYBOARDSTROKE_DOWN = 0x0000;

        private const int KEYBOARDSTROKE_UP = 0x0002;

        private const int KEYBOARD_UNICODE = 0x0004;

        private const int SYS_KEYBOARD_TIME = 0;

        private const int SYS_KEYBOARD_EXTRAINFO = 0;

        public static void Send(List<Tuple<Keys, bool>> arg) {
            List<Input> i = new List<Input>();

            arg.ForEach(item => {
                Input add = new Input();
                add.Type = SYS_KEYBOARD;
                add.Keyboard.Flags = item.Item2 ? KEYBOARDSTROKE_UP | KEYBOARD_UNICODE : KEYBOARDSTROKE_DOWN | KEYBOARD_UNICODE;
                add.Keyboard.VirtualKey = (short)item.Item1;
                add.Keyboard.ScanCode = (short)MapVirtualKey((short)item.Item1, 0);
                add.Keyboard.Time = SYS_KEYBOARD_TIME;
                add.Keyboard.ExtraInfo = SYS_KEYBOARD_EXTRAINFO;
                i.Add(add);
            });

            SendInput(i.Count, i.ToArray(), Marshal.SizeOf(i[0]));
        }

        private static Maneuver m;

        public static void SetManeuver(Maneuver arg) {
            m = arg;
            m.SetSendDelegate(Send);
        }

        private static IntPtr HookProc(int nCode, uint msg, ref KBDLLHOOKSTRUCT s) {
            if (m != null) {
                bool isUp = (0x101 == msg || 0x105 == msg);
                Keys k = (Keys)s.vkCode;
                if (m.HookProc(k, isUp)) {
                    return (IntPtr)1;
                }
            }
            return CallNextHookEx(handle, nCode, msg, ref s);
        }
    }
}