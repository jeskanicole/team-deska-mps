//https://www.geeksforgeeks.org/c-program-for-tower-of-hanoi/

#include <stdio.h>
#include <time.h>

// C recursive function to solve tower of hanoi puzzle
void towerOfHanoi(int n, char from_rod, char to_rod, char aux_rod){
    if (n == 1){
        printf("\n    Move disk 1 from rod %c to rod %c", from_rod, to_rod);
        return;
    }
    towerOfHanoi(n-1, from_rod, aux_rod, to_rod);
    printf("\n    Move disk %d from rod %c to rod %c", n, from_rod, to_rod);
    towerOfHanoi(n-1, aux_rod, to_rod, from_rod);
}

int main(){
    clock_t start_t, end_t;

    start_t = clock();    
    printf("\nWelcome to Tower of Hanoi Machine Problem!");
    printf("\n\nStart of the program. Starting timer...");

    int n = 30; // Number of disks
    towerOfHanoi(n, 'A', 'C', 'B');  // A, B and C are names of rods

    end_t = clock();
    printf("\nEnd of the program. \n\nTotal time: %ld \n", end_t);
    
    return 0;
}
