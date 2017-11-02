using System.Collections.Generic;

namespace ex0dusCLI {

    public class CLIResult {

        public List<CLI.ResultSwitch> Parsed { get; }
        public List<string> Extra { get; }
        public List<string> Invalid { get; }
        public List<CLI.Switch> Missing { get; }
        public bool HasExtra {

            get {

                return Extra.Count != 0;

            }

        }
        public bool HasInvalid {

            get {

                return Invalid.Count != 0;

            }

        }
        public bool HasMissing {

            get {

                return Missing.Count != 0;

            }

        }
        public bool HasParsed {

            get {

                return Parsed.Count != 0;

            }

        }
        public bool IsEmpty {

            get {

                return Parsed.Count == 0 && Extra.Count == 0;

            }

        }

        public CLIResult(List<CLI.ResultSwitch> Parsed, List<string> Extra, List<string> Invalid, List<CLI.Switch> Missing) {

            this.Missing = Missing;
            this.Extra = Extra;
            this.Parsed = Parsed;

        }

        public CLI.ResultSwitch GetParsed(CLI.Switch Find) {

            return FromSwitches(Find, Parsed);

        }

        public CLI.ResultSwitch GetParsed(string Find) {

            return FromSwitches(Find, Parsed);

        }

        public bool ParsedContains(CLI.Switch Find) {

            return FromSwitches(Find, Parsed) != null;

        }

        public bool ParsedContains(string Find) {

            return FromSwitches(Find, Parsed) != null;

        }

        public bool IsMissing(CLI.Switch Find) {

            return Missing.Contains(Find);

        }

        public bool IsMissing(string Find) {

            foreach (CLI.Switch Switch in Missing) {

                if (Switch.Name.Equals(Find)) {

                    return false;

                }

            }

            return true;

        }

        private static CLI.ResultSwitch FromSwitches(string Find, List<CLI.ResultSwitch> List) {

            foreach (CLI.ResultSwitch Switch in List) {

                if (Switch.Base.Name.Equals(Find)) {

                    return Switch;

                }

            }

            return null;

        }

        private static CLI.ResultSwitch FromSwitches(CLI.Switch Find, List<CLI.ResultSwitch> List) {

            foreach (CLI.ResultSwitch Switch in List) {

                if (Switch.Base.Name.Equals(Find.Name)) {

                    return Switch;

                }

            }

            return null;

        }

    }

}
