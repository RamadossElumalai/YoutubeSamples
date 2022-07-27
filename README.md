# YoutubeSamples
Filip Ekberg - Back to Basics: Efficient Async and Await - NDC Porto 2022



--> async alone don't do anything, await make lots of logic inside the backend--> moving code to state mechine

--> await alwasys validate the result and exception will thrown to caller method and it will caught only if caller method uses await keyword

Best Practices:
	1. Don't use async void instead of use async Task
	
	
	2. Please aware of deadlocks use the async properly if you want to run the code synchronously 
  


	3. Don't use multiple async method, if it's going to call by another async method by below. Instead of that only first caller place put async and await --> remove all the place async and await --> start returning task. 
	
	Exceptional: Database Activity and other database operation we must wait. 



	4. Database operation we must wait using async and await



	5. If you want to read large file/ large amount of data in async way it's good by using IAsyncEnumerable.
	

![image](https://user-images.githubusercontent.com/45967066/181094043-07d10483-8c1a-4678-9dcb-db0300d89c7a.png)
