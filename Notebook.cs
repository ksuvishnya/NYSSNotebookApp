using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

namespace NotebookApp
{
    class Notebook
    {
        
        static void Main(string[] args)
        {
            //Note n2 = new Note();
            //Note n3 = new Note();
            //Note.CreateNewNote(n1);
            //Note.CreateNewNote(n2);
            //Note.CreateNewNote(n3);
            //Note.ShowAllNotes();
            Console.WriteLine("Добро пожаловать в Вашу записную книгу.\n\n");
            while (true)
            {
                Console.WriteLine("             Введите номер операции             \n\n");
                Console.WriteLine("0 - Добавить новый контакт\n1-Редактировать контакт\n2-Удалить контакт\n3-Посмотреть информацию о контакте\n4-Посмотреть информацию о всех контактах\n5-Выйти");
                string input = Console.ReadLine();
                int fieldId = 100;
                while (Int32.TryParse(input, out _))
                {
                    fieldId = Int32.Parse(input);
                    if (fieldId < 0 || fieldId > 5)
                    {
                        fieldId = Int32.Parse(input);
                        Console.WriteLine("Неверно. Введите, пожалуйста, число от 0 до 5 включительно.");
                        input = Console.ReadLine();

                    }
                    else { fieldId = Int32.Parse(input); break; }
                }
                while (!Int32.TryParse(input, out _))
                {
                    Console.WriteLine("Неверно. Введите, пожалуйста, число от 0 до 5 включительно.");
                    input = Console.ReadLine();
                    while (Int32.TryParse(input, out _))
                    {
                        fieldId = Int32.Parse(input);
                        if (fieldId < 0 || fieldId > 5)
                        {
                            fieldId = Int32.Parse(input);
                            Console.WriteLine("Неверно. Введите от 0 до 5 включительно");
                            input = Console.ReadLine();

                        }
                        else { fieldId = Int32.Parse(input); break; }
                    }
                }

                switch (fieldId)
                {
                    case 0:
                        Note.CreateNewNote(new Note());
                        break;
                    case 1:
                        if (Note.people.Count == 0)
                        {
                            Console.WriteLine("На данный момент в Вашей книге нет контактов.");
                            break;
                        }
                        Console.WriteLine("Введите id контакта, который хотите редактировать: ");
                        string inputEdit = Console.ReadLine();
                        int tempEdit = 0;
                        while (Int32.TryParse(inputEdit, out _))
                        {
                            tempEdit = Int32.Parse(inputEdit);
                            if (Note.people.Count < tempEdit)
                            {
                                tempEdit = Int32.Parse(inputEdit);
                                Console.WriteLine($"Неверно. Введите, пожалуйста, число от 0 до {Note.people.Count - 1} включительно.");
                                inputEdit = Console.ReadLine();

                            }
                            else { tempEdit = Int32.Parse(inputEdit); break; }
                        }
                        while (!Int32.TryParse(inputEdit, out _))
                        {
                            Console.WriteLine($"Неверно. Введите, пожалуйста, число от 0 до {Note.people.Count - 1} включительно.");
                            inputEdit = Console.ReadLine();
                            while (Int32.TryParse(inputEdit, out _))
                            {
                                tempEdit = Int32.Parse(inputEdit);
                                if (Note.people.Count < tempEdit)
                                {
                                    tempEdit = Int32.Parse(inputEdit);
                                    Console.WriteLine($"Неверно. Введите, пожалуйста, число от 0 до {Note.people.Count - 1} включительно.");
                                    inputEdit = Console.ReadLine();

                                }
                                else { tempEdit = Int32.Parse(inputEdit); break; }
                            }
                        }
                        Note.EditNote(Note.people[tempEdit]);
                        break;
                    case 2:
                        if (Note.people.Count == 0)
                        {
                            Console.WriteLine("На данный момент в Вашей книге нет контактов.");
                            break;
                        }
                        Console.WriteLine("Введите id контакта, который хотите удалить: ");
                        string inputDelete = Console.ReadLine();
                        int tempDelete = 0;
                        while (Int32.TryParse(inputDelete, out _))
                        {
                            tempDelete = Int32.Parse(inputDelete);
                            if (Note.people.Count < tempDelete)
                            {
                                tempDelete = Int32.Parse(inputDelete);
                                Console.WriteLine($"Неверно. Введите, пожалуйста, число от 0 до {Note.people.Count - 1} включительно.");
                                inputDelete = Console.ReadLine();

                            }
                            else { tempDelete = Int32.Parse(inputDelete); break; }
                        }
                        while (!Int32.TryParse(inputDelete, out _))
                        {
                            Console.WriteLine($"Неверно. Введите, пожалуйста, число от 0 до {Note.people.Count - 1} включительно.");
                            inputDelete = Console.ReadLine();
                            while (Int32.TryParse(inputDelete, out _))
                            {
                                tempDelete = Int32.Parse(inputDelete);
                                if (Note.people.Count < tempDelete)
                                {
                                    tempDelete = Int32.Parse(inputDelete);
                                    Console.WriteLine($"Неверно. Введите, пожалуйста, число от 0 до {Note.people.Count - 1} включительно.");
                                    inputDelete = Console.ReadLine();

                                }
                                else { tempDelete = Int32.Parse(inputDelete); break; }
                            }
                        }
                        Note.DeleteNote(Note.people[tempDelete]);
                        break;
                    case 3:
                        if (Note.people.Count == 0)
                        {
                            Console.WriteLine("На данный момент в Вашей книге нет контактов.");
                            break;
                        }
                        Console.WriteLine("Введите id контакта, который хотите просмотреть: ");
                        string inputRead = Console.ReadLine();
                        int tempRead = 0;
                        while (Int32.TryParse(inputRead, out _))
                        {
                            tempRead = Int32.Parse(inputRead);
                            if (Note.people.Count < tempRead)
                            {
                                tempRead = Int32.Parse(inputRead);
                                Console.WriteLine($"Неверно. Введите, пожалуйста, число от 0 до {Note.people.Count - 1} включительно.");
                                inputRead = Console.ReadLine();

                            }
                            else { tempRead = Int32.Parse(inputRead); break; }
                        }
                        while (!Int32.TryParse(inputRead, out _))
                        {
                            Console.WriteLine($"Неверно. Введите, пожалуйста, число от 0 до {Note.people.Count - 1} включительно.");
                            inputRead = Console.ReadLine();
                            while (Int32.TryParse(inputRead, out _))
                            {
                                tempRead = Int32.Parse(inputRead);
                                if (Note.people.Count < tempRead)
                                {
                                    tempRead = Int32.Parse(inputRead);
                                    Console.WriteLine($"Неверно. Введите, пожалуйста, число от 0 до {Note.people.Count - 1} включительно.");
                                    inputRead = Console.ReadLine();

                                }
                                else { tempRead = Int32.Parse(input); break; }
                            }
                        }
                        Note.ReadNote(Note.people[tempRead]);
                        break;
                    case 4:
                        Note.ShowAllNotes();
                        break;
                    case 5:
                        System.Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class Note
    {
        public static int id = 0;
        public static List<Note> people = new List<Note>();
        private string firstName;
        private string lastName;
        private string middleName; // not obligatory
        private string phoneNumber; // digits only
        private string country;
        private string dateOfBirth;
        private string company; // not obligatory
        private string position; // not obligaroty
        private string extraNotes; // not oblugatory
        public static void CreateNewNote(Note n)
        {
            string temp;
            Console.WriteLine("Введите имя (обязательное поле):");
            temp = Console.ReadLine();
            while (temp == "")
            {
                Console.WriteLine("Поле Имя не должно быть пустым. Попробуйте ещё раз.");
                temp = Console.ReadLine();
            }
            n.firstName = temp;
            Console.WriteLine("Введите фамилию (обязательное поле):");
            temp = Console.ReadLine();
            while (temp == "")
            {
                Console.WriteLine("Поле Фамилия не должно быть пустым.. Попробуйте ещё раз.");
                temp = Console.ReadLine();
            }
            n.lastName = temp;
            Console.WriteLine("Введите отчество (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
            n.middleName = Console.ReadLine();
            Console.WriteLine("Введите номер телефона, используя только цифры (обязательное поле):");
            temp = Console.ReadLine();
            while (!IsProperNum(temp))
            {
                Console.WriteLine("Номер введён неверно. Попробуйте ещё раз. Введите номер телефона, используя только цифры.");
                temp = Console.ReadLine();
            }
            n.phoneNumber = temp;
            Console.WriteLine("Введите страну (обязательное поле):");
            temp = Console.ReadLine();
            while (temp == "")
            {
                Console.WriteLine("Поле Страна не должно быть пустым. Попробуйте ещё раз.");
                temp = Console.ReadLine();
            }
            n.country = temp;
            Console.WriteLine("Введите дату рождения в формате дд/мм/гггг (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
            temp = Console.ReadLine();
            while (!IsProperDate(temp))
            {
                Console.WriteLine("Дата рождения введена неверно. Попробуйте ещё раз. Введите дату рождения в формате дд/мм/гггг.");
                temp = Console.ReadLine();
            }
            n.dateOfBirth = temp;
            Console.WriteLine("Введите название компании (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
            n.company = Console.ReadLine();
            Console.WriteLine("Введите должность (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
            n.position = Console.ReadLine();
            Console.WriteLine("Введите дополнительные заметки (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
            n.extraNotes = Console.ReadLine();
            people.Add(n);
            Note.id++;
            Console.WriteLine($"Контакт {n.firstName} {n.lastName} создан с id {Note.id}.");
        }
        public static bool IsProperNum(string s)
        {
            bool res = true;
            if (s == "") res = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (!Char.IsDigit(s[i]))
                {
                    res = false;
                    break; //having one letter is enough for a FALSE flag
                }
            }
            return res;
        }
        public static bool IsProperDate(string s)
        {
            bool flag = true;
            if (s !="" && !DateTime.TryParse(s, out _))
            {
                flag = false;
            }
            return flag;
        }
        public static void EditNote(Note n)
        {
            Console.WriteLine("Что Вы хотите редактировать? Необходимо ввести число от 1 до 9 включительно.\n1-Имя\n2-Фамилия\n3-Отчество\n4-Номер телефона\n5-Страна\n6-День рождения\n7-Название компании\n8-Должность\n9-Дополнительные заметки");
            string input = Console.ReadLine();
            int fieldId = 10000;
            while(Int32.TryParse(input, out _))
            {
                fieldId = Int32.Parse(input);
                if (fieldId <= 0 || fieldId >= 10)
                {
                    fieldId = Int32.Parse(input);
                    Console.WriteLine("Неверно. Введите, пожалуйста, число от 1 до 9 включительно.");
                    input = Console.ReadLine();

                }
                else { fieldId = Int32.Parse(input); break; }
            }
            while (!Int32.TryParse(input, out _))
            {
                Console.WriteLine("Неверно. Введите, пожалуйста, число от 1 до 9 включительно.");
                input = Console.ReadLine();
                while (Int32.TryParse(input, out _))
                {
                    fieldId = Int32.Parse(input);
                    if (fieldId <= 0 || fieldId >= 10)
                    {
                        fieldId = Int32.Parse(input);
                        Console.WriteLine("Неверно. Введите от 1 до 9 включительно");
                        input = Console.ReadLine();

                    }
                    else { fieldId = Int32.Parse(input); break; }
                }
            }
            string temp;
            switch (fieldId)
            {
                
                case 1:
                    Console.WriteLine("Введите новое имя (поле не может быть пустым): ");
                    temp = Console.ReadLine();
                    while (temp == "")
                    {
                        Console.WriteLine("Поле Имя не должно быть пустым. Попробуйте ещё раз.");
                        temp = Console.ReadLine();
                    }
                    n.firstName = temp;
                    break;
                case 2:
                    Console.WriteLine("Введите новую фамилию (поле не может быть пустым): ");
                    temp = Console.ReadLine();
                    while (temp == "")
                    {
                        Console.WriteLine("Поле Фамилия не должно быть пустым. Попробуйте ещё раз.");
                        temp = Console.ReadLine();
                    }
                    n.lastName = temp;
                    break;
                case 3:
                    Console.WriteLine("Введите отчество (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
                    n.middleName = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Введите номер телефона, используя только цифры (обязательное поле):");
                    temp = Console.ReadLine();
                    while (!IsProperNum(temp))
                    {
                        Console.WriteLine("Номер введён неверно. Попробуйте ещё раз. Введите номер телефона, используя только цифры.");
                        temp = Console.ReadLine();
                    }
                    n.phoneNumber = temp;
                    break;
                case 5:
                    Console.WriteLine("Введите страну (обязательное поле):");
                    temp = Console.ReadLine();
                    while (temp == "")
                    {
                        Console.WriteLine("Поле Страна не должно быть пустым. Попробуйте ещё раз.");
                        temp = Console.ReadLine();
                    }
                    n.country = temp;
                    break;
                case 6:
                    Console.WriteLine("Введите дату рождения в формате дд/мм/гггг (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
                    temp = Console.ReadLine();
                    while (!IsProperDate(temp))
                    {
                        Console.WriteLine("Дата рождения введена неверно. Попробуйте ещё раз. Введите дату рождения в формате дд/мм/гггг.");
                        temp = Console.ReadLine();
                    }
                    n.dateOfBirth = temp;
                    break;
                case 7:
                    Console.WriteLine("Введите название компании (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
                    n.company = Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine("Введите должность (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
                    n.position = Console.ReadLine();
                    break;
                case 9:
                    Console.WriteLine("Введите дополнительные заметки (НЕобязательное поле, при желании поле можно оставить пустым, нажав ENTER):");
                    n.extraNotes = Console.ReadLine();
                    break;
                default:
                    break;
            }
            Console.WriteLine("Изменения внесены. :)");

        }
        public static void DeleteNote(Note n)
        {
            Console.WriteLine($"Контакт {n.firstName} {n.lastName} удалён.");
            people.Remove(n);
            Note.id--;
        }
        public static void ReadNote(Note n)
        {
            Console.WriteLine($"Контакт №{people.IndexOf(n)+1}\nИмя - {n.firstName}\nФамилия - {n.lastName}\nНомер телефона - {n.phoneNumber}");
        }
        public static void ShowAllNotes()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("Ваша записная книжка пуста.");
            }
            else
            {
                for (int i = 0; i < people.Count; i++)
                {
                    ReadNote(people[i]);
                }
            }

        }

    }
}
