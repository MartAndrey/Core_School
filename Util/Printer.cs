namespace CoreSchool.Util
{
    public static class Printer
    {
        public static void Menu()
        {
            Console.WriteLine("\nEnter the number of the option you want\n");

            string[] ListMenu = new string[] {
                                                "1. Show school description",
                                                "2. Show courses",
                                                "3. Show subjects",
                                                "4. Show students",
                                                "5. Show evaluations",
                                                "6. Show average by subject",
                                                "7. Show average of one subject",
                                                "8. Show top average by subject",
                                                "9. Show top average of one subject",
                                                "0. End Program"
                                               };

            for (int i = 0; i < ListMenu.Length; i++)
            {
                Console.WriteLine(ListMenu[i]);
            }
        }

        public static void PressEnterOrEsc()
        {
            Console.WriteLine("Press \"ENTER\" to continue or press \"ESC\" to return to the menu");
        }
        public static void PressEnter()
        {
            Console.WriteLine("Press \"ENTER\" for continue");
        }
        public static void DrawLine(int tam = 20)
        {
            Console.WriteLine("".PadLeft(tam, '='));
        }

        public static void WriteTitle(string title)
        {
            int size = title.Length + 4;
            DrawLine(size);
            Console.WriteLine($"| {title} |");
            DrawLine(size);
        }

        public static void Beep(int hz = 2000, int time = 500, int quantity = 1)
        {
            while (quantity-- > 0)
            {
                Console.Beep(hz, time);
            }
        }
    }
}