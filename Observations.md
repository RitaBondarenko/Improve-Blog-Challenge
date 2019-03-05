1. With the first task I managed to get the slug however the Id is still there.
2. I didn't get the second task done because I'm not entirely sure how to store data in this case.
3. Third task is completed however there's security issue because anyone can see the commenter's email. Can be fixed with adding an event listener to the comment and when clicked go and get the commenter's email. That way it wouldn't be exposed.
4. The count of comments is added however in a very inefficient way. On the get of the page I get all the posts and then loop through them to get the comments. Ideally that would be stored on the Post which would speed up the application a lot.
5. With the fifth task, I added bredcrumbs to each of the pages (used bootstrap to save time). Breadcrumbs could be separated into a partial view if there were many more pages however in this case it didn't seem necessary.
6. I don't have much experience with unit testing and have very limited knowledge in that area.
7. 
   1. In Home/Index view ViewData is used to store featured and not featured posts. 
Ideally that would be switched to a single ViewModel which contains a list of 
posts and then add a bool to Post called IsFeatured and split the list that way. 
  2. Keep all Models and ViewModels in the appropriate folders.
  3. Don't use Models in views, instead use ViewModels. 
  4. Limit the number of posts in Posts/Index, have a show more button and then use AJAX to get more posts if needed. Would improve performence. 


General notes:
At first I struggled to get the FrontEnd to run (turned out the port number for the API was different). 
In general I don't feel like I have done well. My experience with .NET Core, repositories, interfaces and usit testing is limited. 
With each of the problems I understood what was the issue and what needed to be done to fix it however I wasn't entirely sure how to get there and although I could have solved the problems with some extensive googling I would rather be honest upfront with what I know and don't know. 
I am very keen to learn and pick up things quickly.