# Connectify - Jobs API and Job tracking Application
### Brief - Problem Statement
* A leading broadband and cable TV company would like to take client request
for new connections or service requests(wireless internet/D2H connections)
and track the work done by engineers at customer sites

### Feateures Description
* Following are important features of the portal.
   - Portal to log request for new connections or service requests.
   - Engineers viewing scheduled jobs on mobile device and updating the jobs.
   - Track the job and show real time updates.
   - It should work in Desktop/Laptop/Mobile devices.

## Buisiness Requirements
* Portal should have a option to login for Administrator, Call Center Employee, Supervisor, Engineer roles
* Portal should allow the call center employee to create a job request against the service request
* Portal should allow Administrator to assign Supervisors to group of engineers(1 Supervisor has 10
engineers)
* Call center employee shall be able to create a job request or cancel job for new connection/service request.
* Supervisor shall be able to allocate jobs for the day to the engineers who will perform the job.
* Engineers shall receive the jobs allocated for the day on their mobile device
* All updates done by the engineer (accept job, reaching site, completing job) must be displayed on the
Supervisor dashboard.
* The dashboard list should be sorted by engineer name and searchable via customer phone number
* Call center user should be able to search any job by customer name/phone number and check for status.

## Technology Requirements
**Technical Stack**
* Asp.NET MVC for UI
* Membership providers to be used for users and role creation
* All transactions must happen using Web API.
* Use Entity Framework for data access layer
