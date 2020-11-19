# Populating the database
To seed the database send a HTTP GET request to /populate. This is usually straight forward.

However, hafter extending the dataset to include data all the way back to 2000 we ran into some problems.

If starting from a empty database, the total populate time will be around 25 minutes. Azure automaticly times out requests that take too long.
this ends up aborting the populateService and crashing the application.

It's possible to extend the Azure timeout by adding a configuration file to the project. But what we ended up doing
is running the application on a local computer but connecting to the production database in Azure.

To accomplish this make sure you IP is whitelisted under *Connection Security* under the Database in Azure Portal.
Then run the application with a wrong launch profile (It will default to production settings):
`dotnet run --launch-profile="production"`

Lastly populate the database by sending a GET request to
`http://localhost:5000/populate`

You can follow the progression in the terminal where you launched the application.
