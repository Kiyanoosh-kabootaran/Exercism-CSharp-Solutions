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
                if (CheckWinner('O')) return ConnectWinner.White; 
                if (CheckWinner('X')) return ConnectWinner.Black; 
                return ConnectWinner.None;
            }

            private bool CheckWinner(char player)
            {
                bool isWhite = (player == 'O');
                HashSet<(int, int)> visited = new HashSet<(int, int)>();
                Queue<(int, int)> queue = new Queue<(int, int)>();

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

                while(queue.Count > 0)
                {
                    var(r , c) = queue.Dequeue();

                    if(isWhite && r == rows -1) return true;
                    if(!isWhite && c == cols -1) return true;

                    int[] dr = { -1, -1, 0, 0, 1, 1 };
                    int[] dc = { 0, 1, -1, 1, -1, 0 };

                    for(int i=0; i < 6; i++)
                    {
                        int nr = r + dr[i];
                        int nc = c + dc[i];

                        if(nr >= 0 && nr < rows && nc >= 0 && nc < cols &&
                           board[nr,nc] == player && !visited.Contains((nr,nc)) )
                        {
                            visited.Add((nr , nc));
                            queue.Enqueue((nr , nc));
                        }
                    }
                    
                }
                return false;
            }
        }
    

