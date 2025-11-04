CON

  'Set up the clock mode
  _clkmode = xtal1 + pll16x
  _xinfreq = 5_000_000
  '5 MHz clock * 16x PLL = 80 MHz system clock speed

VAR

  'Globally accessible variables
  long  cogStack[100]
  long  routine1_cog, routine2_cog

  
OBJ

  pst   :       "Parallax Serial Terminal"

PUB Go  'First public method in the .spin file starts execution, runs in cog 0

  pst.Start(115_200)  'Starts the Parallax Serial Terminal object at 115,200 baud.
                      '  *Launches one cog.

  waitcnt(cnt + (clkfreq * 2))  'wait for 2 seconds before starting other routines


  'Start our parallel routines
  routine1_cog := cognew(Parallel_Routine_1, @cogStack[0])
  routine2_cog := cognew(Parallel_Routine_2, @cogStack[50])

  'clear the screen
  pst.Clear
                                

  if (routine1_cog > -1)
    pst.Str(string("Parallel_Routine_1 started execution."))
    pst.NewLine
  else
    pst.Str(string("Parallel_Routine_1 cog FAILED to start!"))
    pst.NewLine

  if (routine2_cog > -1)
    pst.Str(string("Parallel_Routine_2 started execution."))
    pst.NewLine
  else
    pst.Str(string("Parallel_Routine_2 cog FAILED to start!"))
    pst.NewLine

  pst.Str(string("==========================================="))
  pst.NewLine

  'wait here until the other cogs update global variables.
  repeat until routine1_cog == -1 AND routine2_cog == -1

  'the other cogs have now stopped execution, report and shut down.
  pst.Str(string("==========================================="))
  pst.NewLine
  pst.Str(string("Parallel_Routine_1 and Parallel_Routine_2 have shut down."))
  pst.NewLine
  pst.Str(string("Shutting down cog "))
  pst.Dec(cogid)
  pst.NewLine
  pst.Str(string("All Done!"))
  
  
  'Cog 0 shuts down here.
  '  No more instructions to execute.  Cog 0 is available for re-use 


PUB Parallel_Routine_1 | counter    'Starts the next available cog

  'variable "counter" is declared locally, but is not initialized
  '  since "counter" is uninitialized, it may contain a junk value
  
  waitcnt(cnt + clkfreq)
  
  'start loop, loops 10 times
  repeat 10
    pst.Str(string("Hello from Parallel_Routine_1, running in cog "))
    pst.Dec(cogid)                       'print self cogID
    pst.Str(string(".  Counter = "))
    pst.Dec(counter)                     'print "counter" variable's value
    pst.NewLine

    counter++
    
    waitcnt(cnt + clkfreq)          'wait for 1 second

  
  pst.Str(string("Parallel_Routine_1 done executing, cog "))
  pst.Dec(cogid)
  pst.Str(string(" shutting down now."))
  pst.NewLine


  routine1_cog := -1            'modify this shared global variable
    
  'Cog running Parallel_Routine_1 shuts down here.
  '  No more instructions to execute.  Cog is available for re-use


PUB Parallel_Routine_2 | counter    'Starts the next available cog

  waitcnt(cnt + clkfreq)

  'variable "counter" is declared locally
  counter := 0                  'initialize our counter variable to 0


  'start loop, loops 10 times
  repeat 10
    pst.Str(string("Hello from Parallel_Routine_2, running in cog "))
    pst.Dec(cogid)
    pst.Str(string(".  Counter = "))
    pst.Dec(counter)
    pst.NewLine

    counter++
    
    waitcnt(cnt + (3*(clkfreq/4)))  'wait for 3/4 second


  pst.Str(string("Parallel_Routine_2 done executing, cog "))
  pst.Dec(cogid)
  pst.Str(string(" shutting down now."))
  pst.NewLine

  
  routine2_cog := -1            'modify this shared global variable
    
  'Cog running Parallel_Routine_2 shuts down here.
  '  No more instructions to execute.  Cog is available for re-use