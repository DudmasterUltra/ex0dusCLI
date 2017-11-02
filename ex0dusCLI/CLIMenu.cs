using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex0dusCLI {

    public class CLIMenu {

        public string Title { get; set; }
        public Option[] Options { get; }

        public CLIMenu(Option[] Configuration) {

            Options = Configuration;

        }

        public CLIMenu(string Title, Option[] Configuration) : this(Configuration) {

            this.Title = Title;

        }

        public Option Display() {

            if (Options.Length == 0) {

                return null;

            }
            Print(0);
            int selected = 0;
            ConsoleKeyInfo key;
            while ((key = Console.ReadKey()).Key != ConsoleKey.Enter) {

                if (key.Key == ConsoleKey.UpArrow) {

                    selected--;
                    if (selected == -1) {

                        selected = Options.Length - 1;

                    }

                } else if (key.Key == ConsoleKey.DownArrow) {

                    selected = (selected + 1) % Options.Length;

                }
                Print(selected);

            }
            return Options[selected];

        }

        protected virtual void Print(int Selected) {

            Console.Clear();
            Console.WriteLine(Title);
            Console.WriteLine();

            for (int i = 0; i < Options.Length; i++) {
                
                if (i == Selected) {

                    Console.Write("> ");

                } else {

                    Console.Write("  ");

                }
                Console.WriteLine(Options[i]);

            }

        }

        public class Option {

            public string Name { get; set; }
            public int color { get; set; }

            public Option(string Name) {

                if (Name.Length > Console.WindowWidth - 3) {

                    throw new ArgumentOutOfRangeException("Name must be one line of characters");

                }
                this.Name = Name;

            }

            public override string ToString() {

                return Name;

            }

        }

    }

}
