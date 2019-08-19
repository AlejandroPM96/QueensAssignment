using System;
using System.Collections.Generic;

namespace Queens
{
    class Queen{
        public int row;
        public int column;
        public Boolean checkConflicts(Queen[, ] board, int row, int col) {  
            int i, j;
            //check for left on the row
            for (i = 0; i < col; i++) {  
                if (board[row, i] != null) return false;  
            }
            //chjecking the diagonal on the left and up
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--) {  
                if (board[i, j] != null) return false;  
            }
            //checking on the rigth and up
            for (i = row, j = col; j >= 0 && i < board.GetLength(0) - 1; i++, j--) {  
                if (board[i, j] != null) return false;  
            }  
            return true;
        }
        public void placed(int row, int col){
            this.row=row;
            this.column=col;
        }
    }
    class Board{
        public Queen[,] board;
        public int N;
        public Board(int N){
            this.board = new Queen[N,N];
            this.N = N;
        }
        public void printBoard(Queen[, ] board) {  
            for (int i = 0; i < N; i++) {  
                for (int j = 0; j < N; j++) {
                    if(board[i, j]!=null){
                        Console.Write("1" + " "); 
                    }else{
                        Console.Write("0 ");
                    }
                }  
                Console.Write("\n");
            }  
        }  
        public Boolean theBoardSolver(Queen[, ] board, int col) {  
            //When there is one queen per column it is done
            if (col >= N) {
                return true;
            }  
            //Putting the queens throgth rows
            for (int i = 0; i < N; i++) {
                Queen queenToPlace = new Queen();
                //check if the space is available  
                if (queenToPlace.checkConflicts(board, i, col)) {
                    queenToPlace.placed(i,col);
                    board[i, col] = queenToPlace;
                    //If available ready to put the next one
                    if (theBoardSolver(board, col + 1)){
                        return true;
                    }  
                    // Removing the piece in case the new one is not possible to put
                    board[i, col] = null;  
                }  
            }  
            return false;  
        }  
    }
    class Program {  
        static int N;
        static void Main(string[] args) {
            //size of board or queens to put
            N = 8;
            Queen[, ] board = new Queen[N, N];
            //making the board
            Board board1 = new Board(N);
            if (!board1.theBoardSolver(board, 0)) {  
                Console.WriteLine("No solution");  
            }
            board1.printBoard(board);
        }  
    }  
}
