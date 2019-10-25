using System;
using System.Linq;

namespace Przyklady_pojedyncze
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new WynikiA())
            {
                Console.WriteLine("Cześć Franek. Oto przykłady na diś. Po każdym przykładzie wpisz wynik i naciśnij Enter.");
                Console.WriteLine("Ale najpierw zdecyduję ile przykładów będziesz miał...");
                String liczba_a = Console.ReadLine();

                int liczba_b = Convert.ToInt32(liczba_a);
                int dobre = 0;
                for (int n = 0; n < liczba_b; n++)
                {
                    var rand = new Random();
                    int a = rand.Next(50);
                    int b = rand.Next(50);
                    string e = Znak();
                    //tu trzeba wstawić conditional w zależności od wyniku funkcji Znak();
                    if (e == "+")
                    {
                        int wynik_b = a + b;
                        Console.Write(a + "+" + b + "=");
                        string wynik_f = Console.ReadLine();
                        int wynik_a = Convert.ToInt32(wynik_f);
                        if (wynik_b == wynik_a)
                        {
                            Console.WriteLine("Brawo, prawidłowy wynik");
                            dobre++;
                        }
                        else
                        {
                            Console.WriteLine("Niestety zła odpowiedź. Prawidłowy wynik to:" + wynik_b);
                        }
                    }
                    if (e == "-")
                    {
                        if (a >= b)
                        {
                            int wynik_b = a - b;
                            Console.Write(a + "-" + b + "=");
                            string wynik_f = Console.ReadLine();
                            int wynik_a = Convert.ToInt32(wynik_f);
                            if (wynik_b == wynik_a)
                            {
                                Console.WriteLine("Brawo, prawidłowy wynik");
                                dobre++;
                            }
                            else
                            {
                                Console.WriteLine("Niestety zła odpowiedź. Prawidłowy wynik to:" + wynik_b);
                            }
                        }
                        else
                        {
                            int wynik_b = b - a;
                            Console.Write(b + "-" + a + "=");
                            string wynik_f = Console.ReadLine();
                            int wynik_a = Convert.ToInt32(wynik_f);
                            if (wynik_b == wynik_a)
                            {
                                Console.WriteLine("Brawo, prawidłowy wynik");
                                dobre++;
                            }
                            else
                            {
                                Console.WriteLine("Niestety zła odpowiedź. Prawidłowy wynik to:" + wynik_b);
                            }

                        }
                        //int wynik_b = a - b;
                        //Console.Write(a + "-" + b + "=");
                        //string wynik_f = Console.ReadLine();
                        //int wynik_a = Convert.ToInt32(wynik_f);
                        //if (wynik_b == wynik_a)
                        //{
                        //   Console.WriteLine("Brawo, prawidłowy wynik");
                        //  dobre++;
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Niestety zła odpowiedź. Prawidłowy wynik to:" + wynik_b);
                        //}
                    }

                }
                Console.WriteLine("Ilość prawidłowych odpowiedzi to:" + dobre + " na " + liczba_b + " przykładów");
                db.Wyniki.Add(
                    new Grade
                    {
                        GradeValue = Convert.ToString(dobre),
                        Numberofex = liczba_a
                    }
                    ) ;
                db.SaveChanges();
                Console.WriteLine("jeśli chcesz wyświetlić poprzednie wyniki wiśnij p");
                string wysw = Console.ReadLine();
                if (wysw == "p")
                {
                    var lista = db.Wyniki.ToList();
                    foreach (var n in lista)
                    {
                        Console.WriteLine(n.GradeId);
                        Console.WriteLine(n.GradeValue+"/"+n.Numberofex);
                    }
                }
                
                Console.ReadLine();
            }
            static string Znak()
            {
                var randA = new Random();
                int zmiana = randA.Next(2);
                if (zmiana == 0)
                {
                    string plus = "+";
                    return plus;
                }
                else
                {
                    string plus = "-";
                    return plus;
                }
            }
        }
    }
}
