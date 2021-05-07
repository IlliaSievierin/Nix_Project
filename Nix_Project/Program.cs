using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nix_Project
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Hotel hotel = LoadHotel();
            bool n = true;
            while (n)
            {
                Console.Clear();
                Console.WriteLine("-----------------==|Hotel|==-----------------");
                Console.WriteLine("1) Добавить комнату");
                Console.WriteLine("2) Удалить комнату");
                Console.WriteLine("3) Забронировать номер");
                Console.WriteLine("4) Узнать количество свободных номеров на дату");
                Console.WriteLine("5) Зарегестрировать заезд/выезд постояльца");
                Console.WriteLine("6) Сохранить и выйти");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddRoom(hotel);
                        break;
                    case 2:
                        DeleteRoom(hotel);
                        break;
                    case 3:
                        ReservationRoom(hotel);
                        break;
                    case 4:
                        CheckNumberOfFreeRooms(hotel);
                        break;
                    case 5:
                        LodgerCheckInOrOut(hotel);
                        break;
                    case 6:
                        n = false;
                        break;
                    default:
                        Console.WriteLine("Выбор неверный! Повторите попытку.");
                        break;

                }
            }
            SaveHotel(hotel);

        }
        static void AddRoom(Hotel hotel)
        {
            Console.Clear();
            Console.WriteLine("-----------------==|Добавление комнаты|==-----------------");
            try
            {
                Console.Write("Введите номер комнаты: ");
                int number = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите цену за день: ");
                int price = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите количество мест: ");
                int seats = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите категорию: ");
                string category = Console.ReadLine();

                hotel.AddRoom(new Room(number, price, seats, category));
                Console.WriteLine("Комната успешно добавлена, нажмите любую клавишу для продолжения.");
            }
            catch(FormatException)
            {
                Console.WriteLine("Вы ввели неверный формат, комната не добавлена, повторите попытку!");
            }
            
         
            Console.ReadKey();
        }
        static void DeleteRoom(Hotel hotel)
        {
            Console.Clear();
            Console.WriteLine("-----------------==|Удаление комнаты|==-----------------");
            try
            {
                Console.Write("Введите номер комнаты: ");
                int number = Convert.ToInt32(Console.ReadLine());
               
                hotel.DeleteRoom(number);
                Console.WriteLine("Комната успешно удалена, нажмите любую клавишу для продолжения.");
            }
            catch (RoomNotFoundException)
            {
                Console.WriteLine("Указанная комната не существует! Повторите попытку.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели неверный формат, комната не удалена, повторите попытку!");
            }


            Console.ReadKey();
        }
        static void ReservationRoom(Hotel hotel)
        {
            Console.Clear();
            Console.WriteLine("-----------------==|Бронирование комнаты|==-----------------");
            try
            {
                Console.Write("Введите ФИО постояльца: ");
                string fullName = Console.ReadLine();

                Console.Write("Введите дату рождения постояльца (дд/мм/гггг): ");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

                Console.Write("Введите адрес постояльца: ");
                string address = Console.ReadLine();

                Console.Write("Введите номер комнаты: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Room room = hotel.Rooms.Where(r=>r.Number==number).FirstOrDefault();

                Console.Write("Введите дату заселения (дд/мм/гггг): ");
                DateTime arrivalDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Введите дату выселения (дд/мм/гггг): ");
                DateTime departureDate = DateTime.Parse(Console.ReadLine());

                hotel.MakeReservation(new Lodger(fullName, dateOfBirth, address), room, arrivalDate, departureDate);

                Console.WriteLine("Бронь успешно добавлена, нажмите любую клавишу для продолжения.");
            }
            catch (RoomNotFoundException)
            {
                Console.WriteLine("Указанная комната не существует! Повторите попытку.");
            }
            catch (RoomBusyException)
            {
                Console.WriteLine("Указанная комната занята! Повторите попытку.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели неверный формат, комната не удалена, повторите попытку!");
            }


            Console.ReadKey();
        }
        static void CheckNumberOfFreeRooms(Hotel hotel)
        {
            Console.Clear();
            Console.WriteLine("-----------------==|Узнать количество свободных комнат|==-----------------");

            Console.Write("Введите дату заселения (дд/мм/гггг): ");
            DateTime arrivalDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите дату выселения (дд/мм/гггг): ");
            DateTime departureDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"Свободных комнат на выбранный промежуток времени: {hotel.NumberOfFreeRooms(arrivalDate,departureDate)}");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }
        static void LodgerCheckInOrOut(Hotel hotel)
        {
            Console.Clear();
            Console.WriteLine("-----------------==|Регистрация заезда/выезда постояльца|==-----------------");

            try
            {
                Console.Write("Введите ФИО постояльца: ");
                string fullName = Console.ReadLine();

                Console.Write("Введите дату рождения постояльца (дд/мм/гггг): ");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

                Console.Write("Введите адрес постояльца: ");
                string address = Console.ReadLine();

                Console.Write("Введите номер комнаты: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Room room = hotel.Rooms.Where(r => r.Number == number).FirstOrDefault();

                Console.Write("Введите дату заселения (дд/мм/гггг): ");
                DateTime arrivalDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Введите дату выселения (дд/мм/гггг): ");
                DateTime departureDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Если заезд введите 1, выезд - 2 : ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        hotel.CheckIn(new Lodger(fullName, dateOfBirth, address), room, arrivalDate, departureDate);
                        Console.WriteLine("Постоялец успешно зарегестрирован");
                        break;
                    case 2:
                        hotel.CheckOut(new Lodger(fullName, dateOfBirth, address), room, arrivalDate, departureDate);
                        Console.WriteLine("Постоялец успешно выписан");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
            catch(ReservationNotFoundException)
            {
                Console.WriteLine("Бронь не найдена. Поробуйте еще раз.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели неверный формат, комната не удалена, повторите попытку!");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }

        static Hotel LoadHotel()
        {
            if (File.Exists(@"D:/" + "Hotel" + ".dat"))
            {
                Hotel hotel = Serialization.DeserializeFromFile(@"D:/" + "Hotel" + ".dat");
                return hotel;
            }
            return new Hotel();
        }
        static void SaveHotel( Hotel hotel )
        {
            Serialization.SerializeInFile(@"D:/" + "Hotel" + ".dat", hotel);
        }
    }
}
