/*
    Luis Alejandro Peña Montoya A01650535
    Ana Karen Campos Garcia     A01335037

    -Environment Analysis:
        -Fully observable: any agent in the board can see the entire board and its contents
        -Cooperative: When one queen can't find a valid place on the board it signals the 
                    previous one to find a new position so that the new one can retry the 
                    positioning
        -Deterministic: Depending on the previous queens a new queen will determine it's new 
                        position
        -Sequential: The decisions of the first queens will affect the next queens positions
        -Static: While a queen is evaluating it's positions the other queens cannot move. And
                if there is no available it "restrains" itself until the previous one finds a
                new position
        -Discrete: The system moves through the steps the queens take on the chess board
        -Unkown: When a queen is placed it doesn't know where the next ones will be placed
 */
using System;

namespace Queens
{
    class MainProgram {  
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