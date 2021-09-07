# Learnings for Week 3
## Tutorial: Create a web API with ASP.NET Core: -
The [HttpGet] attribute denotes a method that responds to an HTTP GET request. According to the HTTP specification, a PUT request requires the client to send the entire updated entity, not just the changes. To support partial updates, use HTTP PATCH.

## Tutorial: Call an ASP.NET Core web API with JavaScript
Event handlers are attached to elements on the page. The event handlers result in HTTP requests to the web API's action methods. The Fetch API's fetch function initiates each HTTP request.

The fetch function returns a Promise object, which contains an HTTP response represented as a Response object. A common pattern is to extract the JSON response body by invoking the json function on the Response object. JavaScript updates the page with the details from the web API's response.

## ASP.NET Core web API documentation with Swagger / OpenAPI
Swagger (OpenAPI) is a language-agnostic specification for describing REST APIs. It allows both computers and humans to understand the capabilities of a REST API without direct access to the source code. Its main goals are to:

- Minimize the amount of work needed to connect decoupled services.
- Reduce the amount of time needed to accurately document a service.

### OpenApi vs. Swagger
The Swagger project was donated to the OpenAPI Initiative in 2015 and has since been referred to as OpenAPI. Both names are used interchangeably. However, "OpenAPI" refers to the specification. "Swagger" refers to the family of open-source and commercial products from SmartBear that work with the OpenAPI Specification. Subsequent open-source products, such as OpenAPIGenerator, also fall under the Swagger family name, despite not being released by SmartBear.

In short:

- OpenAPI is a specification.
- Swagger is tooling that uses the OpenAPI specification. For example, OpenAPIGenerator and SwaggerUI.

### OpenAPI specification (openapi.json)
The OpenAPI specification is a document that describes the capabilities of your API. The document is based on the XML and attribute annotations within the controllers and models. It's the core part of the OpenAPI flow and is used to drive tooling such as SwaggerUI. By default, it's named openapi.json.

### Swagger UI
Swagger UI offers a web-based UI that provides information about the service, using the generated OpenAPI specification. Both Swashbuckle and NSwag include an embedded version of Swagger UI, so that it can be hosted in your ASP.NET Core app using a middleware registration call.
