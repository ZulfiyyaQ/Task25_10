using Newtonsoft.Json;
using task25_10.Exceptions;
using static System.Reflection.Metadata.BlobBuilder;

namespace task25_10
{
    internal class Program
    {
        private static string jsonpath;
        static void Main(string[] args)
        {
            string currentdirectory = Directory.GetCurrentDirectory();
            jsonpath = Path.Combine(currentdirectory, "Name.json");
            if (!File.Exists(jsonpath))
            {
                File.Create(jsonpath).Close();
            }

            

            List<string> names = new List<string>
            {
              "Sebine",
              "Neriman"

            };
            Serialize(names);

            Add("Sabir");
            Console.WriteLine();
            Add("Esmer");
            Console.WriteLine();
            Add("Bextiyar");
            Console.WriteLine();
            if (Search(name => name == "Qabil"))
            {
                Console.WriteLine("Bele telebe telebe var");
            }
            else
            {
                Console.WriteLine("Bele telebe yoxdur.");
            }
            Console.WriteLine();
            Delete("Sabir");
            Console.WriteLine();
            ShowAllNames();




            //Console App elemeye calisdim(((Qizdirmam qalxdi
            //restartSwitch:
            //    Console.WriteLine("**************");
            //    Console.WriteLine("Telebelerin adlari");
            //    Console.WriteLine("**************");
            //    Console.WriteLine("[1] Telebe addlari elave ele");
            //    Console.WriteLine("[2] Telebeni tap");
            //    Console.WriteLine("[3] Telebeni sil");
            //    Console.WriteLine("[4] Butun siyahini goster");
            //    Console.WriteLine("[0] Programdan chix");

            //    string choice = Console.ReadLine();

            //    try
            //    {
            //        switch (choice)
            //        {
            //            case "1":
            //                Console.Clear();
            //                while (true)
            //                {
            //                    Console.Write("Telebenin adini daxil edin:");
            //                    string name = Console.ReadLine().Trim();
            //                    name = char.ToUpper(name[0]) + name.Substring(1).ToLower();


            //                    if (name.Length > 3 && name.Length < 25)
            //                    {
            //                        static void Add(string name)
            //                        {
            //                            List<string> names = Deserialize();
            //                            if (names == null)
            //                            {
            //                                names = new();
            //                            }
            //                            names.Add(name);
            //                            Serialize(names);
            //                            Console.WriteLine($"{name} adli telebe elave edildi");
            //                        }
            //                    }
            //                    else
            //                    {
            //                        throw new WrongInputException("Duzgun deyer daxil edin");
            //                    }
            //                    break;
            //                }
            //                break;
            //            case "2":
            //                Console.Clear();

            //                break;

            //            case "3":
            //                Console.Clear();


            //                break;

            //            case "4":
            //                Console.Clear();
            //                while (true)
            //                {
            //                    static void ShowAllNames()
            //                    {
            //                        List<string> names = Deserialize();
            //                        foreach (var name in names)
            //                        {
            //                            Console.WriteLine($"Telebelerin adlari:{name}");
            //                        }
            //                    }
            //                    break;
            //                }
            //                break;

            //            case "0":

            //                Console.WriteLine("Ugurlar!");
            //                return;

            //            default:
            //                Console.WriteLine("Seciminiz duzgun deyil. Duzgun reqem daxil edin .");

            //                break;
            //        }
            //    }
            //    catch(Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    goto restartSwitch;

        }
        public static void Serialize(List<string> names)
        {
            string result = JsonConvert.SerializeObject(names);

            using (StreamWriter sw = new(jsonpath))
            {
                sw.Write(result);
            }
        }

        public static List<string> Deserialize()
        {
            string result;
            using (StreamReader sr = new(jsonpath))
            {
                result = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<string>>(result);
        }
        public static void Add(string name)
        {
            List<string> names = Deserialize();
            if (names == null)
            {
                names = new();
            }
            names.Add(name);
            Serialize(names);
            Console.WriteLine($"{name} adli telebe elave edildi");
        }
        public static void Delete(string name)
        {
            List<string> names = Deserialize();

            if (names.Contains(name))
            {
                names.Remove(name);
                Console.WriteLine($"{name} adli telebe silindi");
                Serialize(names);
            }
            else
            {
                Console.WriteLine($"{name} adli telebe tapilmadi");
            }
        }
        public static bool Search(Predicate<string> name)
        {
            List<string> names = Deserialize();
            return names.Exists(name);
        }
        public static void ShowAllNames()
        {
            List<string> names = Deserialize();
            foreach (var name in names)
            {
                Console.WriteLine($"Telebelerin adlari:{name}");
            }
        }
    }
}