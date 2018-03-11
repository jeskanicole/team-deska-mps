// http://www.sanfoundry.com/c-program-tower-of-hanoi-using-recursion/
// https://www.ibm.com/support/knowledgecenter/en/SSLTBW_2.2.0/com.ibm.zos.v2r2.bpxbd00/clock.htm

#include <time.h>
#include <stdio.h>
 
void towers(int, char, char, char);
double time1, timedif; 

int main(){   

    int num;
    printf("Enter the number of disks : ");
    scanf("%d", &num);
    printf("The sequence of moves involved in the Tower of Hanoi are :\n");
    
    time1 = (double) clock();            /* get initial time */
    time1 = time1 / CLOCKS_PER_SEC;      /*    in seconds    */

    towers(num, 'A', 'C', 'B');


    /* call clock a second time */
    timedif = ( ((double) clock()) - time1)/ CLOCKS_PER_SEC;
    printf("\nThe elapsed time is %f seconds\n\n", timedif);


    return 0;
}
void towers(int num, char frompeg, char topeg, char auxpeg){
   
    if (num == 1){
        printf("\n Move disk 1 from peg %c to peg %c", frompeg, topeg);
        return;
    }
    towers(num - 1, frompeg, auxpeg, topeg);
    printf("\n Move disk %d from peg %c to peg %c", num, frompeg, topeg);
    towers(num - 1, auxpeg, topeg, frompeg);
}