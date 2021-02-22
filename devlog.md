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
