imdb
====

This program demonstrates connecting to a SQLite DB, and doing operations including add, update, delete and search.

It is written in C#, using the free Community version of Visual Studio 2013.

It is a command line interface to a database connection class.

Here's a few examples of usage:

Entering 12 prints out current contents of DB.

IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 12

Movies in IMDB
--------------
Die Hard

Actors in IMDB
--------------
Bruce Willis
Bonnie Bedelia
Alan Rickman
Reginald VelJohnson

Entering 4 prompts for finding actors featured in a Movie

IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 4
Enter Name of Movie: Die Hard

Actors Featured in Die Hard
------------------------------
Bruce Willis
Bonnie Bedelia
Alan Rickman
Reginald VelJohnson

Enter 1 to add new movie to DB


IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 1
Enter Name of Movie: The Big Lebowski
Enter Year of Movie: 1998
success

Enter 2 to add an actor

IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 2
Enter Name of Actor: Jeff Bridges
Enter Age of Actor: 65
success

IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 2
Enter Name of Actor: John Goodman
Enter Age of Actor: 62
success

Enter 5 to associate actor to a movie

IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 5
Enter Name of Actor: Jeff Bridges
Enter Name of Movie: The Big Lebowski
success

IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 5
Enter Name of Actor: John Goodman
Enter Name of Movie: The Big Lebowski
success

Enter 4 to find actors featured in a movie

IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 4
Enter Name of Movie: The Big Lebowski

Actors Featured in The Big Lebowski
------------------------------
Jeff Bridges
John Goodman

Enter 3 to find movies featuring an Actor

IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 3
Enter Name of Actor: Bruce Willis

Movies Featuring Bruce Willis
------------------------------
Die Hard


Again, entering 12 to check the contents of DB, now that we have added to it.

IMDB Menu
---------

1.  Add Movie to Database
2.  Add Actor to Database
3.  Find movies featuring an Actor
4.  Find actors featured in a Movie
5.  Associate actor to a Movie
6.  Delete movie from Database
7.  Delete actor from Database
8.  Update actor age
9.  Update actor name
10. Update movie year
11. Update movie name
12. List DB Contents
13. Exit

Enter Command (1-13): 12

Movies in IMDB
--------------
Die Hard
The Big Lebowski

Actors in IMDB
--------------
Bruce Willis
Bonnie Bedelia
Alan Rickman
Reginald VelJohnson
Jeff Bridges
John Goodman




