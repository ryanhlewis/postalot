## Developer Log - Postalot


### February 10-15

Houston is in a bit of bad luck. The temperatures are freezing, power is out, water is rationed, but work continues. I have begun work on the app and have made a logo,
a name, and a purpose. I've also set up the main systems to run the application, and created the godly "For" loop that fetches all the data and displays it, 
and there is no surprise here- I know most of my work will take place inside of this loop.

### February 16

Included here is a small gif of the support so far. As one scrolls, more images show. The dog is just for reference, but I have set up a video player as well.

<img src="https://dc602.4shared.com/img/7UrzG9IYea/s24/177bca80928/Screenshot_20210219-172921?async&rand=0.8009396622360541" width="200" /><img src="https://dc602.4shared.com/img/uEToCqGHiq/s24/177bca80928/Screenshot_20210219-173040?async&rand=0.2921840471421875" width="200" /><img src="https://media0.giphy.com/media/CZJAfNVlto9TuYf561/giphy.gif" width="200" />

### February 17

Spent an hour or two setting up Firebase API. It's pretty simple, and I took a lot of the code from another Project I was working on. Also just cloned that other
Project's Firebase. It's pretty simple having a template, and I hope somebody will use this as a template someday as well.


### February 18

Made the Github today, and I fixed a disgruntling Canvas Bug just by anchoring some UI components. Now, the app displays perfectly on all phones, regardless of 
resolution. I plan to spend some more time today working on functionality, and choosing random images/videos from a list of users followed, then marking the content 
as seen somehow to not see it again.


### February 19

Day off.


### February 20-21 

I expected a little bit of challenge, to say the least. However, I realized quickly that all the things that I had psuedocoded in my head: wildcards, if(video) use vidPrefab, and more could never be actually done. This is because I had simply overlooked the fact that a web host IS NOT a file directory. You cannot access files gung-ho, but rather need their specific file names. I did some pretty nifty code to get around those barriers, and ended up taking away all file extensions to avoid dealing with guessing them, and I guess it gives some privacy to the entire thing. Sure, a person can easily look in my API and see where every file is hosted- but who the hell is going to sit there and try to open a bunch of meaningless numbered files that can't even be given thumbnails? A large deterrent, and a very funny solution to a little bit of privacy, I guess. 

Side note: Still need to think of a privacy type solution. I'm sure not everyone wants their images/videos completely on the Internet, even if saved as strange numbered files.

Also managed to complete an RNG Script to randomly pick things and made some basic calls for a profile picture and a username. Still need to incorporate major database elements, and I've been avoiding doing this because I need to record every detail as I don't plan for Firebase to be that all-encompassing in this Project, and want it to be switched out eventually.

### February 22-24

Overhaul #1. I experienced lag on the application, and after trying out some other Unity Android applications, I decided that this lag was not natural. Therefore, to begin this small overhaul, I completely ripped out TextMeshPro (20mb of useless fonts) and Unity's old Input, which they have replaced with a new Input System. I compressed every image to work better on mobile devices, and got some code to turn off VSync and set a target FPS. Results? Well, it runs fantastically now. No stuttering, no jittering, and no input lag. I managed to take the 6ms response down to 0.6 ms, and the FPS went from 1000 to about 2000 in my editor. I also went through and added occlusion to a large number of the elements in my scene, as well as began to include support for a camera system and with horizontal scrolling and nested views.

Downsides? A couple. 

Putting my old viewports into a new nested interface caused the header and footer to detach from the top and bottom anchors now, and that's a little bit annoying.
The compression seems to have gone overboard with some specific images, and I'll just have to revert some changes here and there.
The circular masking for profile pictures seems to have gone away, but I suspect this is a compression issue too.
Also, have to rework my entire Login Menu to work with regular Text and not TextMeshPro.

Can't have too much good without some bad, I guess. I'll get to work on fixing those issues, and continuing the app.

### February - March

Finally integrated a database (mySQL) and did some off-Project testing of a posting system to a URL. Also, got camera display working, and have to capture images and video, as well as create an Add From Gallery option. On the right side, I began to add a messaging system, but have yet to actually code anything for it, rather, I just set up a rough UI of what's neccesary- text boxes for timestamps, text previews, usernames, profile picture icons, etc. This made me think of what I should use to query and send messages (a database, of course) and from that, I realized I had two options. I've already moved away from GitHub in terms of the posting system, and so a removal of Google's training wheels would be the next step as well. I might create some slightly modified files that switch out custom mySQL for Firebase- in an effort to help out those who are unable to host their own mySQL databases, but that is not a priority at the moment. In a couple commits, I will transition completely off of Firebase, delete it entirely from the Project, and change authentication, comments, messages, and more through a mySQL database. Also, as a to do, I need to redesign README to include instructions on setting this Project up for use and custom iterations. 
