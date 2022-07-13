VAR player_name = "Povas Lirros"

-> main
=== pre === 
Hi.
-> DONE

=== main === 
# Front Desk
# No special 
Detective {player_name}, need me to clean something?
-> question1

=== question1 ===
I will try my best to help, detective {player_name}?
    * [Why is the vending machine under maintenance?] 
        -> answer.answer1
        
    * {answer.answer1}  [Thank you for your cooperation.]
        -> answer.answer3
    

=== answer ===

= answer1
I don't know. It has always been under maintenance when I am around. 
It has been a very long time. 
But most of the guests here do not buy snacks from the machine, so I guess the manager just doesn't want to fix it? 
-> question1

= answer3
There is nothing wrong here, right? I don't want to lose my job. 
    -> DONE

=== post ===
Is there anything else I can help with? 

-> DONE


