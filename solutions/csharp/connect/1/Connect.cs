using System;
using System.Collections.Generic;


        public enum ConnectWinner { White, Black, None }

        public class Connect
        {
            public char[,] board;
            public int rows;
            public int cols;

            public Connect(string[] input)
            {
                rows = input.Length;
                cols = 0;

                foreach (string row in input)
                {
                    int usefulCharCount = 0;
                    foreach (char c in row)
                    {
                        if (c == 'O' || c == '.' || c == 'X') usefulCharCount++;
                    }
                    if (usefulCharCount > cols) cols = usefulCharCount;
                }

                board = new char[rows, cols];

                // مقداردهی اولیه با '.' برای جلوگیری از وجود کاراکترهای خالی
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                        board[r, c] = '.';

                for (int r = 0; r < rows; r++)
                {
                    string currentRow = input[r];
                    int currentColInBoard = 0;
                    foreach (char c in currentRow)
                    {
                        if (c == 'X' || c == 'O' || c == '.')
                        {
                            if (currentColInBoard < cols)
                            {
                                board[r, currentColInBoard] = c;
                                currentColInBoard++;
                            }
                        }
                    }
                }
            }

            public ConnectWinner Result()
            {
                if (CheckWinner('O')) return ConnectWinner.White; // بازیکن O (بالا به پایین)
                if (CheckWinner('X')) return ConnectWinner.Black; // بازیکن X (چپ به راست)
                return ConnectWinner.None;
            }

            private bool CheckWinner(char player)
            {
                bool isWhite = (player == 'O');
                HashSet<(int, int)> visited = new HashSet<(int, int)>();
                Queue<(int, int)> queue = new Queue<(int, int)>();

                // ۱. شروع از لبه‌های ابتدایی
                for (int i = 0; i < (isWhite ? cols : rows); i++)
                {
                    int startR = isWhite ? 0 : i;
                    int startC = isWhite ? i : 0;

                    if (board[startR, startC] == player)
                    {
                        queue.Enqueue((startR, startC));
                        visited.Add((startR, startC));
                    }
                }

                // ۲. پیمایش (BFS/DFS) برای پیدا کردن مسیر
                while (queue.Count > 0)
                {
                    var (r, c) = queue.Dequeue();

                    // ۳. چک کردن رسیدن به لبه مقابل
                    if (isWhite && r == rows - 1) return true; // O از بالا به پایین رسید
                    if (!isWhite && c == cols - 1) return true; // X از چپ به راست رسید

                    // ۴. بررسی ۶ همسایه در ساختار Hex
                    int[] dr = { -1, -1, 0, 0, 1, 1 };
                    int[] dc = { 0, 1, -1, 1, -1, 0 };

                    for (int i = 0; i < 6; i++)
                    {
                        int nr = r + dr[i];
                        int nc = c + dc[i];

                        if (nr >= 0 && nr < rows && nc >= 0 && nc < cols &&
                            board[nr, nc] == player && !visited.Contains((nr, nc)))
                        {
                            visited.Add((nr, nc));
                            queue.Enqueue((nr, nc));
                        }
                    }
                }

                return false;
            }
        }
    

