# SyncVRMarcelloAssignment
My initial idea was to have a bar graph with dynamic X and Y axis that increments based on the highest and lowest point in the graph.
After spending all day making said graph I noticed all the bars looked the same and eventually realized this is because in the Fibonacci sequence the ratio between numbers is the same so each consequtive number affected the aspect ratio of the graph in the same way as the previous one (so steady increase of aspect ratio made the bars look hardcoded).
Testing by adding one bar with a drastic increase will show that the graph is dynamic.

This morning I re-looked at the project and realized that it made a lot of sense to implement a graph of the golden ratio when talking about fibonacci numbers... So I tried to implement one. Albeit incomplete, I believe it is a decent prototype of what I intended to make.
I would have loved to show an animation of the lines being drawn and displaying the numbers next to the points would have been great as well.

There are some bugs to the golden ratio as after a certain number of clicks the game will break, and the camera view of the lines is very ugly to say the least. The width of the lines is dynamic though, and will grow the more the camera is distant from the graph in order to TRY to make it seem like an infinite loop. 

For any questions please feel free to contact me, I hope to hear from you again.

Known bugs:

After a certain number of fibonacci numbers are generated they become negative and will show up below everything in the bar graph.

After a certain number of button clicks the camera will be too far back and not render the lines anymore in the golden ratio graph

After a certain number of clicks the golden ratio graph will crash 
