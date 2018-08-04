/*
*
* Maneuver.cs
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

using SAXWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KeyReBind {

    public class Maneuver {
        private List<Binding> b;

        public delegate void Send(List<Tuple<Keys, bool>> arg);

        private Send s;

        public void SetSendDelegate(Send arg) {
            s = arg;
        }

        public Maneuver(string path) {
            b = new List<Binding>();

            Init(Path.GetDirectoryName(path), Path.GetFileName(path));
        }

        private void Init(string arg1dir, string arg2file) {
            XReader x = new XReader();
            x.SetDirectory(arg1dir);
            x.SetFileName(arg2file);
            x.Parse();

            x.GetNode().GetChildren()[0].GetChildren().ForEach(item => {
                AddBinding(item);
            });
        }

        private void AddBinding(NodeEntity arg) {
            if (@"Binding".Equals(arg.GetNodeName())) {
                Keys addKey = StringToKey(arg.Find(@"BindFrom").Find(@"Key").GetNodeValue());
                bool isUp = bool.Parse(arg.Find(@"BindFrom").Find(@"IsUp").GetNodeValue());
                Binding add = new Binding(addKey, isUp);
                arg.Find(@"BindTo").GetChildren().ForEach(item => {
                    Keys childKey = StringToKey(item.Find(@"Key").GetNodeValue());
                    bool childIsUp = bool.Parse(item.Find(@"IsUp").GetNodeValue());
                    add.Add(childKey, childIsUp);
                });
                b.Add(add);
            }
        }

        public bool HookProc(Keys arg1k, bool arg2up) {
            foreach (Binding item in b) {
                if (arg1k == item.GetBindFrom() && arg2up == item.BindFromIsUp()) {
                    s(item.GetAll());
                    return true;
                }
            }
            return false;
        }

        private Keys StringToKey(string arg) {
            switch (arg) {
                case @"A":
                    return Keys.A;

                case @"B":
                    return Keys.B;

                case @"C":
                    return Keys.C;

                case @"D":
                    return Keys.D;

                case @"E":
                    return Keys.E;

                case @"F":
                    return Keys.F;

                case @"G":
                    return Keys.G;

                case @"H":
                    return Keys.H;

                case @"I":
                    return Keys.I;

                case @"J":
                    return Keys.J;

                case @"K":
                    return Keys.K;

                case @"L":
                    return Keys.L;

                case @"M":
                    return Keys.M;

                case @"N":
                    return Keys.N;

                case @"O":
                    return Keys.O;

                case @"P":
                    return Keys.P;

                case @"Q":
                    return Keys.Q;

                case @"R":
                    return Keys.R;

                case @"S":
                    return Keys.S;

                case @"T":
                    return Keys.T;

                case @"U":
                    return Keys.U;

                case @"V":
                    return Keys.V;

                case @"W":
                    return Keys.W;

                case @"X":
                    return Keys.X;

                case @"Y":
                    return Keys.Y;

                case @"Z":
                    return Keys.Z;

                case @"LShift":
                    return Keys.LShiftKey;

                case @"RShift":
                    return Keys.RShiftKey;

                case @"LCtrl":
                    return Keys.LControlKey;

                case @"RCtrl":
                    return Keys.RControlKey;

                case @"Space":
                    return Keys.Space;

                case @"NumPad0":
                    return Keys.NumPad0;

                case @"NumPad1":
                    return Keys.NumPad1;

                case @"NumPad2":
                    return Keys.NumPad2;

                case @"NumPad3":
                    return Keys.NumPad3;

                case @"NumPad4":
                    return Keys.NumPad4;

                case @"NumPad5":
                    return Keys.NumPad5;

                case @"NumPad6":
                    return Keys.NumPad6;

                case @"NumPad7":
                    return Keys.NumPad7;

                case @"NumPad8":
                    return Keys.NumPad8;

                case @"NumPad9":
                    return Keys.NumPad9;

                default:
                    return Keys.None;
            }
        }

        private class Binding {
            private Element bindFrom;

            private List<Element> bindTo;

            public Binding(Keys arg1, bool arg2) {
                bindFrom = new Element(arg1, arg2);
                bindTo = new List<Element>();
            }

            public void Add(Keys arg1, bool arg2) {
                bindTo.Add(new Element(arg1, arg2));
            }

            public Keys GetBindFrom() {
                return bindFrom.GetKey();
            }

            public bool BindFromIsUp() {
                return bindFrom.IsUp();
            }

            public int Count() {
                return bindTo.Count;
            }

            public Keys GetBindTo(int arg) {
                if (bindTo.Count < arg + 1) {
                    return Keys.None;
                }
                return bindTo[arg].GetKey();
            }

            public bool BindToIsUp(int arg) {
                if (bindTo.Count < arg + 1) {
                    return false;
                }
                return bindTo[arg].IsUp();
            }

            public List<Tuple<Keys, bool>> GetAll() {
                List<Tuple<Keys, bool>> ret = new List<Tuple<Keys, bool>>();
                bindTo.ForEach(item => {
                    Tuple<Keys, bool> add = new Tuple<Keys, bool>(item.GetKey(), item.IsUp());
                    ret.Add(add);
                });
                return ret;
            }

            private class Element {
                private Keys k;

                private bool isUp;

                public Keys GetKey() {
                    return k;
                }

                public bool IsUp() {
                    return isUp;
                }

                public Element(Keys arg1, bool arg2) {
                    k = arg1;
                    isUp = arg2;
                }
            }
        }
    }
}