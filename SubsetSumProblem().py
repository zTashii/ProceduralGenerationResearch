from random import randint, sample
from itertools import chain, combinations, product
from time import time
import random


#code below provided by Coventry University
#this helped me adapt and learn python quickly as i have not used it in a long time
#but i also created my own methods of generating the set
#i used this code because it generated elements which were above 100 so testing the algorithms with
#large numbers was easier when it generated automatically
class SSP():
    def __init__(self, S=[], t=0):
        self.S = S
        self.t = t
        self.n = len(S)
        self.decision = False
        self.total    = 0
        self.selected = []

    def __repr__(self):
        return "SSP instance: S="+str(self.S)+"\tt="+str(self.t)
    
    def random_instance(self, n, bitlength=10):
        max_n_bit_number = 2**bitlength-1
        self.S = sorted( [ randint(0,max_n_bit_number) for i in range(n) ] , reverse=True)
        self.t = randint(0,n*max_n_bit_number)
        self.n = len( self.S )   

    def random_yes_instance(self, n, bitlength=10):
        max_n_bit_number = 2**bitlength-1
        self.S = sorted( [ randint(0,max_n_bit_number) for i in range(n) ] , reverse=True)
        self.t = sum( sample(self.S, randint(0,n)) )
        self.n = len( self.S )

    ### Algorithm implementation below ###

    def try_at_random(self):
        candidate = []
        total = 0
        while total != self.t:
            candidate = sample(self.S, randint(0,self.n))
            total     = sum(candidate)
            print( "Trying: ", candidate, ", sum:", total )

    def exhaustive_subset_sum(self, A, target):
        count = 1
        solution = []
        while count <= len(A):
            for x in combinations(A, count):
                if sum(x)== target:
                    solution.append(x)
            count += 1
        print ("Combinations: " + str(len(solution)))
        return solution
        

    def dynamic_subset_sum(self, A, target):
        path = [0] * (target + 1)
        path[0] = 1
        nPath = path[:]
        for x in A:
            for j in range(x, target + 1):
                nPath[j] += path[j - x]
            path = nPath[:]
        return path[target]

    def rec_subset_sum(self, A, target):
        solution = []
        def recursive(x, target, sol=()):
            if not x:
                return False
            if x[0] == target:
                solution.append(sol +(x[0],))
            else:
                recursive(x[1:], target-x[0], sol + (x[0],))
                recursive(x[1:], target, sol)
        recursive(A, target)
        return solution

    '''
    theory of the greedy algorithm:
    iterate through the list and compare elements to the target.
    if no value is returned, iterate again but add the position of the list to the previous position
    and then compare, if doesnt match, repeat

    '''

    def greedy_subset_sum_theory(self, A, target): #test code from wikipedia.
        #not actually using this code, i used this to wrap my head around greedy algorithms
        L.append(A[0])
        T = []
        for i in range(1,len(A)):
            T = [(A[i] + y) for y in A]
            U = T + L
            U = sorted(U)
            L.pop()
            y = U[0]
            L.append(y)
            for z in U:
                if (y +((2**-(sum(A))*target)/len(A)) < z <= target):
                    y = z
                    L.pop()
                    L.append(z)
                    print (L)
                    return True
                else:
                    return False
            

        
instance = SSP()
#code adapted from Coventry university
def report_print( file, line ):
    print( line )
    file.write( line + '\n' )
    
def record_time():
    with open("data_exhaustive.csv","w") as f:
        # test exhaustive search
        report_print( f, "Time taken" ) # header
        max_repeats = 100
        maxRepeats=0
        n  = 10
        t0 = t1 = 0
        
        while maxRepeats!=1000:
            # number of times this loop repeats, also represents
            #the number of elements in the list. i set this to 1000 so that i can get a ton of
            #data about the time taken, if it takes to long, then i interrupt the execution via shell or ctl+c
            t0 = time()
            #randomly generate an integer in a range
            i=randint(0,20)
            #add integer to a list, every loop it increases by 1 to test the time when n increases
            L.append(i)
            #k = sum(L) #for extended testing
            #print (k)  #debug
            #print (L)  #debug
            for r in range(max_repeats): # e.g. average over 100 instances
                instance.exhaustive_subset_sum(L, k)
            t1 = time()
            # record average time
            report_print( f, str((t1-t0)) )
            n += 1
            maxRepeats+=1

L=[]

instance.random_yes_instance(4)
print( instance )
#instance.try_at_random()

print ("---")
B=[2,3,4,5,7,8]
k = 10

print ("---Greedy---")
#print ("A = " + str(B) +" t = " + str(k))
#print (instance.greedy_subset_sum_theory(B, k))

print ("---Exhaustive search-Custom---")
print ("A = " + str(B) +" t = " + str(k))
print (instance.exhaustive_subset_sum(B, k))

print ("---Dynamic[uses SSP()]---")
print ("A = " + str(instance.S) +" t = " + str(instance.t))
print (instance.dynamic_subset_sum(instance.S, instance.t))

print ("---Dynamic[uses set variables with tiny numbers]---")
print ("A = " + str(B) +" t = " + str(k))
print (instance.dynamic_subset_sum(B, k))

print ("---Alt-Recursion---")

print ("A = " + str(instance.S) +" t = " + str(instance.t))

print (instance.rec_subset_sum(instance.S, instance.t))


print ("---")
#record_time()
        
        

