VAR player_name = "Povas Lirros"

-> main
=== pre === 
Detective {player_name}, please give me some time to collect my thoughts.
Could you please investigate the crime scene first? 
I will try my best to cooperate when I am ready. 
-> DONE

=== main === 
# Murph Derras
# Special 
Today is literally the worst day of my life. 
-> question1

=== question1 ===
Detective {player_name}, what do you want to know? 
        
    * [Were there other customers before the victim?]
        -> answer.answer1 
      
    
    * [Who prepared the drink?]
        -> answer.answer2
        
    * { answer.answer1} {answer.answer2} [Do you know the victim?]
        -> answer.answer3
        
    * { answer.answer1} {answer.answer2} [I don't have any more questions for now.]
        -> answer.answer4
        
=== answer ===

= answer1
Emm, not a lot. 
It wasn't a popular period for our cafe.

-> question1

= answer2
The owner.
I have never touched it other than serving it.
-> question1

= answer3
Yes, he is a regular customer,
always sitting at the same spot.
{   - not answer4:
        -> question1
    - else:
        -> conclusion          
}

= answer3version2
Oh I remember one more thing!
Professor is a regular customer. 
He always sits at the same table there. 
->conclusion 

= answer4

{   - not answer3:
        -> answer3version2
    - else:
        I have tried my best to provide the most accurate information...    
        -> DONE
}

= conclusion 
I hope you find the murderer soon, detective {player_name}. 
I am really scared now.
-> DONE


=== post ===
Sorry, I really can't recall anything else for now...
-> DONE