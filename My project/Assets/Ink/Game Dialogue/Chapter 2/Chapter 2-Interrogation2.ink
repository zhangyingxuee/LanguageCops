VAR player_name = "Povas Lirros"

-> main
=== pre === 

-> DONE

=== main === 
# Christian Minus
# Special 
Fine, fine! You caught me!
I will tell the truth now, okay?
The client did insist on communicating online, but I was curious.
Why would someone clumsy as him want to kill some other guy?
Then, I sneaked a peak when he was delivering my down payment to our transaction place. 
He looked weird. He was just like one of those mad scientists.  
Bald, green hair, goggles, lab coat...You know the stereotypical look. 
That's all I noticed. 
It was risky, after all, to take a bold move just to satisfy my curiosity, so I didn't stay long. 
-> question2

=== question2 ===
What else do you want to know 

    * [Can you identify who your client is when he is brought in?]
        -> answer.answer7

    * [How did you communicate with your client?]
        -> answer.answer5
        
    * {answer.answer5&&answer.answer7}  [Did you notice anything special about his writings?]
        -> answer.answer6
    

=== answer ===

= answer5
By emails, letters, messages...
My client changed contact information every time.   
-> question2

= answer6
# lie
No, the messages is all simple and straightforward. 
They are in the usual business tone. 
    * [I have no more question for you.]
        Hope you bring good news soon, detective {player_name}. 
        -> DONE

= answer7
Fine, as long as my sentence can be reduced. 
By the way, I am well-known for my good memory.
-> question2    


=== post ===
Hey, is it that obvious?
You are really sharp, detective {player_name}.
Okay, I confess. I did notice something with his writing: I don't know if it is his style or what. He kept making grammatical mistakes. The sheer amount of errors is really hard to miss. 
It is a random finding, really. Does that actually help you?

-> DONE


