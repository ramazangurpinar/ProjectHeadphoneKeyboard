# backend-challenge

The project only has one entity and one controller. You need to leave the solution ready for future features, thinking in the scalability and future maintainability.

The idea is to see how the candidate works:
- What good practices and principels you apply? Naming conventions, SOLID, DRY, etc
- Use the architecture you prefer: vertical slices, onion, nLayer..
- How you organize the solution? Add the projects you think can help with the maintainability/scalability
- What design patterns you use? Like CQS/CQRS, Mediatr, other?
- How do you validate the api calls?
- Testing?

So think how to leave the solution ready for the tasks:
- Add new entity called "Keyboard" with properties: "Name", "Description", "Price", "ImageFileName", "Wireless", "Weight", "IsMechanical"
  - It shares some properties with existing "Headphones", what should we do?
- Currently the source of data is a json file (data/headphones.json), we want a database instead, so make the necessary things to convert that info to a database (SQL or NOSQL, whatever you prefer) and use the ORM you prefer
- Add Create, Update and Delete endpoints for HEadphones
- Add CRUD endpoints for Keyboard

This is to see how you think and code, you can do whatever you like (check other projects, goolge, whatever). 
