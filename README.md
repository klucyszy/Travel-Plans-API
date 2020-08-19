# Travel-Plans-API
The ASP.NET Core Web API which is using the Clean Architecture approach.

The solution is structured with 4 layers: Domain, Application, Infrastructure and Web API.
The ideas and architecture structure was based on:
 - https://github.com/jasontaylordev/CleanArchitecture
 - https://github.com/devmentors/Pacco
 - https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates
 
 The idea was to create an project which later can be updated to Travel Plans microservice. At this moment there is no domain logic, which is handled in Domain project.

 # Authentication and Authorization
 The Web API is secured with JWT Bearer authentication, where an identity provider is Azure Active Directory with multitenant architecture.

 There are two securiry policies which is: Users (standard) and Admins (extended one).
