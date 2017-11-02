using System;

namespace ex0dusCLI {

    public class CLIAdvMenu : CLIMenu {

        public CLIAdvMenu(Option[] Configuration) : base(Configuration) {}

        public CLIAdvMenu(string Title, Option[] Configuration) : base(Title, Configuration) {}

        protected override void Print(int Selected) {

            Console.Clear();
            Console.WriteLine(Title);
            Console.WriteLine();

            for (int i = 0; i < Options.Length; i++) {

                if (i == Selected) {

                    Console.WriteLine(Options[i]);

                }

            }

        }

        public class ArtOption : Option {

            public string Art { get; set; }

            public ArtOption(string Name, string Art) : base(Name) {

                this.Art = Art;

            }

            public override string ToString() {

                return Art;

            }

        }

    }

}
