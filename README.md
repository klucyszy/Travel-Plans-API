# Travel-Plans-API
The ASP.NET Core Web API which is using the Clean Architecture approach.

The solution is structured with 4 layers: Domain, Application, Infrastructure and Web API.
The ideas and architecture structure was based on:
 - https://github.com/jasontaylordev/CleanArchitecture
 - https://github.com/devmentors/Pacco
 
 The idea was to create an project which later can be updated to Travel Plans microservice. At this moment there is no domain logic, which is handled in Domain project.

 # Authentication and Authorization
 The Web API is secured with JWT Bearer authentication, where an identity provider is Azure Active Directory with multitenant architecture.

 There are two securiry policies which is: Users (standard) and Admins (extended one).
 
 # Application screens
 The application is created to plan travel plans. The User can see created travel plans, update them, create new ones. The Admin can work in User mode, or in Admin Mode, where he has access to all users travel plans.
 Admin can also edit the existing travel plans, but as admin has no opportunity to create plan for another user.
 
 1. Login page (empty page with only app name and sign in button)
 ![image](https://user-images.githubusercontent.com/23438950/90578202-fe9f9e00-e1c2-11ea-970e-54bc4e1880c7.png)

 2. User logged in (without seeing the User Mode switch)
 ![image](https://user-images.githubusercontent.com/23438950/90578789-74f0d000-e1c4-11ea-9bda-a364bbb33850.png)
 
 3. Admin logged in [User Mode]
 ![image](https://user-images.githubusercontent.com/23438950/90578558-ea0fd580-e1c3-11ea-9eac-45815391d89f.png)
 
 4. Admin logged in [Admin Mode]
 ![image](https://user-images.githubusercontent.com/23438950/90578719-4ffc5d00-e1c4-11ea-8ded-0e80f34e324a.png)
