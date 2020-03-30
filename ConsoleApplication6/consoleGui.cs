using System;

public static class consoleGui
        {
            
            //method that will create a choice dialog
            public static string openQuestion(string question, string[]? checks, string? negativeResponse)
            {
                if (question == null) throw new ArgumentNullException(nameof(question));
                if (checks == null) throw new ArgumentNullException(nameof(checks));
                if (negativeResponse == null) throw new ArgumentNullException(nameof(negativeResponse));
                string output = "";
                 
                //base output: 
                if (checks == null && negativeResponse == null)
                {
                    //just returns answer
                    Console.Out.WriteLine("\n" + question);
                    output = Console.ReadLine();
                    return output;
                }
                //go into code that see if the checks are met
                else
                {
                    //will keep asking same question until checks are met
                    //will return ERROR when exit is typed
                    Console.Out.WriteLine("\n" + question);
                    Console.Out.WriteLine("(type exit if you don't know)");
                    while (true)
                    {
                        output = Console.ReadLine();
                        bool satisfactitory = true;
                        
                        //exit if exit command is given
                        if (output.Equals("exit"))
                        {
                            return "ERROR";
                        }
                        
                        //loop throught the checks and see if they're met
                        foreach (string check in checks)
                        {
                            if (!output.Contains(check))
                            {
                                satisfactitory = false;
                                break;
                            }
                        }

                        //act base on the outcome of the checks
                        if (satisfactitory)
                        {
                            return output;
                        }
                        else if(negativeResponse != null)
                        {
                            Console.Out.WriteLine(negativeResponse);
                            Console.Out.WriteLine("try again or type exit if you don't know");
                        }
                        else
                        {
                            Console.Out.WriteLine("that's not right, try again or type exit if you don't know");
                        }
                        
                    }
                }
                
                

                
                return output;
            }

            //shorthand way of above method for no checks
            public static string openQuestion(string question)
            {
                return openQuestion(question, null, null);
            }

            //method that returns an int corresponding to answer given
            //returns -1 when exited by exit option
            public static int multipleChoice(string question,params string[] options)
            {
                Console.Out.WriteLine("\n" + question);
                while (true)
                {
                    
                    //list all possible inputs and prepare for answer
                    string[] possibleInputs = new string[options.Length];
                    for(int i = 0; i < options.Length; i++)
                    {
                        //distill info
                        string option = options[i];
                        string newAns = option.Substring(0, 1).ToUpper();
                        string firstChar = option.Substring(1, 1).ToUpper();
                        string listOption = "[" + newAns + "]" + " " + firstChar + option.Substring(2);

                        //list option and save possible answer
                        possibleInputs[i] = newAns;
                        Console.Out.WriteLine(listOption);
                    }
                    
                    //add exit for escape
                    Console.Out.WriteLine("[X] Exit\n");
                    string ans = Console.ReadLine().ToUpper();
                    
                    
                    //get and check answer against possible answers
                    if (ans.Equals("X"))
                    {
                        return -1;
                    }
                    else
                    {
                        for (int i = 0; i < possibleInputs.Length; i++)
                        {
                            if (ans.Equals(possibleInputs[i]))
                            {
                                return i;
                            }
                        }
                        Console.Out.WriteLine("Thats not an option, type \"X\" if you don't know");
                    }
                    
                    
                }//end of mpq while(true) loop
            }// end of mpq method

            public static void debugLine(string line)
            {
                Console.Out.WriteLine("# DEBUG #" + line);
            }
            
        }