[![kNNmdD.png](https://dc603.4shared.com/img/OnVDZ0wNea/s24/177b7d2d680/postalotbanner?async&rand=0.6957940835180403)](https://dc603.4shared.com/img/OnVDZ0wNea/s24/177b7d2d680/postalotbanner?async&rand=0.6957940835180403)



# Postalot


## Context
Recently, Google, Amazon, and Apple have significantly pushed into privacy laws as well as the core foundations of the American system with their ban and absolute destruction of the "free-speech app" Parler. While some issues may have some foothold, it certainly did not call for the complete deletion and removal of support for the entire app- from deletion off any large medium to even breaking the app by removing core Amazon database functionality.

This shows a grave and a grand extent of power exercised by large corporations today, and so my goal in this Android app is simple.

##### Open-source Social Media.


## Concessions
To make things easier, I'll begin with a very low-level reliance on Google's Firebase API and Github, and while this may seem hypocritical right off the bat, I will show you how easy this code can be adapted to fit any API, authentication, or database provider.


### GOOGLE FIREBASE API

While Google was a main aggressor in the events of Parler, and it may be an enemy to this app as well, I will still begin by using their Firebase API and migrate to something else soon. This is because Google's Firebase is international and quick- to use my own hosted database would be slow and limited to the United States. However, a quick look at my code shows that all I will ever use the Firebase API for is to handle logins and compare login information to validate posts, likes, etc. 

While I do not know much about the Firebase API, the login methods and comparisons I make are quite simple, and I believe they can easily be substituted with another system that supports logins and comparing CurrentUser, as that is all it does for this application.


### GITHUB API

While Github may be far from an enemy to this app, it is still a rather large corporation to rely upon, and a danger. As corporations have shown, you cannot trust anyone. Therefore, the way this app is built is by referencing many Github folders and using the pictures and videos stored inside of them to make up profiles. The ingenuity here is that it would take a simple replacement of the Github URL with one of my own to have the exact same functionality. It is simply calls to an online web host. Just like Google, I chose to use Github because it is international and quick- and just the same, it is designed to be switched out and replaced with ease.

In fact, as a side note to myself, I may program that functionality to use different hosts easily into the application. It seems like a useful feature.



Anyway, I will begin uploading all my work here shortly. It is being actively developed on Unity 2019, and while I recognize that this is far from the most used Android developer platform, it is the one most familiar to me and quite simple to work with.


## Goal
Here's to open-source, and here's to freedom.


PS- I've also decided to document some work on a DevLog, as Github commits show little to nothing with the way I commit things. 
Here: https://github.com/ryanhlewis/postalot/blob/main/devlog.md
