using System;
using System.Collections.Generic;
using System.Text;

namespace ex0dusCLI {

    public class CLI {

        public char SwitchStyle { get; }
        public Switch[] Switches { get; }

        public CLI(Switch[] Configuration, char SwitchStyle) {

            Switches = Configuration;
            this.SwitchStyle = SwitchStyle;

        }

        public CLI(Switch[] Configuration) : this(Configuration, '-') {}

        public CLIResult Parse(string[] Args) {

            List<ResultSwitch> Out = new List<ResultSwitch>();
            List<string> Invalid = new List<string>();
            List<string> Extra = new List<string>();

            for (int i = 0; i < Args.Length; i++) {

                string Arg = Args[i];
                if (Arg.StartsWith(SwitchStyle.ToString())) {

                    Switch FoundSwitch = GetSwitch(Arg.Substring(1));
                    if (FoundSwitch == null) {

                        Invalid.Add(Arg.Substring(1));

                    } else {
                        
                        if (FoundSwitch.HasValue) {

                            if (i + 1 < Args.Length && !Args[i + 1].StartsWith(SwitchStyle.ToString())) {

                                string SwitchValue = Args[i + 1];
                                i++;
                                Out.Add(new ResultSwitch(FoundSwitch, SwitchValue));

                            } else {

                                Out.Add(new ResultSwitch(FoundSwitch));

                            }

                        } else {

                            Out.Add(new ResultSwitch(FoundSwitch));

                        }

                    }

                } else {

                    Extra.Add(Arg);

                }

            }

            List<Switch> Missing = new List<Switch>();
            foreach (Switch Find in Switches) {

                if (!BaseContains(Find, Out)) {

                    Missing.Add(Find);

                }

            }

            return new CLIResult(Out, Extra, Invalid, Missing);

        }

        private bool BaseContains(Switch one, List<ResultSwitch> List) {

            foreach (ResultSwitch S in List) {

                if (one.Equals(S.Base)) {

                    return true;

                }

            }
            return false;

        }

        public Switch GetSwitch(string Name) {

            foreach (Switch S in Switches) {

                if (S.Name.Equals(Name)) {

                    return S;

                }

            }
            return null;

        }

        public void Splash() {

            Console.WriteLine(Properties.Resources.splash);

        }

        public void Splash(string Title, string Author) {

            char[] titleChar = Title.ToCharArray();
            StringBuilder TitleSpaced = new StringBuilder(Title.Length * 2);
            for (int i = 0; i < Title.Length; i++) {

                TitleSpaced.Append(titleChar[i]);
                TitleSpaced.Append(' ');

            }
            string SplashText = TitleSpaced + "by " + Author;
            int Indent = (40 - (SplashText.Length / 2)) - 20;

            Splash();
            Console.WriteLine();
            Console.WriteLine(new string(' ', Indent) + SplashText);
            Console.WriteLine();
            Console.WriteLine("Usage:");
            foreach (Switch S in Switches) {

                Console.WriteLine(" -" + S.Name + ": " + S.Description);

            }

        }

        public void Pause() {

            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey();

        }

        public class Switch {

            public string Name { get; set; }
            public bool IsRequired { get; set; }
            public bool HasValue { get; set; }
            public string Description { get; set; }

            public Switch(string Name) {

                this.Name = Name;

            }

            public Switch(string Name, string Description) {

                this.Name = Name;

            }

            public override string ToString() {

                return Name;

            }

        }

        public class ResultSwitch {
            
            public Switch Base { get; }
            public string Value { get; }
            public bool HasParsedValue {

                get {

                    return !String.IsNullOrEmpty(Value);

                }

            }

            public ResultSwitch(Switch Base, string Value) {

                this.Base = Base;
                this.Value = Value;

            }

            public ResultSwitch(Switch Base) {

                this.Base = Base;

            }

            public override string ToString() {

                if (HasParsedValue) {

                    return Base.Name + " = " + Value;
                    
                } else {

                    return Base.Name;

                }

            }

        }

    }

}