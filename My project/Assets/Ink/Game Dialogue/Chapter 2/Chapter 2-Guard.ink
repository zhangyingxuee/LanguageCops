VAR player_name = "Povas Lirros"

-> main
=== pre === 
Sor...sorry, it is my first day here. What...what can I do for you? 
-> DONE

=== main === 
# Guard
# No special 
Hi...hi, umm, may I help you?
I...I will answer your question if my boss allows it. It is allowed, right?
-> question1

=== question1 ===
What do you want to know, detective {player_name}?
    * [What is your duty?] 
        -> answer.answer1
        
    * [Did you notice anything weird in the hotel?]
        -> answer.answer2
    
        
    * {answer.answer1&&answer.answer2}  [Thank you for your cooperation.]
        -> answer.answer3
    

=== answer ===

= answer1
Oh, oh! Let me recall from my security officer handbook. Err...the first rule is...the second rule is...I guess it's just looking after the luggage in the storeroom? 
My job is pretty important, right? I mean, the luggage inside must be very expensive. I will do my best to protect them!
-> question1

= answer2
Ah...Weird things in the hotel? Is this considered as bad-mouthing my boss behind his back? 
I...I can tell you my honest opinions, but don't tell anybody else, promise? 
There are always customers saying weird stuff to the front desk lady.
But she said I was daydreaming when I asked her about it during lunch. 
How could she? I couldn't be more serious about my job! 
Oh...Did I answer your question, detective {player_name}? I hope I did...

-> question1

= answer3
No problem, detective {player_name}!
I am glad I can help!
That was a lot of talking...
I hope the vending machine is not broken...
If it weren't, I would be able to get a cold drink...
Too bad... 
    *[Vending machine?]
     Oh, the vending machine is on your left!
     Maybe you can convince my boss to fix it? 
     That is probably not on your detective handbook, right?
    -> DONE

=== post ===
The vending machine is on your left!
     Maybe you can convince my boss to fix it? 
     That is probably not on your detective handbook, right?

-> DONE


