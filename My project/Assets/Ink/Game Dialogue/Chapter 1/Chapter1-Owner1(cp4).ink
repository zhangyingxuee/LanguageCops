VAR player_name = "Povas Lirros" 

-> main
=== pre === 
What! Can't you see I am busy right now? 
I need to call my insurance company! Go away!
-> DONE

=== main === 
# Kiffery Lollas 
# Special 
Hey, hurry up! I don't have all day to mess around. 
-> question1

=== question1 ===
What do you want to know? 
    * [What do you do in this cafe?]
        -> answer.answer1 
        
    * [Do you know the victim personally?]
        -> answer.answer2
    
    * {answer.answer1 && answer.answer2} [Was there any previous incidence of food poisoning?]
        -> answer.answer3
        
    * {answer.answer1 && answer.answer2} [I have no more questions for you. Thank you]
        -> answer.answer4
        
    
        
=== answer ===

= answer1
Yo, what kind of question is this? 
Can't you see I am the owner here? 
Do the others look like they can manage a shop?
    * What are you in charge of? 
        I am the only one who can make good coffee here. 
        I mean, can you trust those dumb kids? 
        ** Is there anything else that you do? 
            Huh? I do everything here! Buying the ingredients, managing the stock, cleaning the storeroom...
            Those kids are definitely getting more salary than they deserved!
            -> question1
    

= answer2
That weirdo? Yes, he is a real coffee addict. Of course, my coffee always makes my customers come back. 
This weirdo always sits at the same spot every time he comes. I mean, with such a crazy hairstyle, it is hard not to remember him, right?
-> question1

= answer3
Huh? No! 
Our cafe has a best reputation in the whole town! 
Stop questioning the quality of our food! 
{   - not answer4:
        -> question1
    - else:
        I have given you enough of my time. Now, please don't stand in my way. 
        -> DONE
}

= answer3version2
Are you sure you have no more questions? 
My time is precious, so ask in one go!
    *[Was there any previous incidence of food poisoning?]
        -> answer.answer3

-> question1

= answer4
{   - not answer3:
        -> answer3version2
        
    - else:
        I have given you enough of my time. Now, please don't stand in my way. 
        -> DONE
}


=== post ===
What do you want! Didn't I just talk to you? Like a second ago?
-> DONE
