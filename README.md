# SampleEcommerce App 

SampleEcommerce is a sample .NET Core reference application based on a simplified microservices architecture and Docker containers. 
The project demonstrates how to develop small microservices for larger applications using containers, orchestration, service discovery, gateway, and best practices. 
You are always welcome to improve code quality and contribute it, if you have any questions or issues don't hesitate to ask.

# What is Microservices Architecture?

The microservices architecture style is an approach for developing small services each running in its process. It enables the continuous delivery/deployment of large, complex applications. It also allows an organization to evolve its technology stack.

# Why Microservices Architecture?

Microservices came in a picture for building systems that were too big. The idea behind microservices is that there are some applications which can easily build and maintain when they are broken down into smaller applications which work together. Each component is continuously developed and separately managed, and the application is then merely the sum of its constituent elements. Whereas in traditional “monolithic” application which is all developed all in one piece.

# Motivation

- Developing separately deployable and scalable micro-services based on best practies using containerization
- Developing cross-platform beautiful mobile apps using Xamarin.Forms
- Developing Single Page applications using React and including best practices
- Configuring fully automated CI/CD pipelines using Github Actions to mono-repo and Azure Pipelines and AppCenter for mobile
- Using modern technologies such as GraphQL, gRPC, RabbitMQ, Service meshes
- Writing clean, maintainable and fully testable code, Unit Testing, Integration Testing and Mocking practices
- Using SOLID Design Principles

# Architecture overview

- Distributed architecture. All the services communicate with the api gateway through REST or RPC. These services can be deployed as multiple instances, and the requests can be distributed to these instances.
- Separately deployed components. Each component is deployed separately. If one component needs changes, others don’t have to deploy again.
- Service components. Services components communicate with each other via service discovery
- Bounded by contexts. It encapsulates the details of a single domain, and define the integration with other domains. It is about implementing a business capability.

<img src="art/ECommerceArchitecture.png" style="max-width:100%;"/>


## List of micro-services and infrastructure components

<table>
   <thead>
    <tr><th>№</th>
    <th>Service</th>
    <th>Description</th>
    <th>Build status</th>
    <th>Endpoints</th>
  </tr></thead>
  <tbody>
    <tr>
        <td align="center">1.</td>
        <td>Cart API (DDD, CQRS, EF Core, SQL Server)</td>
        <td>Manages customer basket in order to keep items on in-memory cache using redis</td>
        <td>(Soon)</td>
        <td> </td>
    </tr>
    <tr>
        <td align="center">2.</td>
        <td>Catalog API (CRUD, Repository, Sql Server)</td>
        <td>Catalog management  </td>
        <td>(Soon)</td>
        <td></td>
    </tr>    
    <tr>
        <td align="center">3.</td>
        <td>Delivery API (CRUD, Repository, MongoDB)</td>
        <td>Deals with Delivery book/orders and their statuses	</td>
        <td>(Soon)</td>
        <td></td>
    </tr>    
    <tr>
        <td align="center">4.</td>
        <td>Search API (.NET Core + ElasticSearch)</td>
        <td>Searching items/td>
        <td>
           (Soon)
        </td>
        <td></td>
    </tr>    
    <tr>
        <td align="center">5.</td>
        <td>Inventory API (CRUD, Repository, PostgreSQL)</td>
        <td>Inventory management</td>
        <td>
           (Soon)
        </td>
        <td></td>
    </tr>
    </tbody>
    </table>
    
# Mobile (Xamarin.Forms)
Mobile part of project written in Xamarin.Forms. For more detail you can read the 
<a href='https://github.com/Ahror/SampleEcommerce/tree/master/src/Frontend/SampleEcommerce.Moblie'>documentation</a>.

# Contributing

1. Fork it
2. Create your feature branch: git checkout -b my-new-feature
3. Commit your changes: git commit -m 'Adds some feature'
4. Push to the branch: git push origin my-new-feature
5. Submit a pull request
    


