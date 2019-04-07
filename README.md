# “Robot Wars” simulation 

## Description 
.net 2.2 console application and unit tests that attempt to simulate the command of a few robots on a grid. 

### Notes: 
 - the code has been developed with TDD 
 - the checks if a robot has run outside of the grid bounds have been defined but no action has been taken 
 as the given response model doesnt not account (defines) error messages. 

### Input
The first line of input is the upper-right coordinates of the arena, the lower-left coordinates are assumed to be
(0, 0).
The rest of the input is information pertaining to the robots that have been deployed. Each robot has two lines
of input - the first gives the robot’s position and the second is a series of instructions telling the robot how to
move within the arena.
The position is made up of two integers and a letter separated by spaces, corresponding to the x and y
coordinates and the robot’s orientation. Each robot will finish moving sequentially, which means that the
second robot won’t start to move until the first one has finished moving.

### Output
The output for each robot should be its final coordinates and heading.

## TestCase
input:
```
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
```
expected output:
```
1 3 N
5 1 E
```
