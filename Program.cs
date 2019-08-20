/*
    Luis Alejandro Peña Montoya A01650535
    Ana Karen Campos Garcia     A01335037

    -Enviroment Analysis:
        -Fully observable: any agent in the board can see the entire board and its contents
        -Cooperative: When one queen can't find a valid place on the board it signals the 
                    previous one to find a new position so that the new one can retry the 
                    positioning
        -Deterministic: Depending on the previous queens a new queen will determine it's new 
                        position
        -Sequential: The decisions of the first queens will affect the next queens positions
        -Static: While a queen is evaluating it's positions the other queens cannot move. And
                if there is no avialable it "restrains" itself until the previous one finds a
                new position
        -Discrete: The system moves throught the steps the queens take on the chess board
        -Unkown: When a queen is placed it doesn't know where the next ones will be placed
 */
using System;

namespace Queens
{
    class Queen{
        //coordinates to know where the queen is placed
        public int row;
        public int column;
        /*
        In this method the queen will check the board for other queens to decide
        if the place where it wants to be is conflicted with another one.
        In case of conflict it will return false.
         */
        public Boolean checkConflicts(Queen[, ] board, int row, int column) {  
            int i, j;
            //check for left on the row
            for (i = 0; i < column; i++) {  
                if (board[row, i] != null) return false;  
            }
            //chjecking the diagonal on the left and up
            for (i = row, j = column; i >= 0 && j >= 0; i--, j--) {  
                if (board[i, j] != null) return false;  
            }
            //checking on the rigth and up
            for (i = row, j = column; j >= 0 && i < board.GetLength(0) - 1; i++, j--) {  
                if (board[i, j] != null) return false;  
            }  
            //no need to check right sides since we are placing the queens from left to rigth
            return true;
        }
        //actually placing the queen
        public void placed(int row, int column){
            this.row=row;
            this.column=column;
        }
        public void unplace(){
            this.row=new int();
            this.column=new int();
        }
    }
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
            itself and signal the past queen to move its position  througth backtraking
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
                        return true;                                //if the queen is able to be palced returns true
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
    class Program {  
        static int N;
        static void Main(string[] args) {
            N = 8;                                  //size of board or queens to put
            Queen[, ] board = new Queen[N, N];      //Array of  Queen objects for the board
            Board board1 = new Board(N);            //making the board
            if (!board1.solveQueens(board, 0)) {    //Start the solution
                Console.WriteLine("No solution"); 
            }else{
                board1.printBoard(board);           //Print solution

            }
        }  
    }  
}
