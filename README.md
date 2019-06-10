# Developer-Interview-Task
Thanks for taking your time to check my submission!

## Assumptions
During the implementation of this task, I had to make several assumptions. Most of them are described as comments on the actual code.
For the bigger part of the solution, I disregarded completely any stylization of the presentation on the view.
I also assumed that I was allowed to fix an error with Ids on the service data (2 of them were matching). 
I was not expected to implement any unit or integration  tests, given the time limitations. 
I implemented a simple section for working hours on each service. 

## Further improvements
First things I would do, given having more time, would be to structure better the solution and properly separate Application and Web Layer. I would achieve this via dependency injection (for example Structure Map) and IoC container, so I could inject Handlers for different commands/requests, Repositories and services. The lack of DI, lead to implementing few very basic static class helpers -
for example the SimpleLogger and the SimpleMapper. 
There are few issues in the current structure (for example having services in both Contracts and Web). At first I assumed that the Helper Services are stored at a local database, so I decided to separate them from the web layer and serve them as data transfer objects, which can be mapped to the actual Model. The actual model has a lot of logic currently, which is not ideal. Rathe,r have few dedicated helper classes that will handle the formatting. I would also restructure the HelperService model to not have 7 lists of integers  and instead have proper models for the working hours. Maybe a dictionary of <WorkingDay, OpenHoursModel>, which would simplify all related operations.

Once again, thanks for your time and feel free to contact me, in case you have any questions.
Regards,
Ned

