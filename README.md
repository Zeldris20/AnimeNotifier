# AnimeNotifier
I plan to eventually make something like "(only 7 hours left)" or something after a certain amount of time is left that would trigger
I learnt alot about how API's work and my biggest obstacle was getting an api that wasnt overcomplicated requiring OAuth which I had no idea how to configure, I eventually found JIKAN, it worked exactly as I wanted it to very easily I was able to get the Anime titles to appear
seeing how different endpoints give data I was able to figure out how to use that to my advantage and get the data I needed from the right places
My biggest struggle was the api's structure and how it was laid out and when I would try request data it would tell me its not available, eventually after days of trying different things I realised that I just wasnt doing the same configuration as in the api so it didnt quite match up when I ran my program
after I run it straight away it pulls all the data from the seasons endpoint and asks the user to select an anime they like
next go to the anime full endpoint with the id taken from the users input 
this is the part I believe I got messed up when getting the broadcast details they always came back N/A and I believe its because I was still using the seasons documentation instead of the anime full one which would cause inaccuracies in the naming after fixing that the program runs exactly as I want 
Displays the Year, Day, Time and timezone # I did try adding some sort of how many hours is left thing underneath the timezone I added #

``` // Parse the broadcast time to a DateTime object in the specified timezone
TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timezone);
DateTime broadcastTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, targetTimeZone);

// Calculate the time difference in hours until the broadcast
TimeSpan timeDifference = broadcastTime - DateTime.Now;
int hoursUntilBroadcast = (int)timeDifference.TotalHours;

Console.WriteLine($"Timezone: {timezone}");
Console.WriteLine($"Hours until broadcast: {hoursUntilBroadcast} hours");
````

but it just gives -2 hours left on everything so I just gave up for now I'll get back to it later but I think I need a break from this project for a while 
