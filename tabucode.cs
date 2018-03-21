//Procedure: loop all elements
t = F(s)
While t > 0
	t = A(t)
Endwhile



//Procedure: Insert an element (t0, s_A)
t_After = F(s_A)
B(t_After) = t0
A(t0) = t_After
F(s_A) = t0
C_ID(t0) = s_A



//Procedure: Drop an element (t0, s_0)
t_Before = B(t0)
t_After = A(t0)
A(t_Before) = t_After
B(t_After) = t_Before
If t_Before = 0 then
	F(s_0) = t_After
Endif



//Procedure: Updating move value
For t=1 to N_p
	//consider dropping t from s_0 (to select t = t0)
	tmpVal = AddVal(t, s_0) - Score(t, t0)
	AddVal(t,s_0) = tmpVal 

	//consider adding t to s_A (to select t = t0)
	tmpVal = AddVal(t,s_A) + Score(t,t0)
	AddVal(t,s_A) = tmpVal
	Update MoveVal(t,s_0) and MoveVal(t,s_A) //by (2.25)
Endfor
//Note: the foregoing holds for t = t0 since Score(t0,t0) = 0.
Update MoveVal(t0,s) //by (2.25), s = 1 ... N_s



//Procedure: Create 2-element clusters
For s = 1 to N_s
	bestVal = BIG

	For each t0 in C(0)
		select t1 and t2 using the 2-element selection strategy
		tmpVal = Score(t0,t1) + Score(t0,t2) + Score(t1,t2)
		If(tmpVal < bestVal)
			bestElem1 = t0
			bestElem1 = t1
		Endif
	Endfor

	Insert an element(bestElem1,s)
	Insert an element(bestElem2,s)
	Drop an element(bestElem1,0)
	Drop an element(bestElem2,0)

Endfor




//Procedure: Create initial solution
Create 2-element clusters
//fill elements to attain the low bound of each cluster
For s = 1 to N_s
	If (n(s) < LB(s))
		Do
			Find an element to t0 that minimizes MoveVal(t0,s)
			Insert an element(t0,s)
			Drop an element(t0,0)
		Until (n(s) >= LB(s))
	Endif
Endif

t0 = F(0)
While(t0 is not null)
	bestVal = BIG
	For s = 1 to N_s
		If (n(s) < UB(s))
			If (MoveVal(t0,s) < bestVal)
				bestVal = moveVal(t0,s)
				bestCluster = s
			Endif
		Endif
	Endfor

	Insert an element(t0, bestCluster)
	Drop an element(t0, 0)
	t0 = A(t0)
Endwhile
//For all cluster computing (2.8) and 2.10 with origial alpha1 and alpha 2 
//Computing (2.11)




//Procedure: Tabu Search procedure(bestObjVal)
//initialization phase

TabuEnd(t,s) = 0 //for all elements t and clusters C(s)
Compute AddVal(t,s) //for all elements t and clusters C(s)
curObjVal = bestObjVal
T_s_size and T_size //upon the methodology described in the above section
candList = 20% //of total moves (t -> s) that are randomly selected
For iter = 1 to loopLimit
	While(tabuIter < tabuLoopLimit)
		bestVal = BIG
		For i = 1 to SizeOf(candList)
			t0 -> s_A = candList[i]
			If(t0 -> s_A is feasible)
				If(DelObjVal < bestVal)
					If(t0 -> s_A is not tabu)
						best_t = t0
						best_s = s_A
						best_s0 = s_0

					Else
						If(DelObjVal + curObjVal < bestObjVal)
						//override tabu status
							best_t = t0
							best_s = s_A
							best_s0 = s_0
						Endif
					Endif

					bestVal = DelObjVal
				Endif
			Endif
		Endfor

		If(bestVal < BIG)
			Insert an element(best_t, best_s)
			Drop an element(best_t, best_s0)
			
			curObjVal = DelObjVal + curObjVal
			If(curObjVal < bestObjVal)
				bestObjVal = curObjVal
				tabuIter = 0
			Endif

			//Update move value for impacted clusters and elements

		Endif
		tabuIter++
		candList = //moves selected upon (2.27)
	Endwhile

	//diversification procedure
	//Perform Diversification procedure describe above
	//TabuEnd(t,s) = 0 for all elements t and Clusters C(s)
Endfor













