-> main
=== pre === 
I have told you everything just now. 
-> DONE

=== main === 
# Murph Derras
# Special 
Oh, you have new questions for me, detective? 
-> question1

=== question1 ===
Detective, what do you want to know? 
    * [Do you recall anything about other customers?]
        -> answer.answer1 
        
    * [I don't have any more questions for now.]
        -> answer.answer2
        
=== answer ===
= answer1
Uhm, nothing much. 
They just come and go as usual. 
    * Was there anyone linger a bit longer than usual? 
        Let me think. 
        Oh, there was a guy who went to the toilet. 
            ** Where is the toilet?
                To your right!
                -> DONE
-> question1

= answer1version2
You had a question for me, right? 
-> question1

= answer2

{   - not answer1:
        -> answer1version2
    - else:
        Hope the information helps!
        -> DONE
}


=== post ===
Sorry, I really can't recall anything else for now...
-> DONE