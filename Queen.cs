using System;
namespace Queens{
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
}