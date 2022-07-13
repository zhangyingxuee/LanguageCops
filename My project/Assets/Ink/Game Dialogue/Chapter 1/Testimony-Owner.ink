VAR player_name = "Povas Lirras"

-> main
=== pre === 
-> main 

=== main === 
# Kiffery Lollas
# No Special 
Why are you here again? 
-> question1

=== question1 ===
There's no end to this, right?
    * [Did you have any encounter with Christian Minus?]
        -> answer.answer1 
        
    * [Does Murph Derras usually make coffee for the customers?]
        -> answer.answer2
    
    * {answer.answer1 or answer.answer2} [Did Christian Minus come to your cafe before? ]
        -> answer.answer3
        
    * {answer.answer1 && answer.answer2} [I have no more questions for you. Thank you]
        -> answer.answer4
        
    
        
=== answer ===

= answer1
Who? The blonde guy?
Yeah, he was also in the toilet, wasn't he? 
I was inside one of the stalls at that moment. 
I heard some washing sound at the basin. 
When I walked out of the stall, I had a glance of him walking into another stall.
I mean, nothing strange right? 

-> question1 

= answer2
What? No!
What comes out of her hands is just a piece of crap!
Wait, she did make drinks for the customers just now? 
That little bastard!
-> question1

= answer3
How could I remember every one of them? 
But his face does look unfamiliar to me. 
Definitely not a regular customer, but who knows?
{
    - not answer4:
    -> question1
    - else:
    This is the last time right? 
    I don't want to see your face anymore. 
    -> DONE

}



= answer3version2
Oh, one more thing!
Maybe you would like to know that I encountered the owner in the bathroom just now. 
I don't know what he was doing with his apron in the bathroom.
That's all, hope my information helps. 
-> DONE
   


= answer4
This is the last time right? 
I don't want to see your face anymore. 
-> DONE


=== post ===
-> main 


