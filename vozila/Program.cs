using NLog;
using NLog.Targets;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace vozila
{
    class Program
    {
        public static string ConnectionString = "Server=tcp:omegavjezba.database.windows.net;Database=prviApp;User ID =omega-user@omegavjezba;Password=Karlovac1992;Trusted_Connection=False;Encrypt =True;";


        static void Main(string[] args)
        {
            //GlobalDiagnosticsContext.Set("connectionString", "Server=tcp:omegavjezba.database.windows.net;Database=prviApp;User ID =omega-user@omegavjezba;Password=Karlovac1992;Trusted_Connection=False;Encrypt =True;");

            //InitializeVehicles();
            //InitializePeople();
            //InitializeLicenses();
            //InitializePeopleLicense();
            while (true)
            {
                switch (CourseOfAction("For calling a method give method number & press enter: \n1. Return people\n2. Return vehicles\n3. Add \n4. Delete\n0. Exit"))
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        switch (CourseOfAction("For calling a method give method number & press enter: \n1. Return drivers\n2. Return pilots\n3. Return people\n0. Exit\n*. Back"))
                        {
                            case 0:
                                Environment.Exit(0);
                                break;
                            case 1:
                                PrintDrivers();
                                break;
                            case 2:
                                PrintPilots();
                                break;
                            case 3:
                                PrintPeople();
                                break;
                            default:
                                break;
                        }

                        break;
                    case 2:
                        switch (CourseOfAction("For calling a method give method number & press enter: \n1. Return driving vehicles\n2. Return flying vehicles\n3. Return all vehicles\n0. Exit\n*. Back"))
                        {
                            case 0:
                                Environment.Exit(0);
                                break;
                            case 1:
                                PrintDrivingVehicles();
                                break;
                            case 2:
                                PrintFlyingVehicles();
                                break;
                            case 3:
                                PrintAllVehicles();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        switch (CourseOfAction("For calling a method give method number & press enter: \n1. Add vehicle\n2. Add person\n0. Exit\n*. Back"))
                        {
                            case 0:
                                Environment.Exit(0);
                                break;
                            case 1:
                                AddVehicle();
                                break;
                            case 2:
                                AddPerson();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 4:
                        switch (CourseOfAction("For calling a method give method number & press enter: \n1. Delete vehicle\n2. Delete person\n0. Exit\n*. Back"))
                        {
                            case 0:
                                Environment.Exit(0);
                                break;
                            case 1:
                                DeleteVehicle();
                                break;
                            case 2:
                                DeletePerson();
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

        }

        private static int CourseOfAction(string question)
        {


            Console.Clear();
            Console.WriteLine(question);
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException ex)
            {
                loggerdb.Error(ex, "upisan je nebroj");
                return -1;
            }

        }


        #region printpersons 

        private static void PrintPeople()
        {
            Console.Clear();
            Console.WriteLine("This is a list of people:");

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT O.Ime FROM dbo.Osoba AS O", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
                conn.Close();
            }
            //Console.WriteLine(string.Join(", ", People.Select(person => person.Name))); 
            //Console.WriteLine();
            //foreach (Person person in People)
            //{
            //    Console.WriteLine(person.Name);
            //}
            Console.ReadLine();
        }

        private static void PrintDrivers()
        {
            Console.Clear();
            Console.WriteLine("this is a list of drivers:");

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT O.Ime FROM dbo.Osoba AS O INNER JOIN dbo.Dozvola AS D ON O.Ime = D.Ime INNER JOIN dbo.VrstaVozila AS VV ON D.IDVrstaVozila = VV.ID WHERE VV.Kategorija LIKE 'kopneno' ", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
                conn.Close();
            }

            //string driversList = string.Join(", ", PeopleLicense.Where(personWithLicense => personWithLicense.Licenses.Any(licence => licence.CategoryType == "driver"))
            //    .Select(personWithLicense => personWithLicense.Person.Name));
            //Console.WriteLine(driversList);

            //foreach (PersonLicense personWithLicense in PeopleLicense)
            //{
            //    foreach (DriversLicense license in personWithLicense.Licenses)
            //    {
            //        if (license.CategoryType == "driver")
            //        {
            //            Console.WriteLine(personWithLicense.Person.Name);
            //        }
            //    }

            //}


            Console.ReadLine();
        }

        private static void PrintPilots()
        {
            Console.Clear();
            Console.WriteLine("This is a list of pilots:");

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT O.Ime FROM dbo.Osoba AS O INNER JOIN dbo.Dozvola AS D ON O.Ime = D.Ime INNER JOIN dbo.VrstaVozila AS VV ON D.IDVrstaVozila = VV.ID WHERE VV.Kategorija LIKE 'zrakoplov' ", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
                conn.Close();
            }

            //var pilots = PeopleLicense.Where(personWithLicense => personWithLicense.Licenses.Any(licence => licence.CategoryType == "pilot"))
            //    .Select(personWithLicense => personWithLicense.Person.Name);

            //string pilotsList = string.Join(", ", pilots);
            //Console.WriteLine(pilotsList);

            //foreach (PersonLicense personWithLicense in PeopleLicense)
            //{
            //    foreach (DriversLicense license in personWithLicense.Licenses)
            //    {
            //        if (license.CategoryType == "pilot")
            //        {
            //            Console.WriteLine(personWithLicense.Person.Name);
            //        }
            //    }
            //}            
            Console.ReadLine();
        }


        #endregion


        #region printvehicles

        private static void PrintAllVehicles()
        {
            Console.Clear();
            Console.WriteLine("This is a list of all vehicles:");

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT V.Ime FROM dbo.Vozilo AS V", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
                conn.Close();
            }


            //Console.WriteLine(string.Join(", ", Vehicles.Select(x => x.Name)));

            //foreach (Vehicle vehicle in Vehicles)
            //{
            //    Console.WriteLine(vehicle.Name);                
            //}
            Console.ReadLine();
        }

        private static void PrintFlyingVehicles()
        {
            Console.Clear();
            Console.WriteLine("This is a list of flying vehicles:");

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT V.Ime FROM dbo.Vozilo AS V INNER JOIN dbo.VrstaVozila AS VV ON V.IDVrstaVozila = VV.ID WHERE VV.Kategorija LIKE 'zrakoplov'", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
                conn.Close();
            }

            //Console.WriteLine(string.Join(", ", Vehicles.Where(x => x is Flying).Select(x => x.Name)));

            //foreach (Vehicle vehicle in Vehicles)
            //{
            //    if (vehicle is Flying)
            //    {
            //        Console.WriteLine(vehicle.Name);
            //    }
            //}
            Console.ReadLine();
        }

        private static void PrintDrivingVehicles()
        {
            Console.Clear();
            Console.WriteLine("This is a list of driving vehicles:");

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT V.Ime FROM dbo.Vozilo AS V INNER JOIN dbo.VrstaVozila AS VV ON V.IDVrstaVozila = VV.ID WHERE VV.Kategorija LIKE 'kopneno'", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
                conn.Close();
            }

            //Console.WriteLine(string.Join(", ", Vehicles.Where(x => x is Driving).Select(x => x.Name)));
            //foreach(Vehicle vehicle in Vehicles)
            //{
            //    if(vehicle is Driving)
            //    {
            //        Console.WriteLine(vehicle.Name);
            //    }
            //}
            Console.ReadLine();
        }
        #endregion


        //#region initialization

        //private static void InitializeVehicles()
        //{
        //    Vehicles = new List<Vehicle>()
        //    {
        //        new Tank("tank1", 100, 3, "grey", 20, "tank1 grenadetype"),
        //        new Tank("tank2", 100, 3, "grey", 20, "tank1 grenadetype"),
        //        new Airplane("airplane1", 1000, 100, "white", 2, "reverse"),
        //        new Airplane("airplane2", 1500, 500, "yellow", 4, "forwardfacing"),
        //        new Helicopter("helicopter1", 500, 10, "green", 6, "elastic"),
        //        new Helicopter("helicopter2", 600, 15, "red", 3, "rigid")
        //    };
        //}

        //private static void InitializePeople()
        //{
        //    People = new List<Person>()
        //    {
        //        new Person("Ivan", 30),
        //        new Person("Ante", 40),
        //        new Person("Željka", 50),
        //        new Person("Bojana", 60),
        //        new Person("Neven", 70)

        //    };
        //}

        //private static void InitializeLicenses()
        //{
        //    Licenses = new List<DriversLicense>()
        //    {
        //       new DriversLicense(100, 0, new DateTime(10 / 12 / 2018)),
        //       new DriversLicense(101, 0, new DateTime(10 / 12 / 2019)),
        //       new DriversLicense(102, 0, new DateTime(10 / 12 / 2020)),
        //       new DriversLicense(103, 0, new DateTime(10 / 12 / 2020)),
        //       new DriversLicense(104, 0, new DateTime(01 / 12 / 2018)),
        //       new DriversLicense(200, 1, new DateTime(10 / 12 / 2023)),
        //       new DriversLicense(201, 1, new DateTime(10 / 12 / 2022))

        //};
        //}
        //private static void InitializePeopleLicense()
        //{
        //    PeopleLicense = new List<PersonLicense>()
        //    {
        //        new PersonLicense(People[0], Licenses[0]),
        //        new PersonLicense(People[1], Licenses[1]),
        //        new PersonLicense(People[2], Licenses[2]),
        //        new PersonLicense(People[3], Licenses[3]),
        //        new PersonLicense(People[4], Licenses[6])
        //    };

        //    PeopleLicense[0].AddDriversLicense(Licenses[4]);           

        //}
        //#endregion


        #region logger
        
        private static Logger loggerdb = LogManager.GetLogger("databaseLogger");

        #endregion


        #region addEntities

        private static void AddVehicle()
        {
            string ime, boja;
            int tezina, brojLjudi, iDVrstaVozila, ID;
            Console.WriteLine("Vehicle name: \n");
            ime = Console.ReadLine();
            Console.WriteLine("Vehicle color: \n");
            boja = Console.ReadLine();
            Console.WriteLine("Vehicle tonnage: \n");
            tezina = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of people: \n");
            brojLjudi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("type of vehicle(tank-1/airplane-2/helicopter-3): \n");
            iDVrstaVozila = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand insertCommand = new SqlCommand("INSERT INTO dbo.Vozilo (Ime, Boja, Tezina, BrojLjudi, IDVrstaVozila) VALUES (@0, @1, @2, @3, @4) SELECT SCOPE_IDENTITY()", conn);

                insertCommand.Parameters.Add("@0", SqlDbType.VarChar, 10).Value = ime;

                insertCommand.Parameters.Add("@1", SqlDbType.VarChar, 10).Value = boja;

                insertCommand.Parameters.Add("@2", SqlDbType.Int).Value = tezina;

                insertCommand.Parameters.Add("@3", SqlDbType.Int).Value = brojLjudi;

                insertCommand.Parameters.Add("@4", SqlDbType.Int).Value = iDVrstaVozila;

                conn.Open();
                ID = Convert.ToInt32(insertCommand.ExecuteScalar());
                conn.Close();
            }
            switch (iDVrstaVozila)
            {
                case 1:
                    AddTankInfo(ID);
                    break;
                case 2:
                    AddAirplaneInfo(ID);
                    break;
                case 3:
                    AddHelicopterInfo(ID);
                    break;
            }
            loggerdb.Info("dodano vozilo");
        }
        private static void AddTankInfo(int ID)
        {
            int duljinaCijevi, prosjecnoVrijemeVoznje;
            string tipMunicije;
            Console.WriteLine("Duljina cijevi:");
            duljinaCijevi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Prosjecno vrijeme voznje:");
            prosjecnoVrijemeVoznje = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Tip municije:");
            tipMunicije = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                SqlCommand tankCommand = new SqlCommand("INSERT INTO dbo.Tenk (ID, DuljinaCijevi, TipMunicije) VALUES (@0, @1, @2)", conn);
                SqlCommand kopneniCommand = new SqlCommand("INSERT INTO dbo.Kopneni (ID, ProsjecnoVrijemeVoznje) VALUES (@0, @1)", conn);

                tankCommand.Parameters.Add("@0", SqlDbType.Int).Value = ID;

                tankCommand.Parameters.Add("@1", SqlDbType.Int).Value = duljinaCijevi;

                tankCommand.Parameters.Add("@2", SqlDbType.VarChar, 30).Value = tipMunicije;

                kopneniCommand.Parameters.Add("@0", SqlDbType.Int).Value = ID;

                kopneniCommand.Parameters.Add("@1", SqlDbType.Int).Value = prosjecnoVrijemeVoznje;

                conn.Open();
                tankCommand.ExecuteNonQuery();
                kopneniCommand.ExecuteNonQuery();
                conn.Close();

                Console.ReadLine();

            }
        }
        private static void AddHelicopterInfo(int ID)
        {
            int brojKrakovaRotora, prosjecnoVrijemeLeta;
            string tipKrakovaRotora;
            Console.WriteLine("Broj krakova rotora:");
            brojKrakovaRotora = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Prosjecno vrijeme leta:");
            prosjecnoVrijemeLeta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Tip krakova rotora:");
            tipKrakovaRotora = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                SqlCommand heliCommand = new SqlCommand("INSERT INTO dbo.Helikopter (ID, BrojKrakovaRotora, TipKrakovaRotora) VALUES (@0, @1, @2)", conn);
                SqlCommand leteciCommand = new SqlCommand("INSERT INTO dbo.Leteci (ID, ProsjecnoVrijemeLeta) VALUES (@0, @1)", conn);

                heliCommand.Parameters.Add("@0", SqlDbType.Int).Value = ID;

                heliCommand.Parameters.Add("@1", SqlDbType.Int).Value = brojKrakovaRotora;

                heliCommand.Parameters.Add("@2", SqlDbType.VarChar, 30).Value = tipKrakovaRotora;

                leteciCommand.Parameters.Add("@0", SqlDbType.Int).Value = ID;

                leteciCommand.Parameters.Add("@1", SqlDbType.Int).Value = prosjecnoVrijemeLeta;

                conn.Open();
                heliCommand.ExecuteNonQuery();
                leteciCommand.ExecuteNonQuery();
                conn.Close();

                Console.ReadLine();
            }
        }
        private static void AddAirplaneInfo(int ID)
        {
            int brojMotora, prosjecnoVrijemeLeta;
            string tipKrila;
            Console.WriteLine("Broj Motora:");
            brojMotora = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Prosjecno vrijeme leta:");
            prosjecnoVrijemeLeta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Tip Krila:");
            tipKrila = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                SqlCommand avionCommand = new SqlCommand("INSERT INTO dbo.Avion (ID, BrojMotora, TipKrila) VALUES (@0, @1, @2)", conn);
                SqlCommand leteciCommand = new SqlCommand("INSERT INTO dbo.Leteci (ID, ProsjecnoVrijemeLeta) VALUES (@0, @1)", conn);

                avionCommand.Parameters.Add("@0", SqlDbType.Int).Value = ID;

                avionCommand.Parameters.Add("@1", SqlDbType.Int).Value = brojMotora;

                avionCommand.Parameters.Add("@2", SqlDbType.VarChar, 30).Value = tipKrila;

                leteciCommand.Parameters.Add("@0", SqlDbType.Int).Value = ID;

                leteciCommand.Parameters.Add("@1", SqlDbType.Int).Value = prosjecnoVrijemeLeta;

                conn.Open();
                avionCommand.ExecuteNonQuery();
                leteciCommand.ExecuteNonQuery();

                conn.Close();

                Console.ReadLine();
            }

        }
        private static void AddPerson()
        {
            string ime;
            int godina, idVrstaVozila;
            DateTime vrijediDo;
            Console.WriteLine("Person name: ");
            ime = Console.ReadLine();
            Console.WriteLine("Godina rodenja: ");
            godina = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dozvola za koju vrstu vozila\ntype of vehicle(tank-1/airplane-2/helicopter-3): \n");
            idVrstaVozila = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Datum trajanje dozvole");
            vrijediDo = Convert.ToDateTime(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                SqlCommand osobaCommand = new SqlCommand("INSERT INTO dbo.Osoba (Ime, Godina) VALUES (@0, @1)", conn);
                SqlCommand dozvolaCommand = new SqlCommand("INSERT INTO dbo.Dozvola (VrijediDo, Ime, IDVrstaVozila) VALUES (@0, @1, @2)", conn);

                osobaCommand.Parameters.Add("@0", SqlDbType.VarChar, 30).Value = ime;
                osobaCommand.Parameters.Add("@1", SqlDbType.Int).Value = godina;

                dozvolaCommand.Parameters.Add("@0", SqlDbType.DateTime).Value = vrijediDo;
                dozvolaCommand.Parameters.Add("@1", SqlDbType.VarChar, 30).Value = ime;
                dozvolaCommand.Parameters.Add("@2", SqlDbType.Int).Value = idVrstaVozila;

                conn.Open();
                osobaCommand.ExecuteNonQuery();
                dozvolaCommand.ExecuteNonQuery();
                conn.Close();

                Console.ReadLine();
            }
            loggerdb.Info("dodana osoba");
        }
        #endregion


        #region obrisi
        private static void DeleteVehicle()
        {
            Console.WriteLine("give name of vehicle you want to delete");
            string ime = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                SqlCommand vehicleCommand = new SqlCommand("DELETE FROM dbo.Vozilo WHERE Ime LIKE @0", conn);
                vehicleCommand.Parameters.Add("@0", SqlDbType.VarChar, 10).Value = ime;

                conn.Open();
                vehicleCommand.ExecuteNonQuery();
                conn.Close();

                Console.ReadLine();
            }

        }

        private static void DeletePerson()
        {
            Console.WriteLine("give name of person you want to delete");
            string ime = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                SqlCommand personCommand = new SqlCommand("DELETE FROM dbo.Osoba WHERE Ime LIKE @0", conn);
                personCommand.Parameters.Add("@0", SqlDbType.VarChar, 30).Value = ime;

                conn.Open();
                personCommand.ExecuteNonQuery();
                conn.Close();

                Console.ReadLine();
            }
        }

        #endregion
    }
}
