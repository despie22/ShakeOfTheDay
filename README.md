# ShakeOfTheDay
This .NET application was developed as a unique school project to display Database inegration with Windows Forms.

This was written March 2020 and needs some refactoring, like creating for loops and adding more abtraction, that can been seen in the python version of this application which will be up soon.

In order to get the Database to work a few lines of code will need to be replaced.
In file explorer, copy the path of the ShakeOfTheDay folder.

On line 9 of PlayerList.vb replace "C:\Users\Dylan\Desktop\ShakeOfTheDay" with the copied path

On line 15 of ShakeForm.vb replace "C:\Users\Dylan\Desktop\ShakeOfTheDay" with the coped path

On line 336 of ShakeForm.vb replace the "C:\Users\Dylan\Desktop\ShakeOfTheDay" part of the string with the copied file path
"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=YOUR FILE PATH HERE\ShakeOfTheDay\PatronDB.mdf;Integrated Security=True;"

On line 336 I keep on getting an error if I try to concatinate the folder path in, any tips on a fix would be appreciated.
