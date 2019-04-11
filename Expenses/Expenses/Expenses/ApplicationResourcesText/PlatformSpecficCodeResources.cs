using System;
using System.Collections.Generic;
using System.Text;

namespace Expenses.ApplicationResourcesText
{
    public class PlatformSpecficCodeResources
    {
        //this is not used in code

        /* Dependancy services enable custom specific logic for each platform to be shared from 
           the .Net Standard shared code files
           Creates an interface from the shared code project into each platform with
           specific logic for each different platform
         
           1.Create an interface
           2.Implementing the interface
           3. the registering the dependancy into xamarin code

           This is often called dependancy injection

        how to create a dependancy

            first Method:
            1.create an interface in the shared project
            2.Create a folder in each of the platforms called dependancies
            3.Create a class that will inherit and implement the interface from the shared project in each of the platforms
            4.Register the class by using the attribute '[assembly: Dependency(typeof(theclassyourusing))]'
            5.Importing all the namespaces to support the attribute
            6.For a 'Task' method make sure in the returns 'async' is before the returned object 'Task'

            Second Method:
            1.in each of the Platforms open the respective classes that starts the app
            2.Define the type to register.
            3.Import all the referances to support the dependancies

            First method is preferable as dependancy files can be quite large
            so by using a seperate class you can extend the functionality

        how to use a dependancy

        */
    }
}
