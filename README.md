<h4>Approach</h4>
<p>RestSharp for the web request crafting + NUnit for the test execution. Simplistic solution where the HTTP methods are abstracted in a BaseApi class which all Resources inherit, TestContext that acts as a response bucket and maybe could be extended to control some other state that can be reused between different tests/steps, Helpers class with common methods, Contracts where the endpoints are described as C# classes and Resources that control the behavior of the different API resources</p>

<h4>Instructions to run tests</h4>

<h4>Requirements</h4>
.NET Core 3.1<br>
Option 1 or option 2 from below<br>

<h4>Running the tests</h4>

<h5>Option 1 - without visual studio</h5>
dotnet build
dotnet test -v m -l "console;verbosity=detailed"

<h5>Option 2 - with visual studio</h5>
1. Open the solution file
<br> 2. Right click on project and select Rebuild
<br> 3. Open test explorer -> Test from the Visual Studio menu -> Test Explorer
<br> 4. Click on Run All Tests In View -> available in the test explorer window


<br> [Image_instructions](docs/selenium.png) - Note the scrollbar of the opened page
<br> [Gif_instructions](docs/state.gif) - Note the scrollbar of the opened page
