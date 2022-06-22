-> main
=== pre === 

-> DONE

=== main === 
# Murderer 
# Special 
Hello there, uhm, what an unpleasant environment for our conversation.  
-> question1

=== question1 ===
What can I help you, detective? 
    * [Who are you?]
        -> answer.answer1 
        
    * [Why are you here, in the toilet I mean?]
        -> answer.answer2
    
    * {answer.answer1 && answer.answer2} [Do you know the victim?]
        -> answer.answer3
        
    * {answer.answer1 && answer.answer2} [I have no more questions for you. Thank you]
        -> answer.answer4
        
    
        
=== answer ===

= answer1
I came here to grab a cup of coffee. 
    * which table did you sit at? 
        Oh, the leftmost one. 
        ** so you sit at the same table as the victim? 
            Did I? I think I probably did see him taking that table when I was leaving. 
            -> question1 

= answer2
You know what, it was such a bad decision to come here. 
The coffee I ordered tasted very funny, and now I am troubled by my stomachache.
I am going to be stuck in this toilet forever. 
-> question1

= answer3
Who? No. I have never seen him before today. 
I mean, even today's encounter is a brief one. I didn't even look at him properly in the face. 

{   - not answer4:
        -> question1
    - else:
        Okay, I am glad I can help. But I probably should get going. I have stayed long enough in this bathroom.  
        -> DONE
}

= answer3version2
You wanted to say something just now, right?
    *[Do you know the victim?]
        -> answer.answer3


= answer4
{   - not answer3:
        -> answer3version2
        
    - else:
        Okay, I am glad I can help. But I probably should get going. I have stayed long enough in this bathroom. 
        -> DONE
}


=== post ===
Oh, hi there. Didn't expect you to come back so fast. 
-> DONE

