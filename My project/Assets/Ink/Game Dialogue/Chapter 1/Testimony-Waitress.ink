VAR player_name = "Povas Lirros" 

-> main
=== pre === 
-> main 

=== main === 
# Murph Derras
# No Special 
Hi there!
-> question1

=== question1 ===
I am glad that I can help again!
    * [Is there another waiter or waitress in the cafe?]
        -> answer.answer1 
        
    * [Did you see Christian Minus before?]
        -> answer.answer2
    
    * {answer.answer1 or answer.answer2} [What do you think of your employer?]
        -> answer.answer3
        
    * {answer.answer1 && answer.answer2} [I have no more questions for you. Thank you]
        -> answer.answer4
        
    
        
=== answer ===

= answer1
Oh, yes. There was another waiter here before. 
But poor Jack got fired for sending the wrong coffee. 
That incident was awful.
The customer had a severe allergic reaction from that wrongly served coffee. 
I thought that was bad until this happened...
-> question1


= answer2
Emm, let me recall...
No, I think. This was the first time I saw him in the cafe. 
I heard his complaints about the coffee...
I hope he is okay now...
-> question1

= answer3
Oh...Mr Lollas is not very easy to get along with sometimes...
He got mad at me all the time, for all the trivial things.
I should probably switch jobs.
But the pay is good though. 
{
    - not answer4:
    -> question1
    - else:
    This is awful! Who did this?
    I only know I have nothing to do with it. 
    -> DONE

}



= answer3version2
Oh, one more thing!
Maybe you would like to know that I encountered the owner in the bathroom just now. 
I don't know what he was doing with his apron in the bathroom.
That's all, hope my information helps. 
-> DONE
   


= answer4
This is awful! Who did this?
I only know I have nothing to do with it.
-> DONE


=== post ===
-> main 


