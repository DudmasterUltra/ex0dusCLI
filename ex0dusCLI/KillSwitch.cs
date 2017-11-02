using System;
using System.IO;
using System.Net.Http;

namespace ex0dusCLI {

    public class KillSwitch {

        private const string KILLSWITCH_URL = "https://raw.githubusercontent.com/DudmasterUltra/Config/master/KillSwitch";

        public static void Validate(string Product) {

            using (HttpClient client = new HttpClient()) {
                
                string response = client.GetAsync(KILLSWITCH_URL).Result.Content.ReadAsStringAsync().Result;
                using (StringReader sr = new StringReader(response)) {

                    string line;
                    while ((line = sr.ReadLine()) != null) {

                        if (line.StartsWith(Product) && !line.EndsWith("true")) {

                            Console.WriteLine("/:-:/.           `-----`          ./:-:/\r\n-/   o`      -+//::----//+o-    ``o   /-\r\n+.    --::--o:           " +
                                " `/o::---    .+\r\n::-:-::.``.d`  E x 0 d u S -y``-:-----:\r\n       `--+s`-             :`m--`       \r\n          -h:`.    ` ` " +
                                "  `..:h`         \r\n          //`smso:.oo+.:+hNo`s:         \r\n         `-s +dsNmshohsmhhd/ y-         \r\n   ....-:-+o  `..`-mNm-" +
                                "`..`  o+:--..-`  \r\n  /-`````-/o+:/y  .s-s`  s+:/+:. ````o  \r\n  -:--  +`    :h//-/:/-++h/   `o  `:-/  \r\n     ::-+      +/:m/N/d/:o" +
                                "     ::-+`    \r\n                /h.` `.h+");
                            Console.WriteLine();
                            foreach (string split in line.Substring(Product.Length + 1).Split(';')) {

                                Console.WriteLine(split);

                            }
                            Console.WriteLine();
                            Console.WriteLine("Thanks for using ex0dus software.");
                            Environment.Exit(0);

                        }

                    }

                }

            }

        }

    }

}
