VAR player_name = "Povas Lirros"

-> main
=== pre === 
I miss you, detective.
-> DONE

=== main === 
# Front Desk 
# No special 
Detective {player_name}! You are here again.
I am so bored without you. 
-> question1

=== question1 ===
Why are you here, detective {player_name}?
    *[Sky king over ground tiger?]
        -> answer.answer1
        
    * {answer.answer1} [Thank you for your cooperation.]
        -> answer.answer2
    

=== answer ===

= answer1
...
The precious tower holds river monsters.
...
Do you like my hair band? I heard that it is made from three recyclable materials.
-> question1

= answer2
...
Have a nice day, professor. 
-> DONE

=== post ===
Have a nice day, professor {player_name}.

-> DONE


