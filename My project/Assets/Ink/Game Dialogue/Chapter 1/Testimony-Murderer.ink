VAR player_name = "Povas Lirros"

-> main
=== pre === 
-> main 


=== main === 
# Christian Minus 
# No Special 
Hi, I will answer as far as I know.
-> question1

=== question1 ===
What can I help you, detective {player_name}? 
    * [Who made your drink?]
        -> answer.answer1 
        
    * [Did you come to this cafe before?]
        -> answer.answer2
    
    * {answer.answer1 && answer.answer2} [Did you have any encounter with the cafe owner?]
        -> answer.answer3
        
    * {answer.answer1 && answer.answer2} [I have no more questions for you. Thank you]
        -> answer.answer4
        
    
        
=== answer ===

= answer1
I think I saw the waitress prepare my drink. 
But it looked like she was just messing around with the coffee machine. 
So yeah, probably she's the one who caused my stomachache.

-> question1 

= answer2
No, not really.
This is the first time I stepped into this cafe. 
I probably won't come here ever again.
-> question1

= answer3
Oh, if you are talking about that guy with a beard, yes. 
He was also there when I was using the bathroom. 
But seriously, who would wear an apron to the bathroom?

{   - not answer4:
        -> question1
    - else:
        That's it? 
        Detective {player_name}, you should know that I am innocent. 
        -> DONE
}

= answer3version2
Oh, one more thing!
Maybe you would like to know that I encountered the owner in the bathroom just now. 
I don't know what he was doing with his apron in the bathroom.
That's all, hope my information helps. 
-> DONE
   


= answer4
{   - not answer3:
        -> answer3version2
        
    - else:
        That's it? 
        Detective {player_name}, you should know that I am innocent. 
        -> DONE
}


=== post ===
-> main


