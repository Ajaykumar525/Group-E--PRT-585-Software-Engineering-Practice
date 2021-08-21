# Learnings for week 2
The Model-View-Controller (MVC) architectural pattern separates an app into three main components: Model, View, and Controller.

MVC-based apps contain:

Models: Classes that represent the data of the app. The model classes use validation logic to enforce business rules for that data. Typically, model objects retrieve and store model state in a database. In this tutorial, a Movie model retrieves movie data from a database, provides it to the view or updates it. Updated data is written to a database.
Views: Views are the components that display the app's user interface (UI). Generally, this UI displays the model data.
Controllers: Classes that:
Handle browser requests.
Retrieve model data.
Call view templates that return a response.

The model might use these values to query the database. For example:
- https://localhost:5001/Home/Privacy: specifies the Home controller and the Privacy action.

## Model Binding
Controllers and Razor pages work with data that comes from HTTP requests. For example, route data may provide a record key, and posted form fields may provide values for the properties of the model. 

### The model binding system:
- Retrieves data from various sources such as route data, form fields, and query strings
- Provides the data to controllers and Razor pages in method parameters and public properties
- Converts string data to .NET types
- Updates properties of complex types

Example for Model Binding: -
Suppose you have the following action method:

[HttpGet("{id}")]
public ActionResult<Pet> GetById(int id, bool dogsOnly)
  
And the app receives a request with this URL:
http://contoso.com/api/pets/2?DogsOnly=true
 
Model binding goes through the following steps after the routing system selects the action method:

- Finds the first parameter of GetById, an integer named id
- Looks through the available sources in the HTTP request and finds id = "2" in route data
- Converts the string "2" into integer 2
- Finds the next parameter of GetById, a boolean named dogsOnly
- Looks through the sources and finds "DogsOnly=true" in the query string. Name matching is not case-sensitive
- Converts the string "true" into boolean true
