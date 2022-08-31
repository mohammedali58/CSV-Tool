# CSV-Tool

## How it works

To begin using this tool do the following 

1- git clone this repository 
2- run this dotnet tool on IDE like visual studio 
3- press f5 or run icon to run the project
4- it will open swagger web page on the Home Controller
5- press on "try it out" button 
6- it will ask for uploading file >> "choose file" button (you can use the file uploaded with the solution testdata folder/input/log.cv)
7- then excute button will handle all the rest 
8- you will find the output result inside the CSV-Tool project (files will be beside the program.cs file)


## what I have used to make this tool 
  
I used clean architcture pattern to separate api layer, application layer(business) , persistence layer and core one
tried to apply solid principle in this tool like Separation of concern and open-closed and so on 
used interfaces/helpers/controllers/DI containers
 
as the time was sensitive, If I had more time I would implement  unit testing, exception handlers,dto and value objects

