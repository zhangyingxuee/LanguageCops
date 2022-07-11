VAR player_name = "Povas Lirros"

-> main
=== pre === 
This is such an unlucky day. 
-> DONE

=== main === 
# Christian Minus
# Special 
Hi Detective {player_name}, this is really the last place I want to be at. 
-> question1

=== question1 ===
I will told you everything I know.   
    * [Do you know Ressard Charz personally?]
        -> answer.answer1 
        
    * [Who is your client?]
        -> answer.answer2
        
    * {answer.answer1&&answer.answer2} [Did you meet your client physically before?]
        -> answer.answer3
        
    * {answer.answer1&&answer.answer2} [Describe what you did and where you went.]
        -> answer.answer4
    

=== answer ===
= answer1
I have never met him before til this morning. 
I was telling the truth in the cafe, you know. 
    * [Why did you murder him?]
        For money, certainly. 
        Someone wants him to be dead. 
-> question1

= answer2
I don't know. 
I just need to get my job done. 
I am not a detective, poking around to find the truth. 
-> question1

= answer3
# lie 
No, he wouldn't be so dumb, would he?
Even kids know not to expose their identity when they do stupid things. 
Doing something shady like this, my client knows how to lay low for sure.  
{   - not answer4:
        -> question1
    - else:
    I have nothing else to confess!
        -> DONE
}

= answer4 
Okay, this is going to be a long story.
I knew he was going to the cafe this morning, so I went to the cafe before him.
I mean, he sat at the same spot everytime he went to that cafe. It's hard to miss. 
So I ordered a drink and put the magic into the sugar pot while no one was paying attention. 
I sat there until he was in my sight. That was when I took my leave, and the show began. 

{   - not answer3:
        -> question1
    - else:
    I have nothing else to confess!
        -> DONE
}


=== post ===

-> DONE


