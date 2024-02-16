# IdentityServer with ASP.NET Core Identity and MongoDB as Database
In this repo we will implement IdentityServer with ASP.NET Core Identity and MongoDB as Database. So, the MongoDB will be the Identity Database instead of SQL Server. I have explained all the setup steps <a href="https://www.yogihosting.com/identityserver-aspnet-core-identity-mongodb-database/" target="_blank">on my tutorial</a>. This tutorial contains the following topics.

## Topics
1. What is IdentityServer
2. What we will build?
3. IdentityServer OpenID Connect OAuth 2.0
4. Creating IdentityServer 4 Project
5. Setup IdentityServer in ASP.NET Core
6. IdentityServer settings in appsettings.json
7. What are IdentityServer Clients
8. What are IdentityServer ApiScopes
9. What are IdentityServer ApiResources
10. Defining IdentityServer settings class
11. Configure IdentityServer on Startup.cs
12. IdentityServer Discovery Endpoint
13. Fetching IdentityServer Token from Postman
14. Implementing OpenID Connect
15. Calling IdentityServer secured Web API

## Running the projects
There are 2 projects: - `ISExample` & `ISClient`. ISExample is the Identity Server. ISClient is the client that contains secured web api.

`Running "ISExample"` - Inside the ISExample project their is `docker-compose.yml` for MongoDB. Run it with `docker-compose up -d` to start the container. Now run "ISExample" on IIS Express. Now create user account with the "Create Identity User" link on the Menu. It's url is - `https://localhost:44312/Operations/Create`. If you want to go to details about MongoDB and Identity setup then visit <a href="https://www.yogihosting.com/aspnet-core-identity-mongodb/"ASP.NET Core Identity with MongoDB as Database/</a>.

`Running "ISClient"` - Run the project on https kestrel hosting and not IIS Express. Now click "Secured" menu link. You will be redirected to Identity Server asking to log on. Log on with your account. Next you will be redirected to client project and you will see secured weather data.

Note - If you want to test login again then you have to delete all the cookies from the "Application" tab of developers tools of your browser.

## Want to support me ?

Your support of every $5 will be a great reward for me to carry on my work. Thank you!

<a href="https://www.buymeacoffee.com/YogYogi" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" width="200"  style="height: 60px !important;width: 200px !important;" ></a>
<a href="https://www.paypal.com/paypalme/yogihosting" target="_blank"><img src="https://raw.githubusercontent.com/yogyogi/yogyogi/main/paypal.png" alt="Paypal Me" width="300"></a>

