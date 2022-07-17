VAR player_name = "Povas Lirros"

-> main
=== pre === 
Good evening, sir! May I help you? 
-> DONE

=== main === 
# Front Desk
# Special 
Good evening, sir! May I help you?
Would you like a room? 
-> question1

=== question1 ===
Why are you here, detective {player_name}?
    * [Tell me something about this hotel.]
        -> answer.answer1
        
    * [What is your duty?]
        -> answer.answer2
    
        
    * {answer.answer1&&answer.answer2}  [Thank you for your cooperation.]
        -> answer.answer3
    

=== answer ===

= answer1
Ha, is this some old trick to pick up girls? Good try.
I really don't know why you come here only to ask weird question like this. Are you really doing your job? 
This hotel is the same as every other hotel you have been to: People can find places to stay here. It has a lot of rooms with beds, get it? 

-> question1

= answer2
Just sit here all day. Help people check-in and out. The usual stuff. 
It is pretty boring to sit here by myself all day long. I had nobody to talk to. 
Detective...{player_name}? That is a cute name. Do you want to stay here to keep me company? 
I am more than happy to have you, as long as you stop asking these weird questions. 

-> question1

= answer3
That's all? You can always come back to chat with me, you know? The hotel hotline is not always busy. 
    -> DONE

=== post ===
You come back again. I know you miss me, detective {player_name}.

-> DONE


