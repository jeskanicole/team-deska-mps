// http://www.sanfoundry.com/c-program-tower-of-hanoi-using-recursion/
// https://www.ibm.com/support/knowledgecenter/en/SSLTBW_2.2.0/com.ibm.zos.v2r2.bpxbd00/clock.htm

#include <stdio.h>
#include <time.h>

void towersOfHanoi(int, char, char, char);
double initial, end; 

int main(){   
    int num = 3;   //number of disks
    printf("\nWelcome to Tower of Hanoi Machine Problem!\n\n");
    printf("You have selected %d number of disks or rings!\n Now, the sequence of action/moves are: ", num); 
    
    initial = (double) clock();  
    initial = initial / CLOCKS_PER_SEC;     //initial time in seconds
    towersOfHanoi(num, 'A', 'C', 'B'); //A, B, and C are the names of the disks
    end = ( ((double) clock()) - initial)/ CLOCKS_PER_SEC;    //second time or end time in seconds
    printf("\nThe elapsed time is %f seconds\n\n", end); //printing of result
    return 0;
}

void towersOfHanoi(int num, char frompeg, char topeg, char auxpeg){ //recursive function
    if (num == 1){
        printf("\n Move disk 1 from peg %c to peg %c", frompeg, topeg); //printing of the move action
        return;
    }
    towersOfHanoi(num - 1, frompeg, auxpeg, topeg);
    printf("\n Move disk %d from peg %c to peg %c", num, frompeg, topeg); //printing of the move action
    towersOfHanoi(num - 1, auxpeg, topeg, frompeg);
}