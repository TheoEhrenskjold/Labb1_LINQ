namespace Labb1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolDBContext())
            {

                var menybool = true; 
                while (menybool) //Huvudmeny
                {
                    Console.Clear();
                    Console.WriteLine("--- Huvudmeny ---");
                    Console.WriteLine("1: Alla lärare som undervisar Matematik");
                    Console.WriteLine("2: Elever med sina lärare");
                    Console.WriteLine("3: Programmering 1");
                    Console.WriteLine("4: Uppdatera ämne");
                    Console.WriteLine("5: Uppdatera lärare");
                    Console.WriteLine("6: Avsluta");
                    switch (Console.ReadLine())
                    {
                        case "1": //Söker upp alla lärare med courseID 1 för att loppa igenom alla lärare som undervisar matte
                            {
                                Console.Clear();
                                var mathTeachers = context.Teacher.Where(t => t.CourseID == 1).ToList();
                                Console.WriteLine("Dessa undervisar Matematik:");
                                foreach (var eacher in mathTeachers)
                                {
                                    Console.WriteLine(eacher.Name);
                                }
                                Console.WriteLine("Tryck Enter för att gå tillbaka till huvudmenyn");
                                Console.ReadKey();
                                break;
                            }

                            
                            case "2": //Joinar ihop lärare och studenter för att kunna loppa igenom och kopplar ihop lärare med respektive elev.
                            {
                                Console.Clear();
                                var EleverochLärare = context.Students
                                .Join(context.Teacher,
                                stu => stu.CourseID,
                                lär => lär.CourseID,
                                (stu, lär) => new
                                {
                                Name = stu.Name,
                                lärName = lär.Name,
                                stuID = stu.CourseID,
                                lärID = lär.CourseID
                                })
                                .ToList();
                                Console.WriteLine("-----------------------------------");

                                foreach (var pair in EleverochLärare)
                                {
                                    Console.WriteLine($"Student Name: {pair.Name}, Teacher Name: {pair.lärName}");
                                }
                                Console.WriteLine("Tryck Enter för att gå tillbaka till huvudmenyn");
                                Console.ReadKey();
                                break;
                            }
                            
                        case "3": //Söker upp programmering1 genom lambda för att se om den svarar med true eller false.
                            {
                                Console.Clear();
                                Console.WriteLine("Finns det en kurs som heter Programmering1");

                                var containsProg1 = context.Course.Any(c => c.Name == "Programmering1");
                                Console.WriteLine(containsProg1);
                                Console.WriteLine("Tryck Enter för att gå tillbaka till huvudmenyn");
                                Console.ReadKey();
                                break;
                            }
                        case "4": //Söker och kollar om det finns en kurs som heter Programmering 1, om true ändra namnet till OOP annars gör inget.
                            {
                                Console.Clear();
                                var subjectToUpdate = context.Course.FirstOrDefault(c => c.Name == "Programmering1");
                                if (subjectToUpdate != null)
                                {
                                    
                                    subjectToUpdate.Name = "OOP";

                                    Console.WriteLine("Programmering1 har nu uppdaterats till OOP");
                                    context.SaveChanges();
                                }
                                else
                                {
                                    Console.WriteLine("Det finns inget ämne som heter Programmering 1");
                                }
                                Console.WriteLine("Tryck Enter för att gå tillbaka till huvudmenyn");
                                Console.ReadKey();
                                break;

                            } 
                            case "5": //Loopa igenom alla elever med courseID 1 för att sedan kunna ändra lärare från anas till reidar.
                            {
                                Console.Clear();
                                var lärarupdate = context.Students.Where(c => c.CourseID == 1);
                                Console.WriteLine("Dessa elver har Anas som lärare idag. Vem ska få Reidar istället?");
                                foreach (var stu in lärarupdate)
                                {
                                    Console.WriteLine(stu.Name);
                                }
                                var input = Console.ReadLine();
                                var stuupdate = context.Students.FirstOrDefault(c => c.Name == input && c.CourseID == 1);
                                if (stuupdate != null)
                                {
                                    stuupdate.CourseID = 2;
                                    context.SaveChanges();
                                    Console.WriteLine($"{stuupdate.Name} har nu bytt till Reidar som lärare");
                                }
                                else
                                {
                                    Console.WriteLine($"Hittade ingen elev med namnet {input}, vänligen försök igen.");
                                }

                                Console.WriteLine("Tryck Enter för att gå tillbaka till huvudmenyn");
                                Console.ReadKey();
                                break;
                            }
                            case "6": { menybool = false; } //Avsluta programmet.
                            break;
                            
                    }
                }              

            }           
           
        }
    }
}
