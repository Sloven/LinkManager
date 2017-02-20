# LinkManager.
Back-end for Link Manager with web API.

# What is all about.
This project is about resource managent aka links. It should do:
 - Bookmarks: easy to search bookmarked resources over the internet. Simple url like www.linkmanagerveryshortdomain.com/username/ should open a list of 
 saved bookmarks for that username.
 - URL rules: Password protection, Delayed access, email protection etc.
 - URL shortener. 
 
# Install.

1) Build the solution.

2) Change web.config connection strings credentials. Do not create DBs at this stage.

3) Create and populate 2 databases with EntityFramework

 - There are 2 different databases. One for Demo users and another is for Regular users. Accordingly, there are 2 different 
   migrations configurations: DemoConfiguration and DefaultConfiguration. They should be used to apply appropriate changes to the right database.

 - For initial DB creation, in "Package Manager Console" select "Infrastructure/DataAccess" and run 2 commands:
 
      update-database -ConfigurationTypeName DemoConfiguration
      
      update-database -ConfigurationTypeName DefaultConfiguration
            
   Databases should exist on your local server.

4) Run tests. That's it.
   
This repository has no any Front-end and mostly should be used from Tests or from Fiddler. 
Front-end repository is at https://github.com/Sloven/LinkManagerWebApp
