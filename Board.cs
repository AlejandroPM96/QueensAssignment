using System;
namespace Queens{
    class Board{
        /*
        Board : the chess board to place the queens
        N : the number of queens that will be placed 
            or the length of the board
         */
        public Queen[,] board;
        public int N;
        //Init
        public Board(int N){
            this.board = new Queen[N,N];
            this.N = N;
        }
        /*Method for printing the board positions of the queens*/
        public void printBoard(Queen[, ] board) {  
            for (int i = 0; i < N; i++) {  
                for (int j = 0; j < N; j++) {
                    if(board[i, j]!=null){
                        Console.Write("Q" + " "); 
                    }else{
                        Console.Write("- ");
                    }
                }  
                Console.WriteLine("\n");
            }  
            Console.WriteLine("*****************");
        }  
        /*
            Solving the problem by placing a Queen per column and iterating the rows,
            If a queen does not find a suitable place in all the rows, it will remove
            itself and signal the past queen to move its position through backtracking
            to retry again its positioning        
         */
        public Boolean solveQueens(Queen[, ] board, int column) {  
            //When there is one queen per column it is done
            if (column >= N) {
                return true;
            }  
            //Iteration to move the current Queen through the board rows
            for (int i = 0; i < N; i++) {
                Queen queenToPlace = new Queen();                   //instantiate new queen
                if (queenToPlace.checkConflicts(board, i, column)) {   //check if the space is available  
                    
                    queenToPlace.placed(i,column);                     //placing the queen
                    board[i, column] = queenToPlace;
                    printBoard(board);

                    if (solveQueens(board, column + 1)){               //Next queen follows up in the next column
                        return true;                                //if the queen is able to be placed returns true
                    }  
                    /*
                        If the next queen is not able to find its spot 
                        we continue the iteration of the rows for a new
                        place to test the next queen
                     */
                    queenToPlace.unplace();
                    board[i, column] = null;                           /* this one does the callback to the previous queens */
                    printBoard(board);                              //just to show the steps on the console
                }else{
                    board[i, column] = queenToPlace;                   //just to show the steps on the console
                    printBoard(board);                              //just to show the steps on the console
                    board[i, column] = null;                           //just to show the steps on the console
                }  
            }
            return false;  //no solution after iterating all columns and all rows without acceptable positions
        }  
    }
}