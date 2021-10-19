using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ChoresApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";   
                builder.UserID = "sa";              
                builder.Password = "DefaultPass";      
                builder.InitialCatalog = "ChoresDB";

                using (ChoresList context = new ChoresList(builder.ConnectionString))
                {
                    

                    User newUser = new User { FirstName = "Bob" };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    Console.WriteLine("\nCreated User: " + newUser.ToString());

                    User newUser2 = new User { FirstName = "Jimmy" };
                    context.Users.Add(newUser2);
                    context.SaveChanges();
                    Console.WriteLine("\nCreated User: " + newUser2.ToString());

                    User newUser3 = new User { FirstName = "Allison" };
                    context.Users.Add(newUser3);
                    context.SaveChanges();
                    Console.WriteLine("\nCreated User: " + newUser3.ToString());

                    Chores newChores = new Chores() { ChoreName = "Dishes" };
                    context.Chores.Add(newChores);
                    context.SaveChanges();
                    Console.WriteLine("\nCreated Chores: " + newChores.ToString());

                    Chores newChores2 = new Chores() { ChoreName = "Garbage" };
                    context.Chores.Add(newChores2);
                    context.SaveChanges();
                    Console.WriteLine("\nCreated Chores: " + newChores2.ToString());

                    Chores newChores3 = new Chores() { ChoreName = "Floors" };
                    context.Chores.Add(newChores3);
                    context.SaveChanges();
                    Console.WriteLine("\nCreated Chores: " + newChores3.ToString());

                    newChores.ChoreAssignment = newUser;
                    newChores2.ChoreAssignment = newUser2;
                    newChores3.ChoreAssignment = newUser3;
                   
                    context.SaveChanges();
                    Console.WriteLine("\nAssigned Chores: '" + newChores.ChoreName + "' to user '" + newUser.GetName() + "'");
                    Console.WriteLine("'" + newChores2.ChoreName + "' to user '" + newUser2.GetName() + "'");
                    Console.WriteLine("'" + newChores3.ChoreName + "' to user '" + newUser3.GetName() + "'");
                    var query = from t in context.Chores
                                where 
                                t.ChoreAssignment.FirstName.Equals("Bob") ||
                                t.ChoreAssignment.FirstName.Equals("Jimmy") ||
                                t.ChoreAssignment.FirstName.Equals("Allison")
                                select t;
                    /* foreach (var t in query)
                    {
                        Console.WriteLine(t.ToString());
                    }
                                       
                   List<Chores> ChoressAfterDelete = (from t in context.Chores select t).ToList<Chores>();

                    if (ChoressAfterDelete.Count == 0)
                    {
                        Console.WriteLine("[None]");
                    }
                    else
                    {
                        foreach (Chores t in query)
                        {
                            Console.WriteLine(t.ToString());
                        }
                    }*/
                }
             }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done. Press any key to finish...");
            Console.ReadKey(true);

        }
    }
}
