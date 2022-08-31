namespace Snake_Cs
{
    internal class SnakeBoard
    {
        //Wymiary
        private readonly int[] board = new int[2];


        private Snake snake = new Snake();
        private Fruit fruit = new Fruit();
        public SnakeBoard()
        {
            board[0] = 30;
            board[1] = 15;
            fruit.new_location(board[0], board[1], snake);
        }

        public void printBoard()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('#', board[0]));
            for (int i = 1; i < board[1] - 1; ++i)
                Console.WriteLine("#" + new String(' ', board[0] - 2) + "#");
            Console.WriteLine(new String('#', board[0]));
            snake.print_snake();
            fruit.print_fruit();
            Console.SetCursorPosition(0, board[1] + 1);
        }

        public void logic()
        {
            Console.Beep();
            Console.CursorVisible = false;
            printBoard();
            bool finished = false;
            while (!finished)
            {
                Thread.Sleep(150);
                snake.erease_snake();
                snake.read_input();
                snake.move_snake();
                switch (snake.check_collisions(fruit.location[0], fruit.location[1], board[0], board[1]))
                {
                    case Snake.Collision_type.NOTHING:
                        break;
                    case Snake.Collision_type.FRUIT:
                        fruit.new_location(board[0], board[1], snake);
                        snake.add_tail();
                        break;
                    case Snake.Collision_type.TAIL:
                        finished = true;
                        break;
                    case Snake.Collision_type.WALL:
                        finished = true;
                        break;
                }
                snake.print_snake();
                fruit.print_fruit();
                Console.SetCursorPosition(0, board[1] + 1);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Beep();

        }

    }
}
