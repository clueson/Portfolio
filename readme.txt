#My Portfolio

***** Quiz ******
a simple javasript ES6, HTML, CSS3, jquery webpage.

***** Sign Form ******
An interactive sing in form, using javascript ES6, HTML5, CSS3, Jquery

****** WPF Desktop app *****
A test application using the MVVM Prism framework, with unity and makes use of boostrap to 
override app.xaml file, guidance was obtained from the MS practice and patterns team on channel 9.
And a special mention goes to series of important prism videos published on youtube by Brian Lagunas 
from which I took great inspiration from!
I was able to write code and completely decouple the code behind .cs file, with no code visible inside 
any of the views code behind!
written in C# using VS2008 (migrated to VS2017) as a modular view model, leveraging
xaml, using the built in prism concepts of behaviours, the prism event aggregator, pub/sub service, 
region manager, the views are created using "user controls" which are injected into each pre defined 
region.Prism framework is loaded in each ViewModel using the "bindablebase" classes which exposes 
improved versions  of IPropertyNotyfyChange interface, Prism' own commanding pattern and much more!

 ***** WCF application Using SOAP and entity frameworks ******
 A test application created in WPF webforms,  using WCF, c#, and XAML and entity frameworks leveraging
 xaml to creat a webpage that access a sql database file on a host connection (simulated).

 ***** Xamarin Forms Weather Application using Rest Api's ******
 Programmed in Xamarin forms, using Xamarins version of xaml, c#, IOS, Android, UWP,
 is a small mobile app which retrieves weather data from a restful API, deserialised from json and then
 leveraged into objects which can be programmed against in c#.
 Uses the Sqlite database engine to store the weather data, and then extracts the data from the database
 which is then injected into the views. I have used commanding, IPropertyNotifyChanged, Public Bindable properties
 Commanding base classes and the use of action delegates. I have used the standard MVVM parttern to decouple
 the "view", the "viewmodel and the "model" form each other.

***** Xamarn Forms Expenses Application ******
A basic expenses application for UWP/IOS/Android, which records any expenses incurred, and places the
data into a database, then retreives the data and then is displayed in the UI.
The appllication makes use of the MVVM pattern, SQL Lite, LINQ to SQL, Commanding, 
IPropertyNotifyChanged, Custom renderers, behaviours, Property binding in XAML, resources, Dependency properties,

there are faults with this application which is an ongoing unfinnished project.
UWP has a file save fault which has yet o be resolved, android and IOS part of this function seems to work.


 

