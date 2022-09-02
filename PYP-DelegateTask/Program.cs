using PYP_DelegateTask;
using PYP_DelegateTask.Models;
using PYP_DelegateTask.Services;
using static PYP_DelegateTask.Enums;

Company company = new Company("Pasha");
while (true)
{
	Console.Clear();
    Helpers.Print("1-Register a user (to company)", ConsoleColor.Cyan);
    Helpers.Print("2-Login in a user (to company)", ConsoleColor.Cyan);
    Helpers.Print("3-See all users in Copany (GetAll)", ConsoleColor.Cyan);
    Helpers.Print("4-Get one User from Company (GetById))", ConsoleColor.Cyan);
    Helpers.Print("5-Update User's datas (UpdateById))", ConsoleColor.Cyan);
    Helpers.Print("6-Delete User from Company(DeleteById))", ConsoleColor.Cyan);
    Helpers.Print("7-Exit", ConsoleColor.Cyan);
    string input = Console.ReadLine();
    if (int.TryParse(input, out int menu)&& menu>=1 &&menu<=7)
    {
        if (menu==7)
        {
            break;
        }
        Menu mainMenu=(Menu)menu;
        switch (mainMenu)
        {
            case Menu.Register:
             
            #region CreateUser
            name:
                Helpers.Print("Name", ConsoleColor.Green);
                string name = Console.ReadLine();
                if (!CheckService.CheckName(name))
                {
                    Helpers.Print("Please correct enter name", ConsoleColor.Red); goto name;
                }
            surname:
                Helpers.Print("Surname", ConsoleColor.Green);
                string surname = Console.ReadLine();
                if (!CheckService.CheckName(surname))
                {
                    Helpers.Print("Please correct enter surname", ConsoleColor.Red); goto surname;
                }
            password:
                Helpers.Print("Password", ConsoleColor.Green);
                string password = Console.ReadLine();
                if (!CheckService.PasswordCheck(password))
                {
                    Helpers.Print("Please correct format password", ConsoleColor.Red); goto password;
                }
                #endregion

                if (!company.Register(name, surname, password))
                {
                    Helpers.SleepErrorAndSuccefuly($"The user {name} {surname} alread exist! please change name or surname", ConsoleColor.Red); goto name;
                }
                Helpers.SleepErrorAndSuccefuly($"The user {name} {surname} Created", ConsoleColor.Green);

                break;
            case Menu.Login:

            #region LoginInfo
            username:
                Helpers.Print("Username", ConsoleColor.Green);
                string username = Console.ReadLine();
                if (!CheckService.CheckName(username))
                {
                    Helpers.Print("Please correct enter username", ConsoleColor.Red); goto username;
                }
            password1:
                Helpers.Print("Password", ConsoleColor.Green);
                password = Console.ReadLine();
                if (!CheckService.PasswordCheck(password))
                {
                    Helpers.Print("Please correct format password", ConsoleColor.Red); goto password1;
                }
                #endregion

                if (!company.Login(username, password))
                {
                    Helpers.SleepErrorAndSuccefuly($"Please write correct username or password ", ConsoleColor.Red); 
                    goto username;
                }
                Helpers.SleepErrorAndSuccefuly($"Welcome {username}", ConsoleColor.Green);
                break;

            case Menu.GetAll:
                #region GettAll
                if (company.GetAll().Count == 0)
                {
                    Helpers.SleepErrorAndSuccefuly($"UserList is Empity ", ConsoleColor.Red);
                }
                foreach (var item in company.GetAll())
                {
                    Helpers.SleepErrorAndSuccefuly($"The User: {item}", ConsoleColor.Green);
                }
                break;
            #endregion

            case Menu.GetById:
                #region UserById
                Helpers.Print("Please Enter User id", ConsoleColor.Green);
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Helpers.Print("please select number type", ConsoleColor.Red); goto case Menu.GetById;
                }
                User user=company.GetById(id);
                if (user == null)
                {
                    Helpers.Print("Bu Id-de user yoxdu!!!", ConsoleColor.Red);
                    goto case Menu.GetById;
                }
                Helpers.SleepErrorAndSuccefuly($"The User: {user}", ConsoleColor.Green);
                #endregion
                break;
            case Menu.UpdateById:
                if (company.ShowUsers().Count==0)
                {
                    Helpers.SleepErrorAndSuccefuly($"UserList is Empity ", ConsoleColor.Red);
                    goto case Menu.UpdateById;
                }
                foreach (var item in company.ShowUsers())
                {
                    Helpers.SleepErrorAndSuccefuly($"The User: {item}", ConsoleColor.Green);
                }
                Helpers.Print("Please Enter User id", ConsoleColor.Green);
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    Helpers.Print("please select number type", ConsoleColor.Red);
                    goto case Menu.UpdateById;
                }
                user = company.GetById(id);
                if (user == null)
                    Helpers.Print("Bu Id-de user yoxdu!!!", ConsoleColor.Red);
                break;
            case Menu.DeleteById:
                break;

        }
    }
    
   
}